using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.MovieOperations.GetMovie
{
    public class GetMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int MovieId { get; set; }

        public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
          
        }

        public MovieDetailViewModel Handle()
        {
            var movie = _context.Movies.Include(x => x.Genre).Include(x => x.Director).Include(x => x.Actor).Where(movie => movie.Id == MovieId).FirstOrDefault();
            if(movie == null)
            {
                throw new InvalidOperationException("Film bulunamadı");
            }
            MovieDetailViewModel viewModel = _mapper.Map<MovieDetailViewModel>(movie);
            return viewModel;

        }
    }

    public class MovieDetailViewModel
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public List<Actor> Actor { get; set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }

    }
}
