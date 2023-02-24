using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.DirectorOperations.GetDirector
{
    public class GetDirectorQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorQuery(IMovieStoreDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<DirectorsViewModel> Handle()
        {
            var directorList = _context.Directors.OrderBy(x => x.Id).ToList();
            List<DirectorsViewModel> directorsViewModel = _mapper.Map<List<DirectorsViewModel>>(directorList);
            return directorsViewModel;
        }
    }

    public class DirectorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
