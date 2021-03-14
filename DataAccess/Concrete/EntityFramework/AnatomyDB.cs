using Core.Concrete;
using Core.Utilities.Interceptors;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

//using Z.EntityFramework.Extensions;

namespace DataAccess.Concrete.EntityFramework
{
    public class AnatomyDB : DbContext
    {
        //public static StringTrimmerInterceptor stringTrimmerInterceptorInterceptor = new StringTrimmerInterceptor();
        //public AnatomyDB()
        //{
        //    this.BindInterceptor(stringTrimmerInterceptorInterceptor);
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //DbInterception.Add(stringTrimmerInterceptorInterceptor);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Anatomy;Trusted_Connection=true");
            //optionsBuilder.AddInterceptors(stringTrimmerInterceptorInterceptor);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var types = modelBuilder.Model.GetEntityTypes();
            foreach (var type in types)
            {
                var properties = type.ClrType.GetProperties();
                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        modelBuilder.Entity(type.ClrType).Property(property.Name)
                            .HasConversion(new ValueConverter<string, string>(v => v.TrimEnd(), v => v.TrimEnd()));
                    }
                }
            }
        }

        public DbSet<Tissue> Tissues { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Sort> Sorts { get; set; }
        public DbSet<TissueImage> TissueImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
