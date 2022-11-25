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
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vacante> VACANTE { get; set; }
        public DbSet<Entrevista> ENTREVISTA { get; set; }
        public DbSet<Prospecto> PROSPECTO { get; set; }
        DbContext Instance { get; }
        public int SaveChanges();

    }
}
