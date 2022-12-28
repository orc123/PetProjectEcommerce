using PetProjectEcommerce.Orders;
using System;
using Volo.Abp.Domain.Entities;

namespace PetProjectEcommerce.Promotions
{
    public class PromotionUsageHistory : Entity<Guid>
    {
        public Guid PromotionId { get; set; }
        public Guid OrderId { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
