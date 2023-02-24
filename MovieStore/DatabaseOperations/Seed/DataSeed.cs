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
                      
                        Name = "Orlando",
                        Surname = "Bloom",
                        
                        
                    },
                    new Actor
                    {

                        Name = "Sean",
                        Surname = "Bean",


                    }
                    );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name="Science Fiction"
                    });
                context.Directors.AddRange(
                    new Director
                    {
                        Name="Peter",
                        Surname="Jackson",
                    });
                context.Orders.AddRange(
                    new Order
                    {
                        CustomerId=1,
                        Movie=new List<Movie>(),
                     
                        TotalPrice=100,
                        PurchaseDate=DateTime.Now
                    });
                context.Customers.AddRange(
                    new Customer
                    {
                        Name= "Gökhan",
                        Surname="Esen",
                        Email="test",
                        Password="test",
                        FavoriteGenre=new List<Genre>(),
                        Order=new List<Order>(),
                    });

                context.SaveChanges();
               
            }
        }
    }
}
