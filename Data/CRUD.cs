﻿using Data.Interface;
using Entities._Class;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CRUD<T> : ICRUD<T> where T : EntityBase
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _entity;
        public CRUD(DbContext context)
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
            _entity.Attach(item);
            _dbContext.SaveChanges();
        }
    }
}