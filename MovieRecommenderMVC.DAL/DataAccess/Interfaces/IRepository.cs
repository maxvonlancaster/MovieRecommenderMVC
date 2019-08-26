using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.DAL.DataAccess.Interfaces
{
    public interface IRepository<T, E> where T : class
    {
        void Add(T entity);

        T Get(E id);

        List<T> GetAll(List<E> ids);

        void Update(T entity);

        void Delete(T entity);

        List<T> GetConditional(System.Linq.Expressions.Expression<Func<T, bool>> lambda);
    }
}
