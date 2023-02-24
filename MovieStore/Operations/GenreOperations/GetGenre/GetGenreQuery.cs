using AutoMapper;
using MovieStore.DatabaseOperations;

namespace MovieStore.Operations.GenreOperations.GetGenre
{
    public class GetGenreQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenresViewModel> genresViewModel = _mapper.Map<List<GenresViewModel>>(genres);

            return genresViewModel;
        }
    }


    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

