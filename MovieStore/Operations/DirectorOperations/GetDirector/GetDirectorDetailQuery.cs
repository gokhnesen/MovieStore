using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.DirectorOperations.GetDirector
{
    public class GetDirectorDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int DirectorId { get; set; }

        public GetDirectorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DirectorDetailViewModel Handle()
        {
            var director = _context.Directors.Include(x => x.Movie).Where(director => director.Id == DirectorId).FirstOrDefault();
            DirectorDetailViewModel directorViewModel = _mapper.Map<DirectorDetailViewModel>(director);
            return directorViewModel;
        }
    }

    public class DirectorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Movies { get; set; }

    }
}
