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
    public class Context : DbContext,IContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("server=localhost;database=FA1;user=sa;password=AFS2018;");
            //options.UseSqlServer("server=108.178.119.50;database=entrevista;user=sa;password=AFS3112.*;");
        }
        protected override void OnModelCreating(ModelBuilder model) {
            model.Entity<User>().HasKey("id");
            model.Entity<Client>().HasKey("id");
            model.Entity<Provider>().HasKey("id");
            model.Entity<Provider>().HasMany(r => r.products).WithOne(c => c.provider).HasForeignKey(r => r.providerid).HasConstraintName("FK_PROVIDERID");
            
            model.Entity<Product>().HasKey("id");
            model.Entity<Order>().HasKey("id");
            //model.Entity<Order>().HasMany(r => r.Details).WithOne(r => r.Order).HasForeignKey(r=>r.OrderID).HasConstraintName("FK_ORDERID");
            //model.Entity<Order>().HasMany<OrderDetails>("Order");

            model.Entity<OrderDetails>().HasKey("id");
            //model.Entity<OrderDetails>().HasOne<Order>()
            //model.Entity<OrderDetails>().hasdef


        }

        public DbSet<User> Users { get; set;}
        public DbSet<Client> Clients { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbContext Instance => this;

    }
}
