using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.DAL.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);

        T Get(int id);

        List<T> GetAll(List<int> ids);

        void Update(T entity);

        void Delete(T entity);
    }
}
