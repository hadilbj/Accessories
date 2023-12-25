namespace Accessories.Models.Repositories
{
    public interface ICartRepository
    {
        IList<Cart> GetAll();
        void Add(Cart cart);
        void Edit (Cart cart);
        void Delete(Cart cart);
        void Update(Cart cart);
        Cart GetCartItemById(int cartItemId);
    }
}
