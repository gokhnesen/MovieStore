using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
        public float Price { get; set; }
        public List<Actor> Actor { get; set; }
        public Director Director { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
