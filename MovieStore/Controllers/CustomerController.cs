using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DatabaseOperations;
using MovieStore.Operations.CustomerOperations.CreateCustomer;
using MovieStore.Operations.CustomerOperations.CreateToken;
using MovieStore.Operations.CustomerOperations.DeleteCustomer;
using MovieStore.Operations.CustomerOperations.GetCustomer;
using MovieStore.Operations.CustomerOperations.RefreshToken;
using MovieStore.Operations.CustomerOperations.UpdateCustomer;
using MovieStore.Operations.DirectorOperations.CreateDirector;
using MovieStore.Operations.DirectorOperations.DeleteDirector;
using MovieStore.Operations.DirectorOperations.GetDirector;
using MovieStore.Operations.DirectorOperations.UpdateDirector;
using MovieStore.TokenOperations;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public CustomerController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = newCustomer;
            command.Handle();

            return Ok(command);
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper,_configuration);
            command.Model=login;
            var token = command.Handle();
            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _mapper, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            GetCustomerQuery query = new GetCustomerQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public IActionResult GetCustomerById([FromRoute] int customerId)
        {
            CustomerDetailViewModel result;


            GetCustomerDetailQuery query = new GetCustomerDetailQuery(_context, _mapper);
            query.CustomerId = customerId;
            GetCustomerDetailQueryValidator validator = new GetCustomerDetailQueryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        [HttpPut("update/{customerId}")]
        public IActionResult UpdateCustomer([FromBody] UpdateCustomerModel request, int customerId)
        {


            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
            command.CustomerId = customerId;
            command.Model = request;
            UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();



            return Ok(request);




        }

        [HttpPost("add")]
        public IActionResult AddCustomer([FromBody] CreateCustomerModel request)
        {


            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = request;
            CreateCustomerValidator validator = new CreateCustomerValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok(request);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {


            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = customerId;
            DeleteCustomerValidator validator = new DeleteCustomerValidator();
            validator.ValidateAndThrow(command);
            command.Handle();




            return Ok();



        }
    }
}
