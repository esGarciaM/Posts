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
            options.UseSqlServer("server=localhost;database=minipost;user=sa;password=AFS2018;");
        }
        protected override void OnModelCreating(ModelBuilder model) {
            model.Entity<Post>().HasKey("Id");
            model.Entity<User>().HasKey("Id");
        }
        public DbSet<Post> Posts { get; set;}
        public DbSet<User> Users { get; set;}
        
    }
}
