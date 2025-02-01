using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SalesBranch : BaseEntity
    {
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public Sale Sale { get; private set; }
    }
}
