using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
       
            private readonly IMovieStoreDbContext _context;
            private readonly IMapper _mapper;
            public CreateGenreModel Model { get; set; }
            public CreateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public void Handle()
            {
                var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
                if (genre is not null)
                {
                    throw new InvalidOperationException("Kitap türü mevcut");
                }
                genre = _mapper.Map<Genre>(Model);
                _context.Genres.Add(genre);
                _context.SaveChanges();
            }
    }

        public class CreateGenreModel
        {
            public string Name { get; set; }
        }
}
