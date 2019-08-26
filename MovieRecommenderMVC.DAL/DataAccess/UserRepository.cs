using MovieRecommenderMVC.DAL.Context;
using MovieRecommenderMVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using System;
using System.Linq.Expressions;

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

        public User Get(string id) {
            return _movieDbContext.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();
        }

        public List<User> GetAll(List<string> ids) {
            return _movieDbContext.Users
                .Where(u => ids.Contains(u.Id))
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

        public List<User> GetConditional(Expression<Func<User, bool>> lambda)
        {
            throw new NotImplementedException();
        }
    }
}
