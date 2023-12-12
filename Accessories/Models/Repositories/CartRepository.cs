namespace Accessories.Models.Repositories
{
    public class CartRepository : ICartRepository
    {
        readonly AppDbContext context;
        public CartRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }

        public void Delete(Cart cart)
        {
            Cart cart1 = context.Carts.Find(cart.Id);
            if (cart1 != null)
            {
                context.Carts.Remove(cart1);
                context.SaveChanges();
            }
        }

        public void Edit(Cart cart)
        {
            Cart cart1 = context.Carts.Find(cart.Id);
            if (cart1 != null)
            {
                cart1.UserId = cart.UserId;
                cart1.ProductId = cart.ProductId;
                cart1.Quantity = cart.Quantity;
                context.SaveChanges();
            }
        }

        public IList<Cart> GetAll()
        {
            return context.Carts.OrderBy(c => c.UserId).ToList();
        }

        public void Update(Cart cart)
        {
            Cart existingProduct = context.Carts.Find(cart.Id);

            if (existingProduct != null)
            {
                existingProduct.UserId = cart.UserId;
                existingProduct.ProductId = cart.ProductId;
                existingProduct.Quantity = cart.Quantity;

                context.SaveChanges();
            }
        }
    }
}
