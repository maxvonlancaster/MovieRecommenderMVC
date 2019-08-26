using MovieRecommenderMVC.DAL.Context;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MovieRecommenderMVC.DAL.DataAccess
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public GenreRepository(MovieDbContext context)
        {
            _movieDbContext = context;
        }

        public void Add(Genre entity)
        {
            _movieDbContext.Genres.Add(entity);
            _movieDbContext.SaveChanges();
        }

        public Genre Get(int id)
        {
            return _movieDbContext.Genres
                .Where(g => g.Id == id)
                .FirstOrDefault();
        }

        public List<Genre> GetAll(List<int> ids)
        {
            if (ids != null)
            {
                return _movieDbContext.Genres
                    .Where(g => ids.Contains(g.Id))
                    .ToList();
            }
            else
            {
                return _movieDbContext.Genres.ToList();
            }
        }

        public void Update(Genre entity)
        {
            _movieDbContext.Genres.Update(entity);
            _movieDbContext.SaveChanges();
        }

        public void Delete(Genre entity)
        {
            _movieDbContext.Genres.Remove(entity);
            _movieDbContext.SaveChanges();
        }

        public Genre GetGenreByName(string genreName)
        {
            return _movieDbContext.Genres
                .Where(g => g.GenreName == genreName)
                .FirstOrDefault();
        }

        public List<Genre> GetConditional(Expression<Func<Genre, bool>> lambda)
        {
            return _movieDbContext.Genres
                .Where(lambda)
                .ToList(); ;
        }
    }
}
