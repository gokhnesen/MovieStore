using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.OrderOperations.GetOrder
{
    public class GetOrderQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OrderViewModel> Handle()
        {
            var order = _context.Orders.OrderBy(x => x.Id).ToList();
            List<OrderViewModel> orderViewModel = _mapper.Map<List<OrderViewModel>>(order);
            return orderViewModel;
        }
    }

    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<Movie> Movie { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float TotalPrice { get; set; }
    }
}

