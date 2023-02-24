using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.OrderOperations.CreateOrder
{
    public class CreateOrderCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateOrderModel Model { get; set; }

        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(x => x.CustomerId == Model.CustomerId);
            if (order is not null)
            {
                throw new InvalidOperationException("Sipariş mevcut");
            }

            order = _mapper.Map<Order>(Model);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }

    public class CreateOrderModel
    {
        public int CustomerId { get; set; }
        public List<Movie> Movie { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float TotalPrice { get; set; }

    }
}

