using System.ComponentModel.DataAnnotations;

namespace MovieRecommenderMVC.DAL.Entities
{
    public class ActorMovie
    {
        [Key]
        public int Id { get; set; }

        public Actor Actor { get; set; }

        public Movie Movie { get; set; }
    }
}
