using System.ComponentModel.DataAnnotations.Schema;

namespace Accessories.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int categoryid { get; set; }
        [ForeignKey("categoryid")]
        public Category category
        {
            get; set;
        }
    }
}
