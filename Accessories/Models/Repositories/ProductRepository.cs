namespace Accessories.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly AppDbContext context;
        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Product product)
        {
            context.Accessories.Add(product);
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            Product product1 = context.Accessories.Find(product.Id);
            if (product != null)
            {
                context.Accessories.Remove(product1);
                context.SaveChanges();
            }
        }

        public void Edit(Product product)
        {
            Product product1 = context.Accessories.Find(product.Id);
            if(product1 != null)
            {
                product1.Name = product.Name;
                product1.Description = product.Description;
                product1.Price = product.Price;
                product1.Catid = product.Catid;
                product1.Photo = product.Photo;
                context.SaveChanges();
            }
        }

        public IList<Product> GetAll()
        {
            return context.Accessories.OrderBy(p => p.Name).ToList();
        }

        public Product GetById(int id)
        {
            return context.Accessories.Where(p => p.Id == id).SingleOrDefault();
        }

        public void Update(Product product)
        {
            Product existingProduct = context.Accessories.Find(product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Catid = product.Catid;
                existingProduct.Photo = product.Photo;

                context.SaveChanges();
            }
        }
    }
}
