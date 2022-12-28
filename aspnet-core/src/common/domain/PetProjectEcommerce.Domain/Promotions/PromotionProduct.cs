using PetProjectEcommerce.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace PetProjectEcommerce.Promotions
{
    public class PromotionProduct : Entity<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }
        public virtual Product Product { get; set; }
    }
}
