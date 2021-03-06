﻿using MovieRecommenderMVC.DAL.Entities;
using System.Collections.Generic;

namespace MovieRecommenderMVC.DAL.DataAccess.Interfaces
{
    public interface IMovieRepository : IRepository<Movie, int>
    {
        EntityFrameworkPaginate.Page<Movie> GetPaginatedMovies(Models.PagingModel pagingModel);
    }
}
