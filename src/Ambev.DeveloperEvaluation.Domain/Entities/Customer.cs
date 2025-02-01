using Ambev.DeveloperEvaluation.Domain.Common;
using System.Net;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SocialNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public Sale Sale { get; set; }

    }
}
