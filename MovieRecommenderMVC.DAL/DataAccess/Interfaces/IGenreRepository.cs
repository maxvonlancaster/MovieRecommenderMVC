using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.DAL.DataAccess.Interfaces
{
    public interface IGenreRepository
    {
        void Add(Genre entity);

        Genre Get(int id);

        List<Genre> GetAll(List<int> ids);

        void Update(Genre entity);

        void Delete(Genre entity);

        Genre GetGenreByName(string genreName);
    }
}
