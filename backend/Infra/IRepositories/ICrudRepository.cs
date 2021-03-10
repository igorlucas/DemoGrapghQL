using System.Collections.Generic;

namespace Infra.IRepositories
{
    public interface ICrudRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        IEnumerable<T> Read();
        T Read(int id);
        void Delete(T entity);
        int Commit();
    }
}
