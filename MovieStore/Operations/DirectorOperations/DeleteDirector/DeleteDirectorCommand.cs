using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieStore.DatabaseOperations;

namespace MovieStore.Operations.DirectorOperations.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int DirectorId { get; set; }

        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Actors.SingleOrDefault(x => x.Id == DirectorId);
            if(director == null)
            {
                throw new InvalidOperationException("Sillinecek Yönetmen bulunamadı");
            }
            _context.Actors.Remove(director);
            _context.SaveChanges();
        }
    }
}
