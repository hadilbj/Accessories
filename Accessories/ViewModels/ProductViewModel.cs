namespace Accessories.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public IFormFile Photo { get; set; }
        public string Description { get; set; }
       
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int categoryid { get; set; }
    }
}
