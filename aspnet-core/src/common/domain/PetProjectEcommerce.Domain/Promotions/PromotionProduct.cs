using PetProjectEcommerce.Products;
using System;
using Volo.Abp.Domain.Entities;

namespace PetProjectEcommerce.Promotions
{
    public class PromotionProduct : Entity<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
