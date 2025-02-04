using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid SaleId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public Status Status { get; set; }

        // EF Rel.
        public Sale Sale { get; set; }
        public Product Product { get; set; }

        public SaleItem(Guid productId, int quantity,
                        decimal price, string productImage = null)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        // EF ctor
        protected SaleItem() { }
    }
}
