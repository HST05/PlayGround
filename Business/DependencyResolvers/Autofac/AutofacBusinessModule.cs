using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

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
            

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
