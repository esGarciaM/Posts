using Entities._Class;
using Entities._Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities._Interface
{
    public interface IContext:IDisposable
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<Provider> Providers{ get; set; }
        public DbSet<Product> Products { get; set; }
        DbContext Instance { get; }
        public int SaveChanges();

    }
}
