using MovieRecommenderMVC.DAL.DataAccess.Interfaces;
using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MovieRecommenderMVC.DAL.DataAccess
{
    public class ActorRepository : IActorRepository
    {
        public void Add(Actor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Actor entity)
        {
            throw new NotImplementedException();
        }

        public Actor Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Actor> GetAll(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public List<Actor> GetConditional(Expression<Func<Actor, bool>> lambda)
        {
            throw new NotImplementedException();
        }

        public void Update(Actor entity)
        {
            throw new NotImplementedException();
        }
    }
}
