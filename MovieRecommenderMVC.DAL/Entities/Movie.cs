using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.DAL.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Name { get; set; }

        public string Ganre { get; set; }
    }
}
