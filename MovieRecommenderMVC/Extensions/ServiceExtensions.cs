using Microsoft.Extensions.DependencyInjection;
using MovieRecommenderMVC.BLL.Services;
using MovieRecommenderMVC.BLL.Services.Interfaces;
using MovieRecommenderMVC.DAL.DataAccess;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using MovieRecommenderMVC.DAL.MongoDBAccess;

namespace MovieRecommenderMVC.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IRatingService, RatingService>();

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();

            services.AddScoped<MongoDbContext>();


            // Add all other services here.
            return services;
        }
    }
}
