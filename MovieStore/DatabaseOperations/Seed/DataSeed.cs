using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DatabaseOperations.Seed
{
    public class DataSeed
    {
        public static void Initiliaze(IServiceProvider serviceProiver)
        {
            using (var context = new MovieStoreDbContext(serviceProiver.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Movies.AddRange(
                    new Movie { 
                        Name="Lord Of The Rings",
                        Actor= new List<Actor>(),
                        GenreId=1,
                        DirectorId=1,
                        Price=50,
                        PublishDate=new DateTime(2000,5,5)
                        
                    });

                context.Actors.AddRange(
                    new Actor
                    {
                      
                        Name = "Asdas",
                        Surname = "Fasdas",
                        
                        
                    });
                context.Genres.AddRange(
                    new Genre
                    {
                        Name="Sci-fi"
                    });
                context.Directors.AddRange(
                    new Director
                    {
                        Name="Brodirector",
                        Surname="BroSurname",
                        Movie=new List<Movie>()
                    });

                context.SaveChanges();
               
            }
        }
    }
}
