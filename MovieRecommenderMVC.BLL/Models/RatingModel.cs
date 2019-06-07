using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.BLL.Models
{
    public class RatingModel
    {
        public int Id {get; set;}

        public string UserName { get; set; }

        public string UserFirstName { get; set; }

        public string UserId { get; set; }

        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string MovieGenre { get; set; }

        public int Rating { get; set; }

    }
}
