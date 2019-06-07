using MovieRecommenderMVC.BLL.Services.Interfaces;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;

namespace MovieRecommenderMVC.BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void Add(Genre entity)
        {
            _genreRepository.Add(entity);
        }

        public void Delete(Genre entity)
        {
            _genreRepository.Delete(entity);
        }

        public Genre Get(int id)
        {
            return _genreRepository.Get(id);
        }

        public List<Genre> GetAll(List<int> ids)
        {
            return _genreRepository.GetAll(ids);
        }

        public Genre GetGenreByName(string genreName)
        {
            return _genreRepository.GetGenreByName(genreName);
        }

        public void Update(Genre entity)
        {
            _genreRepository.Update(entity);
        }
    }
}
