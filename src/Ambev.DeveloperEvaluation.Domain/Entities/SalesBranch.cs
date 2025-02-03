using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SalesBranch : BaseEntity
    {
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }
    }
}
