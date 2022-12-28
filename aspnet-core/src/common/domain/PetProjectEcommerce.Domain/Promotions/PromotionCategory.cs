using System;
using Volo.Abp.Domain.Entities;

namespace PetProjectEcommerce.Promotions
{
    public class PromotionCategory : Entity<Guid>
    {
        public Guid CategoryId { get; set; }
        public Guid PromotionId { get; set; }

        public virtual Promotion Promotion { get; set; }

    }
}
