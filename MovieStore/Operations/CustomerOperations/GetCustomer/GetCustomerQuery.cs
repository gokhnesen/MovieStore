using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.CustomerOperations.GetCustomer
{
    public class GetCustomerQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomerQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<CustomerViewModel> Handle()
        {
            var customerList = _context.Directors.OrderBy(x => x.Id).ToList();
            List<CustomerViewModel> customerViewModel = _mapper.Map<List<CustomerViewModel>>(customerList);
            return customerViewModel;
        }
    }

    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Order> Order { get; set; }
        public List<Genre> FavoriteGenre { get; set; }
    }
}

