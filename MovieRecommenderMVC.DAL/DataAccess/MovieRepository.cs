using MovieRecommenderMVC.DAL.Context;
using MovieRecommenderMVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;

namespace MovieRecommenderMVC.DAL.DataAccess
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public MovieRepository(MovieDbContext context)
        {
            _movieDbContext = context;
        }

        public void Add(Movie entity)
        {
            _movieDbContext.Movies.Add(entity);
            _movieDbContext.SaveChanges();
        }

        public Movie Get(int id)
        {
            return _movieDbContext.Movies
                .Where(m => m.MovieId == id)
                .Include(m => m.Ganre)
                .FirstOrDefault();
        }

        public List<Movie> GetAll(List<int> ids)
        {
            if (ids != null)
            {
                return _movieDbContext.Movies
                    .Where(m => ids.Contains(m.MovieId))
                    .Include(m => m.Ganre)
                    .ToList();
            }
            else
            {
                var movies = _movieDbContext.Movies
                    .Include(m => m.Ganre)
                    .ToList();
                return movies;
            }
        }

        public void Update(Movie entity)
        {
            _movieDbContext.Movies.Update(entity);
            _movieDbContext.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            _movieDbContext.Movies.Remove(entity);
            _movieDbContext.SaveChanges();
        }
    }
}
