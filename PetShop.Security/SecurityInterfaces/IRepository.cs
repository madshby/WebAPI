using System.Collections.Generic;

namespace PetShop.Security.SecurityInterfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        T Add(T entity);
        T Edit(T entity);
        T Remove(long id);
    }
}