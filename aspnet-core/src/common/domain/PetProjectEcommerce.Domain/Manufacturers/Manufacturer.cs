using PetProjectEcommerce.Products;
using PetProjectEcommerce.Promotions;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace PetProjectEcommerce.Manufacturers
{
    public class Manufacturer : CreationAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Slug { get; set; }
        public string CoverPicture { get; set; }
        public bool Visibility { get; set; }
        public bool IsActive { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<PromotionManufacturer> PromotionManufacturers { get; set; }
    }
}
