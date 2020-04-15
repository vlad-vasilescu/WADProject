using WADProject.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using WADProject.Repositories.Abstractions;

namespace WADProject.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        protected readonly ApplicationDbContext dbContext;

        public GeneralRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Get(int? id)
        {
            return dbContext.Find<T>(id);
        }

        public void Add(T item)
        {
            dbContext.Add<T>(item);
            dbContext.SaveChanges();
        }

        public void Remove(T item)
        {
            dbContext.Remove<T>(item);
            dbContext.SaveChanges();
        }

        public void Update(T item)
        {
            dbContext.Update<T>(item);
            dbContext.SaveChanges();
        }

        public bool Exists(int? id)
        {
            if (dbContext.Find<T>(id) != null)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}