﻿namespace Accessories.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}
