using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.Operations.ActorOperations.GetActor;

namespace MovieStore.Operations.ActorOperations.UpdateActor
{
    public class UpdateActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int ActorId { get; set; }
        public UpdateActorModel Model { get; set; }

        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == ActorId);
            if(actor is null)
            {
                throw new InvalidOperationException("Aktör bulunamadı");
            }
            if (_context.Actors.Any(x => x.Name.ToLower() == Model.Name && x.Surname == Model.Surname))
            { 
                throw new InvalidOperationException("Aynı aktör mevcut");
            }

            actor.Name = Model.Name != default ? Model.Name : actor.Name;
            actor.Surname = Model.Surname !=default ? Model.Surname : actor.Surname;
            _context.SaveChanges();
        }
       
        
    }

    public class UpdateActorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
