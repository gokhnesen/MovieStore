using MovieStore.DatabaseOperations;

namespace MovieStore.Operations.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int MovieId { get; set; }

        public DeleteMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == MovieId);
            if(movie == null)
            {
                throw new InvalidOperationException("Silinecek film bulunamadı");
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
