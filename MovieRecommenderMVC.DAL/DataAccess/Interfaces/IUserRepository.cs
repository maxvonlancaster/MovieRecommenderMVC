using MovieRecommenderMVC.DAL.Entities;
using System.Collections.Generic;

namespace MovieRecommenderMVC.DAL.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        void Add(User entity);

        User Get(int id);

        List<User> GetAll(List<int> ids);

        void Update(User entity);

        void Delete(User entity);
    }
}
