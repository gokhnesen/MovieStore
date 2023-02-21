using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DatabaseOperations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Actor> Actors { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Customer> Customers { get; set; }

        int SaveChanges();
    }
}
