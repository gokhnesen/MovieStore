using Microsoft.EntityFrameworkCore;
using MovieStore.DatabaseOperations;
using MovieStore.DatabaseOperations.Seed;
using AutoMapper;

namespace MovieStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MovieStoreDbContext>(optionsAction: options => options.UseInMemoryDatabase("MovieStoreDb"));
            builder.Services.AddScoped<IMovieStoreDbContext,MovieStoreDbContext>(provider => provider.GetService<MovieStoreDbContext>());
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();

            using(var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DataSeed.Initiliaze(serviceProiver: services);
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}