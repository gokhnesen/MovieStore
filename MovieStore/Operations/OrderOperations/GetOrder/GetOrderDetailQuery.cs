using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.OrderOperations.GetOrder
{
    public class GetOrderDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int OrderId { get; set; }

        public GetOrderDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OrderDetailViewModel Handle()
        {
            var order = _context.Orders.Where(order => order.Id == OrderId).FirstOrDefault();
            if (order is null)
            {
                throw new InvalidOperationException("Sipariş bulunamadı");
            }
            OrderDetailViewModel orderDetailViewModel = _mapper.Map<OrderDetailViewModel>(order);
            return orderDetailViewModel;
        }
    }

    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<Movie> Movie { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float TotalPrice { get; set; }
    }
}

