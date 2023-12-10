namespace Accessories.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryPhoto { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
