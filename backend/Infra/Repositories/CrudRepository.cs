using Infra.Contexts;
using Infra.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private readonly DataContext _db;

        public CrudRepository(DataContext db) => _db = db;

        public int Commit() => _db.SaveChanges();

        public void Create(T entity) => _db.Add(entity);

        public void Delete(T entity) => _db.Remove(entity);

        public IEnumerable<T> Read() => _db.Set<T>().ToArray();

        public T Read(int id) => _db.Set<T>().Find(id);

        public void Update(T entity) => _db.Entry(entity).State = EntityState.Modified;
    }
}
