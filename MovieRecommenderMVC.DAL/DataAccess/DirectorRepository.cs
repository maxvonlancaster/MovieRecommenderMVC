using MovieRecommenderMVC.DAL.Context;
using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MovieRecommenderMVC.DAL.DataAccess
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public DirectorRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public void Add(Director entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Director entity)
        {
            throw new NotImplementedException();
        }

        public Director Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Director> GetAll(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public List<Director> GetConditional(Expression<Func<Director, bool>> lambda)
        {
            throw new NotImplementedException();
        }

        public void Update(Director entity)
        {
            throw new NotImplementedException();
        }
    }
}
