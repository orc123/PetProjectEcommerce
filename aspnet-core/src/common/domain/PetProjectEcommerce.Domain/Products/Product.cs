using PetProjectEcommerce.Inventories;
using PetProjectEcommerce.Manufacturers;
using PetProjectEcommerce.Orders;
using PetProjectEcommerce.ProductCategories;
using PetProjectEcommerce.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace PetProjectEcommerce.Products;

public class Product : AuditedAggregateRoot<Guid>
{
    public Guid ManufacturerId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public ProductType ProductType { get; set; }
    public string SKU { get; set; }
    public string Slug { get; set; }
    public int SortOrder { get; set; }
    public bool Visibility { get; set; }
    public bool IsActive { get; set; }
    public Guid CategoryId { get; set; }
    public string SeoMetaDescription { get; set; }
    public string ThumbnailPicture { get; set; }
    public double SellPrice { get; set; }

    public virtual ProductCategory ProductCategory { get; set; }
    public virtual Manufacturer Manufacturer { get; set; }
    public virtual ICollection<Inventory> Inventories { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public virtual ICollection<ProductLink> ProductLinks { get; set; }
    public virtual ICollection<ProductAttributeDateTime> ProductAttributeDateTimes { get; set; }
    public virtual ICollection<ProductAttributeDecimal> ProductAttributeDecimals { get; set; }
    public virtual ICollection<ProductAttributeText> ProductAttributeTexts { get; set; }
    public virtual ICollection<ProductAttributeInt> ProductAttributeInts { get; set; }
    public virtual ICollection<ProductAttributeVarchar> ProductAttributeVarchars { get; set; }
    public virtual ICollection<ProductTag> ProductTags { get; set; }
    public virtual ICollection<ProductReview> ProductReviews { get; set; }
}
