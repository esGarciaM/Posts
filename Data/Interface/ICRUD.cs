using Entities._Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ICRUD<T> where T : EntityBase
    {
        public IEnumerable<T> All();
        public T Get(int id);
        public int Add(T item);
        public bool Update(T item);
        public bool Delete(int id);
        IEnumerable<T> getRange(int from, int to);
        public IEnumerable<T> Where(string w);
        public DbSet<T> GetEntity();
    }
}
