using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalSaleItemAmount { get; set; }
        public double Discount { get; set; }
        public double TotalPriceDiscount { get; set; }
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }
        public Guid ProductId { get; set; }
        public Guid SaleId { get; set; }

        // EF Rel.
        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }
}
