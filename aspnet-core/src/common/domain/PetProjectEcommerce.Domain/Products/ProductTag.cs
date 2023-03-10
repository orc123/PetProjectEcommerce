using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace PetProjectEcommerce.Products;

public class ProductTag : Entity
{
    public Guid ProductId { get; set; }
    public string TagId { get; set; }
    public override object[] GetKeys()
    {
        return new object[] { ProductId, TagId };
    }
    public virtual Product Product { get; set; }
    public virtual Tag Tag { get; set; }
}
