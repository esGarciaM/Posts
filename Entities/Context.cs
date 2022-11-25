﻿using Entities._Class;
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
            //options.UseSqlServer("server=localhost;database=minipost;user=sa;password=AFS2018;");
            options.UseSqlServer("server=108.178.119.50;database=entrevista;user=sa;password=AFS3112.*;");
        }
        protected override void OnModelCreating(ModelBuilder model) {
            model.Entity<Post>().HasKey("id");
            model.Entity<User>().HasKey("id");

            model.Entity<Vacante>().HasKey("id");
            model.Entity<Prospecto>().HasKey("id");
            model.Entity<Entrevista>().HasKey("id");

        }
        public DbSet<Post> Posts { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<Vacante> VACANTE { get; set; }
        public DbSet<Entrevista> ENTREVISTA{ get; set; }
        public DbSet<Prospecto> PROSPECTO{ get; set; }
        public DbContext Instance => this;
    }
}
