using System.Collections.Generic;

namespace WADProject.Repositories.Abstractions
{
    public interface IGeneralRepository<T> where T : class
    {
        public T Get(int? id);
        public void Add(T item);
        public void Remove(T item);
        public void Update(T item);
        public bool Exists(int? id);
    }
}