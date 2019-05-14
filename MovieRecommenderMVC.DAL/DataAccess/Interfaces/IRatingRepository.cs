using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.DAL.DataAccess.Interfaces
{
    public interface IRatingRepository : IRepository<UserMovie, int>
    {
        UserMovie GetByUserAndMovie(int movieId, string userId);
    }
}
