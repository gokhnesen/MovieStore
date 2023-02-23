using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int MovieId { get; set; }

        public UpdateMovieModel Model { get; set; }

        public UpdateMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;

        }

        public void Handle()
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == MovieId);
            if(movie == null)
            {
                throw new InvalidOperationException("Film bulunamadı");
            }
            movie.Name=Model.Name != default ? Model.Name : movie.Name;
            movie.Price=Model.Price != default ? Model.Price : movie.Price;
            movie.DirectorId = Model.DirectorId != default ? Model.DirectorId : movie.DirectorId;
            movie.GenreId = Model.GenreId != default ? Model.GenreId : movie.GenreId;
            movie.PublishDate=Model.PublishDate != default ? Model.PublishDate : movie.PublishDate;
            movie.Actor = Model.Actor !=default ? Model.Actor : movie.Actor;

            _context.SaveChanges();
        }
    }

    public class UpdateMovieModel
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public List<Actor> Actor { get; set; }
        public float Price { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
