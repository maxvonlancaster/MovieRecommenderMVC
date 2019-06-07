using MovieRecommenderMVC.DAL.Entities;
using System.Collections.Generic;

namespace MovieRecommenderMVC.BLL.Services.Interfaces
{
    public interface IGenreService
    {
        void Add(Genre entity);

        Genre Get(int id);

        List<Genre> GetAll(List<int> ids);

        void Update(Genre entity);

        void Delete(Genre entity);

        Genre GetGenreByName(string genreName); 
    }
}
