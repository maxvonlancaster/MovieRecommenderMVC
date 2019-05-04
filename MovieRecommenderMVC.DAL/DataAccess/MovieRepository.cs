using MovieRecommenderMVC.DAL.Context;
using MovieRecommenderMVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MovieRecommenderMVC.DAL.DataAccess
{
    public class MovieRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public MovieRepository(MovieDbContext context)
        {
            _movieDbContext = context;
        }

        public void Add(Movie entity)
        {
            _movieDbContext.Movies.Add(entity);
        }

        public Movie Get(int id)
        {
            return _movieDbContext.Movies
                .Where(m => m.MovieId == id)
                .FirstOrDefault();
        }

        public List<Movie> GetAll(List<int> ids)
        {
            return _movieDbContext.Movies
                .Where(m => ids.Contains(m.MovieId))
                .ToList();
        }

        public void Update(Movie entity)
        {
            _movieDbContext.Movies.Update(entity);
        }

        public void Delete(Movie entity)
        {
            _movieDbContext.Movies.Remove(entity);
        }
    }
}
