using MovieStore.DatabaseOperations;

namespace MovieStore.Operations.OrderOperations.DeleteOrder
{
    public class DeleteOrderCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int OrderId { get; set; }

        public DeleteOrderCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == OrderId);
            if (order == null)
            {
                throw new InvalidOperationException("Silinecek sipariş bulunamadı");
            }
            if (_context.Customers.Any(x => x.Id == OrderId))
            {
                throw new InvalidOperationException("Müşterinin siparişi mevcut");
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
