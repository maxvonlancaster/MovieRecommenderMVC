using MovieRecommenderMVC.DAL.Context;
using MovieRecommenderMVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MovieRecommenderMVC.DAL.DataAccess
{
    class UserRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public UserRepository(MovieDbContext context) {
            _movieDbContext = context;
        }

        public void Add(User entity) {
            _movieDbContext.Users.Add(entity);
        }

        public List<User> GetAll(List<int> ids) {
            return _movieDbContext.Users
                .Where(u => ids.Contains(u.UserId))
                .ToList();
        }
    }
}
