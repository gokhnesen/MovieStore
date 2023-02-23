using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.MovieOperations.GetMovie
{
    public class GetMovieQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MovieViewModel> Handle()
        {
            var movieList = _context.Movies.Include(x => x.Genre).Include(x => x.Actor).Include(x => x.Director).OrderBy(x => x.Id).ToList();
            List<MovieViewModel> movieViewModel = _mapper.Map<List<MovieViewModel>>(movieList);
            return movieViewModel;
        }
    }

    public class MovieViewModel
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public List<Actor> Actor { get; set; }
        public float Price { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
