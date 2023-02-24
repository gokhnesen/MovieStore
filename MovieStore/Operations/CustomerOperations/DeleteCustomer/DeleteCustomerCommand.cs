using MovieStore.DatabaseOperations;

namespace MovieStore.Operations.CustomerOperations.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int CustomerId { get; set; }

        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customer = _context.Actors.SingleOrDefault(x => x.Id == CustomerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Silinecek müşteri bulunamadı");
            }
            _context.Actors.Remove(customer);
            _context.SaveChanges();
        }
    }
}
