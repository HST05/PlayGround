using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Type = Entities.Concrete.Type;

namespace DataAccess.Concrete
{
    public class AnatomyDB:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Anatomy;Trusted_Connection=true");
        }

        public DbSet<Tissue> Tissues { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}
