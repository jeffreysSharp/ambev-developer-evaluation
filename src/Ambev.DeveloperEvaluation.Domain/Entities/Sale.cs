using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int SaleNumber { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SalesBrancheId { get; set; }

        private readonly List<SaleItem> _saleItems;
        public IReadOnlyCollection<SaleItem> SaleItems => _saleItems;

        // EF Rel.
        public Customer Customer { get; private set; }
        public SalesBranch SalesBranche { get; private set; }
    }
}
