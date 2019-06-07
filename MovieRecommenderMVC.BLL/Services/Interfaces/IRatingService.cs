using MovieRecommenderMVC.BLL.Models;
using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Services.Interfaces
{
    public interface IRatingService
    {
        void Add(RatingModel model);

        RatingModel Get(int id);

        List<RatingModel> GetAll(List<int> ids);

        void Update(RatingModel model);

        void Delete(RatingModel model);
    }
}
