using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System.Text.Json.Serialization;

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
        public DateTime? UpdatedAt { get; set; }
        public Status Status { get; set; }
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        
        // EF Rel.
        [JsonIgnore]
        public Sale? Sale { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }

        public SaleItem() { }

        public SaleItem(int quantity, double price, double totalSaleItemAmount, double discount, 
            double totalPriceDiscount, DateTime createdAt, DateTime? updatedAt, Status status, 
            Guid productId, Guid saleId)
        {
            Quantity = quantity;
            Price = price;
            TotalSaleItemAmount = totalSaleItemAmount;
            Discount = discount;
            TotalPriceDiscount = totalPriceDiscount;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Status = status;
            ProductId = productId;
            SaleId = saleId;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleItemValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void Activate()
        {
            Status = Status.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            Status = Status.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Suspend()
        {
            Status = Status.Suspended;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
