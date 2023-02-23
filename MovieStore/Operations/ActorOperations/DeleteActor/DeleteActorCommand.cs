using MovieStore.DatabaseOperations;

namespace MovieStore.Operations.ActorOperations.DeleteActor
{
    public class DeleteActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int ActorId { get; set; }

        public DeleteActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == ActorId);
            if(actor == null)
            {
                throw new InvalidOperationException("Silinecek oyuncu bulunamadı");
            }
            if(_context.Movies.Any(x=>x.Id == ActorId))
            {
                throw new InvalidOperationException("Oyuncunun filmi mevcut");
            }
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }
    }
}
