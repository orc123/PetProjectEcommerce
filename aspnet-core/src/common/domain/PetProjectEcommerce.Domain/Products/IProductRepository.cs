using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Repositories;

namespace PetProjectEcommerce.Products;

public interface IProductRepository : IRepository<Product, Guid>
{
    Task<List<Product>> GetProducts();
    Task<(int, List<Product>)> GetPagedProducts(Guid? categoryId, string keyword, int skipCount, int maxResultCount);
}
