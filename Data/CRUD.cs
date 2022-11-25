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
            //_entity = _dbContext.Set<T>();
        }
        public void Add(T item)
        {
            _entity.Add(item);
            _dbContext.SaveChanges();
        }
        public IEnumerable<T> All()
        {
            return _entity.ToList();
        }
        public void Delete(int id)
        {
            T item = this.Get(id);
            _entity.Remove(item);
            _dbContext.SaveChanges();
        }
        public T Get(int id)
        {
            T item = _entity.FirstOrDefault(x => x.id == id);
            return item;
            /*T item = _entity.Find(id);
            return item;*/
        }
        public void Update(T item)
        {
            _entity.Attach(item);
            //_dbContext.SaveChanges();
            /*T uitem = Get(item.Id);
            _dbContext.Entry(uitem).CurrentValues.SetValues(item);*/
            _dbContext.SaveChanges();
        }
        public T getLast() { 
            return _entity.Last(); ;
        }
        public IEnumerable<T> Where(string w)
        {
            return _entity.FromSqlRaw(w).ToList();
            //return _entity.Where(x => x.id == w);
            //T item = _entity.FirstOrDefault(x => x.id == id);
            //return item;
            
        }
    }
}