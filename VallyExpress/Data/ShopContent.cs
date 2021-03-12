using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace VallyExpress.Data
{
    class ShopContent : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public ShopContent()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем бд с новой схемой    
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Host = localhost; Port=5432;Database=store;Username=postgres;Password=test");
    }

}
