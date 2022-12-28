using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace PetProjectEcommerce.Promotions
{
    public class Promotion : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string CouponCode { get; set; }
        public bool RequireUseCouponCode { get; set; }
        public DateTime ValidDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public double DiscountAmount { get; set; }
        public DiscountUnit DiscountUnit { get; set; }
        public bool LimitedUsageTimes { get; set; }
        public uint MaximumDiscountAmount { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<PromotionCategory> PromotionCategories { get; set; }
        public virtual ICollection<PromotionManufacturer> PromotionManufacturers { get; set; }
        public virtual ICollection<PromotionProduct> PromotionProducts { get; set; }
        public virtual ICollection<PromotionUsageHistory> PromotionUsageHistories { get; set; }
    }
}
