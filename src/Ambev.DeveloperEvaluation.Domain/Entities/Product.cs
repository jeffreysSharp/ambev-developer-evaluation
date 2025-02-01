using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }        
        public double Price { get; set; }        
        public string Image { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public SaleItem SaleItem { get; private set; }
    }
}
