using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;

namespace MovieStore.Operations.OrderOperations.UpdateOrder
{
    public class UpdateOrderCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int OrderId { get; set; }
        public UpdateOrderModel Model { get; set; }

        public UpdateOrderCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == OrderId);
            if (order is null)
            {
                throw new InvalidOperationException("Sipariş bulunamadı");
            }
            if (_context.Orders.Any(x => x.Id == OrderId))
            {
                throw new InvalidOperationException("Aynı sipariş mevcut");
            }

            order.CustomerId = Model.CustomerId != default ? Model.CustomerId : order.CustomerId;
            order.Movie = Model.Movie != default ? Model.Movie : order.Movie;
            order.PurchaseDate = Model.PurchaseDate != default ? Model.PurchaseDate : order.PurchaseDate;
            order.TotalPrice = Model.TotalPrice != default ? Model.TotalPrice : order.TotalPrice;

            _context.SaveChanges();
        }


    }

    public class UpdateOrderModel
    {
        public int CustomerId { get; set; }
        public List<Movie> Movie { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float TotalPrice { get; set; }

    }

}
