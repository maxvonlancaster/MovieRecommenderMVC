using MovieRecommenderMVC.DAL.Entities;
using System.Collections.Generic;

namespace MovieRecommenderMVC.DAL.DataAccess.Interfaces
{
    public interface IMovieRepository
    {
        void Add(Movie entity);

        Movie Get(int id);

        List<Movie> GetAll(List<int> ids);

        void Update(Movie entity);

        void Delete(Movie entity);
    }
}
