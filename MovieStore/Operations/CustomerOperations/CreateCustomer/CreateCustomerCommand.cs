using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.CustomerOperations.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Email == Model.Email);
            if (customer != null)
            {
                throw new InvalidOperationException("Müşteri mevcut");
            }

            customer = _mapper.Map<Customer>(Model);
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }

    public class CreateCustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public List<Order> Order { get; set; }
        //public List<Genre> FavoriteGenres { get; set; }

    }
}
