using MovieRecommenderMVC.DAL.Context;
using MovieRecommenderMVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using EntityFrameworkPaginate;
using MovieRecommenderMVC.DAL.Models;
using System;
using System.Linq.Expressions;
using MovieRecommenderMVC.DAL.MongoDBAccess;

namespace MovieRecommenderMVC.DAL.DataAccess
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext;

        private readonly MongoDbContext _mongoDbContext;

        public MovieRepository(MovieDbContext context, MongoDbContext mcontext)
        {
            _movieDbContext = context;
            _mongoDbContext = mcontext;
        }

        public async void Add(Movie entity)
        {
            _movieDbContext.Movies.Add(entity);
            _movieDbContext.SaveChanges();
            var collection = _mongoDbContext.database.GetCollection<Movie>("Movies");
            await collection.InsertOneAsync(entity);
        }

        public Movie Get(int id)
        {
            return _movieDbContext.Movies
                .Where(m => m.MovieId == id)
                .Include(m => m.Ganre)
                .Include(m => m.Director)
                .FirstOrDefault();
        }

        public List<Movie> GetAll(List<int> ids)
        {
            if (ids != null)
            {
                return _movieDbContext.Movies
                    .Where(m => ids.Contains(m.MovieId))
                    .Include(m => m.Ganre)
                    .Include(m => m.Director).ToList();
            }
            else
            {
                var movies = _movieDbContext.Movies
                    .Include(m => m.Ganre)
                    .Include(m => m.Director)
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

        public Page<Movie> GetPaginatedMovies(PagingModel pagingModel)
        {
            Page<Movie> movies;
            var filters = new Filters<Movie>();
            var sortings = new Sorts<Movie>();

            sortings.Add(pagingModel.SortBy == 1, x => x.MovieId, pagingModel.IsDescending ?? false);
            sortings.Add(pagingModel.SortBy == 2, x => x.Name, pagingModel.IsDescending ?? false);
            sortings.Add(pagingModel.SortBy == 3, x => x.Ganre, pagingModel.IsDescending ?? false);

            filters.Add(pagingModel.SearchBy == 2 && !string.IsNullOrEmpty(pagingModel.SearchText),
                x => x.Name.Contains(pagingModel.SearchText));
            filters.Add(pagingModel.SearchBy == 3 && !string.IsNullOrEmpty(pagingModel.SearchText),
                x => x.Ganre.GenreName.Contains(pagingModel.SearchText));

            movies = _movieDbContext.Movies.Paginate(pagingModel.PageNumber, pagingModel.PageSize, sortings, filters);
            return movies;
        }

        public List<Movie> GetConditional(Expression<Func<Movie, bool>> lambda)
        {
            return _movieDbContext.Movies
                .Where(lambda)
                .ToList();
        }
    }
}
