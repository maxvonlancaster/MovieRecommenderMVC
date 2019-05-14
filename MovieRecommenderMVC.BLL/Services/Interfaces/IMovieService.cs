using MovieRecommenderMVC.BLL.Models;
using MovieRecommenderMVC.DAL.Entities;
using System.Collections.Generic;

namespace MovieRecommenderMVC.BLL.Services.Interfaces
{
    public interface IMovieService
    {
        void Add(Movie entity);

        MovieModel Get(int id);

        List<MovieModel> GetAll(List<int> ids, string userId);

        void Update(Movie entity);

        void Delete(Movie entity);

        void DeleteById(int id);
    }
}
