using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.DAL.DataAccess.Interfaces
{
    public interface IGenreRepository : IRepository<Genre, int>
    {
        Genre GetGenreByName(string genreName);
    }
}
