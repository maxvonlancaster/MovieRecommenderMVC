using MovieRecommenderMVC.DAL.Entities;
using System.Collections.Generic;

namespace MovieRecommenderMVC.BLL.Services.Interfaces
{
    public interface IMovieService
    {
        void Add(Movie entity);

        Movie Get(int id);

        List<Movie> GetAll(List<int> ids);

        void Update(Movie entity);

        void Delete(Movie entity);
    }
}
