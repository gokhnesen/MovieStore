using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DatabaseOperations;
using MovieStore.Operations.ActorOperations.CreateActor;
using MovieStore.Operations.ActorOperations.DeleteActor;
using MovieStore.Operations.ActorOperations.GetActor;
using MovieStore.Operations.ActorOperations.UpdateActor;

namespace MovieStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorQuery query = new GetActorQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{actorId}")]
        public IActionResult GetActorById([FromRoute] int actorId)
        {
            ActorDetailViewModel result;
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            query.ActorId = actorId;
            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        [HttpPut("update/{actorId}")]
        public IActionResult UpdateActor([FromBody] UpdateActorModel request, int actorId)
        {


            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.ActorId = actorId;
            command.Model = request;
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();



            return Ok(request);
        }

        [HttpPost("add")]
        public IActionResult AddActor([FromBody] CreateActorModel request)
        {


            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = request;
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok(request);
        }

        [HttpDelete("{actorId}")]
        public async Task<IActionResult> DeleteActor(int actorId)
        {


            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = actorId;
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();



        }
    }
}
