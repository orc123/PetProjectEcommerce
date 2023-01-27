using PetProjectEcommerce.ProductAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace PetProjectEcommerce.Products;

public class ProductAttributeDecimal : Entity<Guid>
{
    public Guid AttributeId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Value { get; set; }
    public virtual ProductAttribute ProductAttribute { get; set; }
    public virtual Product Product { get; set; }
}
