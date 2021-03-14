using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using VallyExpress.Models;

namespace VallyExpress.DataBase
{
    public class ShopContext : DbContext
    {
        
        private string conString;

        public DbSet<Product> Products { get; set; }
        public DbSet<Reserv> Reserved { get; set; }
        public DbSet<User> Users { get; set; }

        public ShopContext(string cs)
        {
            conString = cs;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if ( !optionsBuilder.IsConfigured ) optionsBuilder.UseNpgsql(conString);
            base.OnConfiguring(optionsBuilder);
        }

    }

}
