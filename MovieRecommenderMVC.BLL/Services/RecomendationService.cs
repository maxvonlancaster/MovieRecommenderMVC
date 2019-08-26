using MovieRecommenderMVC.BLL.Services.Interfaces;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using MovieRecommenderMVC.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieRecommenderMVC.BLL.Services
{
    public class RecomendationService : IRecomendationService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;

        public RecomendationService(IRatingRepository ratingRepository, 
            IUserRepository userRepository, 
            IMovieRepository movieRepository)
        {
            _ratingRepository = ratingRepository;
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public List<Movie> GetRecommended(string UserId)
        {
            var recommendations = _ratingRepository.GetConditional(r => r.Rating > 5 && r.User.Id == UserId)
                .Select(r => r.Movie)
                .ToList();
            return recommendations;
        }
    }
}
