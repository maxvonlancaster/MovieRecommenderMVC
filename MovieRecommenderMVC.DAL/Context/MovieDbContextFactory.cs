using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MovieRecommenderMVC.DAL.Context
{
    class MovieDbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-2M0GJS3G\\SQLEXPRESS;Database=MovieRecommender;Trusted_Connection=True;");

            return new MovieDbContext(optionsBuilder.Options);
        }
    }

}
