using AutoMapper;
using MovieStore.Entities;
using MovieStore.Operations.ActorOperations.CreateActor;
using MovieStore.Operations.ActorOperations.GetActor;
using MovieStore.Operations.DirectorOperations.CreateDirector;
using MovieStore.Operations.DirectorOperations.GetDirector;
using MovieStore.Operations.MovieOperations.CreateMovie;
using MovieStore.Operations.MovieOperations.GetMovie;

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


        }
    }
}
