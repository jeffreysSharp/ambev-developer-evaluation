using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }        
        public string Image { get; set; } = string.Empty;
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Status Status { get; set; }
        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public Product() { }
        public Product(DateTime createdAt)
        {
            CreatedAt = DateTime.UtcNow;
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
