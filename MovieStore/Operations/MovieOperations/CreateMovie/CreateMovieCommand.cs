using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.MovieOperations.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateMovieCommand(IMovieStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Name.ToLower() == Model.Name);
            if(movie != null)
            {
                throw new InvalidOperationException("Film mevcut");
            }

            movie = _mapper.Map<Movie>(Model);
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }

    public class CreateMovieModel
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public List<Actor> Actor { get; set; }
        public float Price { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
