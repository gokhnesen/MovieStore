using AutoMapper;
using MovieStore.DatabaseOperations;

namespace MovieStore.Operations.ActorOperations.GetActor
{
    public class GetActorQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ActorViewModel> Handle()
        {
            var actor = _context.Actors.OrderBy(x => x.Id).ToList();
            List<ActorViewModel> actorViewModel = _mapper.Map<List<ActorViewModel>>(actor); 
            return actorViewModel;
        }
    }

    public class ActorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
