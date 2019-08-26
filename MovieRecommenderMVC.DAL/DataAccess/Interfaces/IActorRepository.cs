using MovieRecommenderMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.DAL.DataAccess.Interfaces
{
    public interface IActorRepository : IRepository<Actor, int>
    {
    }
}
