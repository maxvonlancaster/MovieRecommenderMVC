using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieRecommenderMVC.DAL.Entities
{
    public class UserMovie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public User User { get; set; }

        public Movie Movie { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }
    }
}
