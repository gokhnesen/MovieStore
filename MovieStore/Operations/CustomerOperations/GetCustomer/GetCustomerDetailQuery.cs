using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.CustomerOperations.GetCustomer
{
    public class GetCustomerDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int CustomerId { get; set; }

        public GetCustomerDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CustomerDetailViewModel Handle()
        {
            var customer = _context.Customers.Where(customer => customer.Id == CustomerId).FirstOrDefault();
            CustomerDetailViewModel customerViewModel = _mapper.Map<CustomerDetailViewModel>(customer);
            return customerViewModel;
        }
    }

    public class CustomerDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Order> Order { get; set; }
        public List<Genre> FavoriteGenre { get; set; }

    }
}

