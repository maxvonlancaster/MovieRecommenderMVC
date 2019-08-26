using MovieRecommenderMVC.DAL.Entities;
using System.Collections.Generic;

namespace MovieRecommenderMVC.BLL.Models
{
    public class MovieModel
    {
        public int? MovieId { get; set; }

        public string MovieName { get; set; }

        public string MovieGanre { get; set; }

        public int? Rating { get; set; }

        public List<Actor> Actors { get; set; }

        public Director Director { get; set; }
    }
}
