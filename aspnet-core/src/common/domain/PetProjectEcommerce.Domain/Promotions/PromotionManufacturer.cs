using System;
using Volo.Abp.Domain.Entities;

namespace PetProjectEcommerce.Promotions
{
    public class PromotionManufacturer : Entity<Guid>
    {
        public Guid ManufactureId { get; set; }
        public Guid PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
