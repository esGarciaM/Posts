using Data.Interface;
using Entities;
using Entities._Class;
using Entities._Interface;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CRUD<T> : ICRUD<T> where T : EntityBase
    {
        private readonly Context _dbContext;
        private readonly DbSet<T> _entity;
        public CRUD(Context context)
        {
            _dbContext = context;
            _entity = _dbContext.Set<T>();

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
        }
        public T Get(int id)
        {
            /*T item = _entity.FirstOrDefault(x => x.Id == id);
            return item;*/
            T item = _entity.Find(id);
            return item;
        }
        public void Update(T item)
        {
            //_entity.Attach(item);
            //_dbContext.SaveChanges();
            T uitem = Get(item.Id);
            _dbContext.Entry(uitem).CurrentValues.SetValues(item);
            _dbContext.SaveChanges();
        }
    }
}