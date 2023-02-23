using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.DirectorOperations.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int DirectorId { get; set; }
        public UpdateDirectorModel Model { get; set; }

        public UpdateDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
     
        }
        public void Handle()
        {
            var director = _context.Directors.FirstOrDefault(x => x.Id == DirectorId);
            if(director == null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadı");
            }
            director.Name = Model.Name != default ? Model.Name : director.Name;
            director.Surname=Model.Surname != default ? Model.Surname : director.Surname;
            director.Movie = Model.Movies != default ? Model.Movies : director.Movie;
        }
    }

    public class UpdateDirectorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
