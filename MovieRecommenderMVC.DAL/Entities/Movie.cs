using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRecommenderMVC.DAL.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MovieId { get; set; }

        public string Name { get; set; }

        public Genre Ganre { get; set; }

        public Director Director { get; set; }
    }
}
