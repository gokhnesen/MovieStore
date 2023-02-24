using AutoMapper;
using MovieStore.DatabaseOperations;

namespace MovieStore.Operations.GenreOperations.GetGenre
{
    public class GetGenreDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }

        public GetGenreDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenresDetailViewModel Handle()
        {
            var genre = _context.Genres.Where(genre => genre.Id == GenreId).FirstOrDefault();
            if (genre is null)
            {
                throw new InvalidOperationException("tür bulunamadı");
            }
            GenresDetailViewModel vm = _mapper.Map<GenresDetailViewModel>(genre);

            return vm;
        }

        public class GenresDetailViewModel
        {
            public string Name { get; set; }
        }
    }
}
