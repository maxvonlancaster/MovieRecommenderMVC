using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    }
}
