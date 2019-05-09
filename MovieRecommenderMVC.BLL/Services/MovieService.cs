using MovieRecommenderMVC.BLL.Services.Interfaces;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using MovieRecommenderMVC.DAL.Entities;
using MovieRecommenderMVC.BLL.Models;
using System.Collections.Generic;

namespace MovieRecommenderMVC.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void Add(Movie entity)
        {
            _movieRepository.Add(entity);
        }

        public MovieModel Get(int id)
        {
            var movie = _movieRepository.Get(id);
            return new MovieModel()
            {
                MovieId = movie.MovieId,
                MovieGanre = movie.Ganre.GenreName,
                MovieName = movie.Name
            }; 
        }

        public List<MovieModel> GetAll(List<int> ids)
        {
            var movies = _movieRepository.GetAll(ids);
            var movieModels = new List<MovieModel>();
            foreach (var movie in movies)
            {
                movieModels.Add(new MovieModel()
                {
                    MovieId = movie.MovieId,
                    MovieName = movie.Name,
                    MovieGanre = movie.Ganre?.GenreName,
                });
            }
            return movieModels;
        }

        public void Update(Movie entity)
        {
            _movieRepository.Update(entity);
        }

        public void Delete(Movie entity)
        {
            _movieRepository.Delete(entity);
        }

        public void DeleteById(int id)
        {
            var entity = _movieRepository.Get(id);
            Delete(entity);
        }
    }
}
