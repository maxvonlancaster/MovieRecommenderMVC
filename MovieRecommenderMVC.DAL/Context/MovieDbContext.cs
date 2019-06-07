using Microsoft.EntityFrameworkCore;
using MovieRecommenderMVC.DAL.Entities;

namespace MovieRecommenderMVC.DAL.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) 
            : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserMovie> UserMovies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<ActorMovie> ActorMovies { get; set; }

        public DbSet<Microsoft.AspNetCore.Identity.IdentityUserClaim<string>> IdentityUserClaims { get; set; }
    }
}
