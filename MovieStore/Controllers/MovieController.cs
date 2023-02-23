using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;
using MovieStore.Operations.MovieOperations.CreateMovie;
using MovieStore.Operations.MovieOperations.DeleteMovie;
using MovieStore.Operations.MovieOperations.GetMovie;
using MovieStore.Operations.MovieOperations.UpdateMovie;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMovieQuery query = new GetMovieQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{movieId}")]
        public IActionResult GetMovieById([FromRoute] int movieId)
        {
            MovieDetailViewModel result;


            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = movieId;
            GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);

        }

        [HttpPut("update/{movieId}")]
        public IActionResult UpdateMovie([FromBody] UpdateMovieModel request, int movieId)
        {


            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.MovieId = movieId;
            command.Model = request;
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();



            return Ok(request);


        }

        [HttpPost("add")]
        public IActionResult AddMovie([FromBody] CreateMovieModel request)
        {


            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model = request;
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok(request);
        }


        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {


            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = movieId;
            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();


            return Ok();
        }
    }
}
