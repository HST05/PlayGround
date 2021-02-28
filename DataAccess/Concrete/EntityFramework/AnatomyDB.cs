using Core.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class AnatomyDB:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Anatomy;Trusted_Connection=true");
        }

        public DbSet<Tissue> Tissues { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Sort> Sorts { get; set; }
        public DbSet<TissueImage> TissueImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
