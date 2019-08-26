using Microsoft.EntityFrameworkCore;
using MovieRecommenderMVC.DAL.Context;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieRecommenderMVC.DAL.DataAccess
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public RatingRepository(MovieDbContext context)
        {
            _movieDbContext = context;
        }

        public void Add(UserMovie entity)
        {
            _movieDbContext.UserMovies.Add(entity);
            _movieDbContext.SaveChanges();
        }

        public void Delete(UserMovie entity)
        {
            _movieDbContext.UserMovies.Remove(entity);
            _movieDbContext.SaveChanges();
        }

        public UserMovie Get(int id)
        {
            return _movieDbContext.UserMovies
                .Where(u => u.Id == id)
                .Include(u => u.User)
                .Include(u => u.Movie)
                .FirstOrDefault();
        }

        public List<UserMovie> GetAll(List<int> ids)
        {
            if (ids != null)
            {
                return _movieDbContext.UserMovies
                    .Where(u => ids.Contains(u.Id))
                    .Include(u => u.Movie)
                    .Include(u => u.User)
                    .ToList();
            }
            else
            {
                return _movieDbContext.UserMovies
                    .Include(u => u.Movie)
                    .Include(u => u.User)
                    .ToList();
            }
        }

        public IQueryable<UserMovie> GetAllByUser(string userId)
        {
            return _movieDbContext.UserMovies
                .Where(u => u.User.Id == userId)
                .Include(u => u.Movie)
                .Include(u => u.User);
        }
            
        public void Update(UserMovie entity)
        {
            // REWRITE
            var oldEntity = _movieDbContext.UserMovies.Where(u => u.Id == entity.Id).FirstOrDefault();
            oldEntity.Rating = entity.Rating;
            _movieDbContext.SaveChanges();
        }

        public UserMovie GetByUserAndMovie(int movieId, string userId)
        {
            return _movieDbContext.UserMovies
                .Where(u => u.User.Id == userId && u.Movie.MovieId == movieId)
                .FirstOrDefault();
        }

        public List<UserMovie> GetConditional(Expression<Func<UserMovie, bool>> lambda)
        {
            return _movieDbContext.UserMovies
                .Where(lambda)
                .Include(u => u.Movie)
                .Include(u => u.User)
                .ToList();
        }
    }
}
