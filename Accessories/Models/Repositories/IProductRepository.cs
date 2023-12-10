namespace Accessories.Models.Repositories
{
    public interface IProductRepository
    {
        IList<Product> GetAll();
        Product GetById(int id);
        void Add (Product product);
        void Update (Product product);
        void Delete (Product product);
        void Edit (Product product);

    }
}
