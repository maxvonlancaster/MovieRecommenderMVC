using MovieRecommenderMVC.BLL.Services.Interfaces;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using MovieRecommenderMVC.DAL.Entities;
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

        public Movie Get(int id)
        {
            return _movieRepository.Get(id);
        }

        public List<Movie> GetAll(List<int> ids)
        {
            return _movieRepository.GetAll(ids);
        }

        public void Update(Movie entity)
        {
            _movieRepository.Update(entity);
        }

        public void Delete(Movie entity)
        {
            _movieRepository.Delete(entity);
        }
    }
}
