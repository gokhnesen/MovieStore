using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DatabaseOperations;
using MovieStore.Operations.DirectorOperations.CreateDirector;
using MovieStore.Operations.DirectorOperations.DeleteDirector;
using MovieStore.Operations.DirectorOperations.GetDirector;
using MovieStore.Operations.DirectorOperations.UpdateDirector;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorQuery query = new GetDirectorQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{directorId}")]
        public IActionResult GetDirectorById([FromRoute] int directorId)
        {
            DirectorDetailViewModel result;


            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
            query.DirectorId = directorId;
            GetDirectorQueryDetailValidator validator = new GetDirectorQueryDetailValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        [HttpPut("update/{directorId}")]
        public IActionResult UpdateDirector([FromBody] UpdateDirectorModel request, int directorId)
        {


            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.DirectorId = directorId;
            command.Model = request;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();



            return Ok(request);




        }

        [HttpPost("add")]
        public IActionResult AddDirector([FromBody] CreateDirectorModel request)
        {


            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = request;
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok(request);
        }

        [HttpDelete("{directorId}")]
        public async Task<IActionResult> DeleteDirector(int directorId)
        {


            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = directorId;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();




            return Ok();



        }
    }
}
