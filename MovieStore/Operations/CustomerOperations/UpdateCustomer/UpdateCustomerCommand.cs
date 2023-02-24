using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.CustomerOperations.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int CustomerId { get; set; }
        public UpdateCustomerModel Model { get; set; }

        public UpdateCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;

        }
        public void Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == CustomerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadı");
            }
            customer.Name = Model.Name != default ? Model.Name : customer.Name;
            customer.Surname = Model.Surname != default ? Model.Surname : customer.Surname;
            customer.Email = Model.Email != default ? Model.Email : customer.Email;
            customer.Password = Model.Password != default ? Model.Password : customer.Password;
            customer.Order = Model.Order != default ? Model.Order : customer.Order;
            customer.FavoriteGenre = Model.FavoriteGenre != default ? Model.FavoriteGenre : customer.FavoriteGenre;
     

        }
    }

    public class UpdateCustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Order> Order { get; set; }
        public List<Genre> FavoriteGenre { get; set; }
    }
}

