using AutoMapper;
using MovieStore.DatabaseOperations;

namespace MovieStore.Operations.ActorOperations.GetActor
{
    public class GetActorDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int ActorId { get; set; }

        public GetActorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorDetailViewModel Handle()
        {
            var actor = _context.Actors.Where(actor => actor.Id == ActorId).FirstOrDefault();
            if(actor is null)
            {
                throw new InvalidOperationException("Aktör bulunamadı");
            }
            ActorDetailViewModel actorDetailViewModel = _mapper.Map<ActorDetailViewModel>(actor);
            return actorDetailViewModel;
        }
    }

    public class ActorDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
