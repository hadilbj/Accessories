namespace Accessories.Models.Repositories
{
    public interface ICategoryRepository
    {
        IList<Category> GetAll();
        Category GetById(int id);
        void Add (Category category);
        void Edit (Category category);
        void Delete (Category category);
    }
}
