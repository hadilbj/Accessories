using Accessories.Models;
using Accessories.Models.Repositories;

namespace Products.Models.Repositories
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
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            Product product1 = context.Products.Find(product.Id);
            if (product != null)
            {
                context.Products.Remove(product1);
                context.SaveChanges();
            }
        }

        public void Edit(Product product)
        {
            Product product1 = context.Products.Find(product.Id);
            if(product1 != null)
            {
                product1.Name = product.Name;
                product1.Description = product.Description;
                product1.Price = product.Price;
                product1.categoryid = product.categoryid;
                product1.Photo = product.Photo;
                context.SaveChanges();
            }
        }

        public IList<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.Where(p => p.Id == id).SingleOrDefault();
        }

        public void Update(Product product)
        {
            Product existingProduct = context.Products.Find(product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.categoryid = product.categoryid;
                existingProduct.Photo = product.Photo;

                context.SaveChanges();
            }
        }
    }
}
