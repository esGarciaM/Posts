using Entities._Class;
using Entities._Entities;
using Entities._Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contest : DbContext ,IContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=localhost;database=FA1;user=sa;password=AFS2018;");
            //options.UseSqlServer("server=108.178.119.50;database=entrevista;user=sa;password=AFS3112.*;");
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<User>().HasKey("id");
            model.Entity<Client>().HasKey("id");
            model.Entity<Product>().HasKey("id");
            model.Entity<Provider>().HasKey("id");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbContext Instance => this;
    }
}
