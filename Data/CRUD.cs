using Data.Interface;
using Entities;
using Entities._Class;
using Entities._Interface;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CRUD<T> : ICRUD<T> where T : EntityBase
    {
        private readonly IContext _dbContext;
        private readonly DbSet<T> _entity;
        public CRUD(IContext context)
        {
            _dbContext = context;
            _entity = _dbContext.Instance.Set<T>();
        }
        public int Add(T item)
        {
            _entity.Add(item);
            _dbContext.SaveChanges();
            int id = item.id;
            return id;
        }
        public IEnumerable<T> All()
        {
            return _entity.ToList();
        }
        public bool Delete(int id)
        {
            T item = this.Get(id);
            if (item != null)
            {
                _entity.Remove(item);
                _dbContext.SaveChanges();
            }
            if(this.Get(id) == null) return true;
            return false;
        }
        public T Get(int id)
        {
            T item = _entity.FirstOrDefault(x => x.id == id);
            return item;
        }
        public bool Update(T item)
        {
            _entity.Attach(item);
            _dbContext.SaveChanges();
            return true;
        }
        public T getLast() { 
            return _entity.Last(); ;
        }
        public IEnumerable<T> getRange(int from, int to)
        {
            return _entity.Where(x => x.id >= from).Where(x=> x.id >= to);
        }
        public IEnumerable<T> Where(string w)
        {
            return _entity.FromSqlRaw(w).ToList();
            //return _entity.Where(x => x.id == w);
            //T item = _entity.FirstOrDefault(x => x.id == id);
            //return item;
        }
        public DbSet<T> GetEntity() {
            return _entity;
        }
    }
}