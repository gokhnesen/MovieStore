using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> Order { get; set; }
        public List<Genre> FavoriteGenre { get; set; }
    }
}
