using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieRecommenderMVC.DAL.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        public string GenreName { get; set; }
    }
}
