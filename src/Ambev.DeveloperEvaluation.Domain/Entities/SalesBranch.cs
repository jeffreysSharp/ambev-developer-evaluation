using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SalesBranch : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Status Status { get; set; }
        public SalesBranch() { }
        public SalesBranch(DateTime createdAt)
        {
            CreatedAt = DateTime.UtcNow;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SalesBranchValidator();
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
