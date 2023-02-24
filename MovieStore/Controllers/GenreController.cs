using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DatabaseOperations;
using MovieStore.Operations.GenreOperations.CreateGenre;
using MovieStore.Operations.GenreOperations.DeleteGenre;
using MovieStore.Operations.GenreOperations.GetGenre;
using MovieStore.Operations.GenreOperations.UpdateGenre;

using static MovieStore.Operations.GenreOperations.GetGenre.GetGenreDetailQuery;

namespace RestfullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;


        public GenreController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenre()
        {
            GetGenreQuery query = new GetGenreQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpGet("{genreId}")]
        public ActionResult GetGenreDetail([FromRoute] int genreId)
        {
            GenresDetailViewModel result;


            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = genreId;
            GetGenreDetailQueryValidiator validator = new GetGenreDetailQueryValidiator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel request)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = request;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int genreId, [FromBody] UpdateGenreModel request)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = genreId;
            command.Model = request;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int genreId)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = genreId;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
