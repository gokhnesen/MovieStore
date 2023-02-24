using AutoMapper;
using MovieStore.Entities;
using MovieStore.Operations.ActorOperations.CreateActor;
using MovieStore.Operations.ActorOperations.GetActor;
using MovieStore.Operations.CustomerOperations.CreateCustomer;
using MovieStore.Operations.DirectorOperations.CreateDirector;
using MovieStore.Operations.DirectorOperations.GetDirector;
using MovieStore.Operations.GenreOperations.CreateGenre;
using MovieStore.Operations.GenreOperations.GetGenre;
using MovieStore.Operations.MovieOperations.CreateMovie;
using MovieStore.Operations.MovieOperations.GetMovie;
using MovieStore.Operations.OrderOperations.CreateOrder;
using MovieStore.Operations.OrderOperations.GetOrder;
using static MovieStore.Operations.GenreOperations.GetGenre.GetGenreDetailQuery;

namespace MovieStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateActorModel, Actor>();
            CreateMap<Actor, ActorDetailViewModel>();
            CreateMap<Actor, ActorViewModel>();
            
            CreateMap<CreateDirectorModel, Director>();
            CreateMap<Director, DirectorsViewModel>();
            CreateMap<Director, DirectorDetailViewModel>();

            CreateMap<CreateMovieModel, Movie>();
            CreateMap<Movie, MovieViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                                              .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
                                              .ForMember(dest => dest.Actor, opt => opt.MapFrom(src => src.Actor));
            
            CreateMap<Movie, MovieDetailViewModel>()
                                              .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                                              .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
                                              .ForMember(dest => dest.Actor, opt => opt.MapFrom(src => src.Actor));

            CreateMap<CreateGenreModel, Genre>();
            CreateMap<Genre, GenresDetailViewModel>();
            CreateMap<Genre, GenresViewModel>();

            CreateMap<CreateCustomerModel, Customer>();


            CreateMap<CreateOrderModel,Order>();
            CreateMap<Order, OrderDetailViewModel>();
            CreateMap<Order, OrderViewModel>();
        }
    }
}
