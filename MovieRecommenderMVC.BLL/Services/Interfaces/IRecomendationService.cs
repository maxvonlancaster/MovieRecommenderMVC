using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Services.Interfaces
{
    public interface IRecomendationService
    {
        List<Movie> GetRecommended(string UserId);
    }
}
