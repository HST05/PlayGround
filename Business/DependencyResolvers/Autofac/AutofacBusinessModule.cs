using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Filing;
using Core.Utilities.Filing.Database;
using Core.Utilities.Filing.Local;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TissueManager>().As<ITissueService>().SingleInstance();
            builder.RegisterType<TissueDal>().As<ITissueDal>().SingleInstance();

            builder.RegisterType<SortManager>().As<ISortService>().SingleInstance();
            builder.RegisterType<SortDal>().As<ISortDal>().SingleInstance();
            
            builder.RegisterType<TissueImageManager>().As<ITissueImageService>().SingleInstance();
            builder.RegisterType<TissueImageDal>().As<ITissueImageDal>().SingleInstance();

            builder.RegisterType<ImageLocalFiling>().As<LocalFileSystem>().SingleInstance();
            builder.RegisterType<ImageDbFiling>().As<DatabaseFileSytem>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
