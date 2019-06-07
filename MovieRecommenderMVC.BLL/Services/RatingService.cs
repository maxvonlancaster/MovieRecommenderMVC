using MovieRecommenderMVC.BLL.Models;
using MovieRecommenderMVC.BLL.Services.Interfaces;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using MovieRecommenderMVC.DAL.Entities;
using System.Collections.Generic;

namespace MovieRecommenderMVC.BLL.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;

        public RatingService(IRatingRepository ratingRepository,
            IUserRepository userRepository,
            IMovieRepository movieRepository)
        {
            _ratingRepository = ratingRepository;
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public void Add(RatingModel model)
        {
            var user = _userRepository.Get(model.UserId);
            var movie = _movieRepository.Get(model.MovieId);
            _ratingRepository.Add(new UserMovie() {User = user,
                Movie = movie,
                Rating = model.Rating });
        }

        public void Delete(RatingModel model)
        {
            var user = _userRepository.Get(model.UserId);
            var movie = _movieRepository.Get(model.MovieId);
            _ratingRepository.Delete(new UserMovie()
            {
                User = user,
                Movie = movie,
                Rating = model.Rating
            });
        }

        public RatingModel Get(int id)
        {
            var userMovie = _ratingRepository.Get(id);
            return new RatingModel()
            {
                UserName = userMovie.User.UserName,
                UserFirstName = userMovie.User.UserFirstName,
                UserId = userMovie.User.Id,
                MovieId = userMovie.Movie.MovieId,
                MovieName = userMovie.Movie.Name,
                MovieGenre = userMovie.Movie.Ganre.GenreName,
                Rating = userMovie.Rating
            };
        }

        public List<RatingModel> GetAll(List<int> ids)
        {
            var ratingModels = new List<RatingModel>();
            var userMovies = _ratingRepository.GetAll(ids);
            foreach (var userMovie in userMovies) {
                ratingModels.Add(new RatingModel()
                {
                    UserName = userMovie.User.UserName,
                    UserFirstName = userMovie.User.UserFirstName,
                    UserId = userMovie.User.Id,
                    MovieId = userMovie.Movie.MovieId,
                    MovieName = userMovie.Movie.Name,
                    MovieGenre = userMovie.Movie.Ganre.GenreName,
                    Rating = userMovie.Rating
                });
            }
            return ratingModels;
        }

        public void Update(RatingModel model)
        {
            var id = model.Id;
            var user = _userRepository.Get(model.UserId);
            var movie = _movieRepository.Get(model.MovieId);
            if (id == 0)
            {
                id = _ratingRepository.GetByUserAndMovie(movie.MovieId, user.Id).Id;
            }
            _ratingRepository.Update(new UserMovie()
            {
                Id = id,
                User = user,
                Movie = movie,
                Rating = model.Rating
            });
        }
    }
}
