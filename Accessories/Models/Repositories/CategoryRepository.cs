using Microsoft.EntityFrameworkCore;

namespace Accessories.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly AppDbContext context;
        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void Delete(Category category)
        {
            Category category1 = context.Categories.Find(category.CategoryId);
            if (category1 != null)
            {
                context.Categories.Remove(category1);
                context.SaveChanges();
            }
        }

        public void Edit(Category category)
        {
            Category category1 = context.Categories.Find(category.CategoryId);
            if (category1 != null)
            {
                category1.CategoryName = category.CategoryName;
                category1.CategoryDescription = category.CategoryDescription;
                context.SaveChanges();
            }
        }

        public IList<Category> GetAll()
        {
            return context.Categories.OrderBy(c => c.CategoryName).ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.Where(c => c.CategoryId == id).SingleOrDefault();
        }
    }
}
