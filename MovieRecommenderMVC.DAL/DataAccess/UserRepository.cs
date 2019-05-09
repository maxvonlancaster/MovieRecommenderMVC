using MovieRecommenderMVC.DAL.Context;
using MovieRecommenderMVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;

namespace MovieRecommenderMVC.DAL.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public UserRepository(MovieDbContext context) {
            _movieDbContext = context;
        }

        public void Add(User entity) {
            _movieDbContext.Users.Add(entity);
            _movieDbContext.SaveChanges();
        }

        public User Get(int id) {
            return _movieDbContext.Users
                .Where(u => u.UserId == id)
                .FirstOrDefault();
        }

        public List<User> GetAll(List<int> ids) {
            return _movieDbContext.Users
                .Where(u => ids.Contains(u.UserId))
                .ToList();
        }

        public void Update(User entity) {
            _movieDbContext.Users.Update(entity);
            _movieDbContext.SaveChanges();
        }

        public void Delete(User entity) {
            _movieDbContext.Users.Remove(entity);
            _movieDbContext.SaveChanges();
        }
    }
}
