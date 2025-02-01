using Ambev.DeveloperEvaluation.Domain.Common;
using System.Diagnostics;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid SaleId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public string ProductImage { get; set; }

        // EF Rel.
        public Sale Sale { get; set; }
        public Product Product { get; set; }

        public SaleItem(Guid productId, string productName, int quantity,
                        decimal price, string productImage = null)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            ProductImage = productImage;
        }

        // EF ctor
        protected SaleItem() { }
    }
}
