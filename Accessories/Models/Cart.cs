namespace Accessories.Models
{
    public class Cart
    {
        public Cart() { }

        public Cart(Product product)
        {
            // Initialiser les propriétés de Cart à partir de product
            Id = product.Id;
            // Autres initialisations...
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}
