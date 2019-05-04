using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.DAL.Entities
{
    public class UserMovie
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MovieId { get; set; }
    }
}
