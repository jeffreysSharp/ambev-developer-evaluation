using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalSaleItemAmount { get; set; }
        public decimal Dicount { get; set; }
        public decimal TotalPriceDiscount { get; set; }
        public Status Status { get; set; }
        public Guid ProductId { get; set; }
        public Guid SaleId { get; set; }


        // EF Rel.
        public Sale Sale { get; set; }
        public Product Product { get; set; }

        public SaleItem(int quantity, decimal price, decimal totalSaleItemAmount, decimal dicount,
            decimal totalPriceDiscount, Status status, Guid productId, Guid saleId, Sale sale, Product product)
        {
            Quantity = quantity;
            Price = price;
            TotalSaleItemAmount = totalSaleItemAmount;
            Dicount = dicount;
            TotalPriceDiscount = totalPriceDiscount;
            Status = status;
            ProductId = productId;
            SaleId = saleId;
            Sale = sale;
            Product = product;
        }

        // EF ctor
        protected SaleItem() { }
    }
}
