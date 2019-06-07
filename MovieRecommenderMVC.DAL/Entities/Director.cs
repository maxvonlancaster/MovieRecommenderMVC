using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRecommenderMVC.DAL.Entities
{
    public class Director
    {
        [Key]
        public int Id { get; set; }

        public string DirectorName { get; set; }

        public string DirectorSecondName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
