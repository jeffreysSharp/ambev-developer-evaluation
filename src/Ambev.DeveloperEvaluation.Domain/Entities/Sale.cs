using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int SaleNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Status Status { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SalesBrancheId { get; set; }
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

        // EF Rel.
        public Customer Customer { get; set; }
        public SalesBranch SalesBranche { get; set; }
        public Sale() { }
        public Sale(int saleNumber, double totalSaleAmount, DateTime createdAt, DateTime? updatedAt, Status status, Guid customerId, Guid salesBrancheId, List<SaleItem> saleItems, Customer customer, SalesBranch salesBranche)
        {
            SaleNumber = saleNumber;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Status = Status.Active;
            CustomerId = customerId;
            SalesBrancheId = salesBrancheId;
            SaleItems = saleItems;
            Customer = customer;
            SalesBranche = salesBranche;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
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
