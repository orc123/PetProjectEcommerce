using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace PetProjectEcommerce.Orders
{
    public class OrderTransaction : CreationAuditedEntity<Guid>
    {
        public string Code { get; set; }
        public Guid OrderId { get; set; }
        public Guid? UserId { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Note { get; set; }
        public virtual Order Order { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
