using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcCoreGiris.Models
{
    public class OkulContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=OkulContextDb;uid=sa;pwd=123irem456");
        //}
        public OkulContext(DbContextOptions<OkulContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kisi>().HasData(
                new Kisi{Id = 1,KisiAd = "irem"}, 
                new Kisi{Id = 2,KisiAd = "meri"});
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Kisi> Kisiler { get; set; }

    }
}
