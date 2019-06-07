using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRecommenderMVC.DAL.Entities
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        public string ActorName { get; set; }

        public string ActorSecondName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
