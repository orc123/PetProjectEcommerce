using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace PetProjectEcommerce.Products
{
    public class ProductReview : CreationAuditedAggregateRoot<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid? ParentId { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Content { get; set; }
        public Guid OrderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductReview ProductReviewParent { get; set; }
        public virtual ICollection<ProductReview> ProductReviewChilds { get; set; }
    }
}
