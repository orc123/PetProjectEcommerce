using PetProjectEcommerce.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace PetProjectEcommerce.ProductAttributes
{
    public class ProductAttribute : CreationAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public AttributeType DataType { get; set; }
        public string Label { get; set; }
        public int SortOrder { get; set; }
        public bool Visibility { get; set; }
        public bool IsActive { get; set; }
        public bool IsRequired { get; set; }
        public bool IsUnique { get; set; }
        public string Note { get; set; }
        public virtual ICollection<ProductAttributeDateTime> ProductAttributeDateTimes { get; set; }
        public virtual ICollection<ProductAttributeDecimal> ProductAttributeDecimals { get; set; }
        public virtual ICollection<ProductAttributeText> ProductAttributeTexts { get; set; }
        public virtual ICollection<ProductAttributeInt> ProductAttributeInts { get; set; }
        public virtual ICollection<ProductAttributeVarchar> ProductAttributeVarchars { get; set; }
    }
}
