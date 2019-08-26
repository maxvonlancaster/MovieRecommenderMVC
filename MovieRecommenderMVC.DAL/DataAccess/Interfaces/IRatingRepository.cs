using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MovieRecommenderMVC.DAL.DataAccess.Interfaces
{
    public interface IRatingRepository : IRepository<UserMovie, int>
    {
        IQueryable<UserMovie> GetAllByUser(string userId);

        UserMovie GetByUserAndMovie(int movieId, string userId);
    }
}
