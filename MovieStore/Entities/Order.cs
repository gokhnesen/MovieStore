namespace MovieStore.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<Movie> Movie { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float Price { get; set; }
    }
}
