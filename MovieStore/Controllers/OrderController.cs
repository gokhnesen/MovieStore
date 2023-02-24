using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DatabaseOperations;
using MovieStore.Operations.ActorOperations.CreateActor;
using MovieStore.Operations.ActorOperations.DeleteActor;
using MovieStore.Operations.ActorOperations.GetActor;
using MovieStore.Operations.ActorOperations.UpdateActor;
using MovieStore.Operations.OrderOperations.CreateOrder;
using MovieStore.Operations.OrderOperations.DeleteOrder;
using MovieStore.Operations.OrderOperations.GetOrder;
using MovieStore.Operations.OrderOperations.UpdateOrder;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            GetOrderQuery query = new GetOrderQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById([FromRoute] int orderId)
        {
            OrderDetailViewModel result;
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            query.OrderId = orderId;
            GetOrderDetailQueryValidator validator = new GetOrderDetailQueryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        [HttpPut("update/{orderId}")]
        public IActionResult UpdateOrder([FromBody] UpdateOrderModel request, int orderId)
        {


            UpdateOrderCommand command = new UpdateOrderCommand(_context);
            command.OrderId = orderId;
            command.Model = request;
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();



            return Ok(request);
        }

        [HttpPost("add")]
        public IActionResult AddOrder([FromBody] CreateOrderModel request)
        {


            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = request;
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok(request);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {


            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.OrderId = orderId;
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();



        }
    }
}
