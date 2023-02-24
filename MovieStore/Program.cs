using Microsoft.EntityFrameworkCore;
using MovieStore.DatabaseOperations;
using MovieStore.DatabaseOperations.Seed;
using AutoMapper;
using MovieStore.Middlewares;
using Microsoft.AspNetCore.HttpLogging;
using MovieStore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MovieStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MovieStoreDbContext>(optionsAction: options => options.UseInMemoryDatabase("MovieStoreDb"));
            builder.Services.AddScoped<IMovieStoreDbContext,MovieStoreDbContext>(provider => provider.GetService<MovieStoreDbContext>());
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Token:Issuer"],
                    ValidAudience = builder.Configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();  
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var serviceProvider = builder.Services.BuildServiceProvider();
            builder.Services.AddHttpLogging(httpLogging =>
            {
                httpLogging.LoggingFields = HttpLoggingFields.All;
            });
            builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();
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
            app.UseAuthentication();
            app.UseHttpLogging();
         
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCustomExceptionMiddle();

            app.MapControllers();

            app.Run();
        }
    }
}