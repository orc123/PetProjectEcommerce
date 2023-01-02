using PetProjectEcommerce.ProductCategories;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PetProjectEcommerce.Admin.ProductCategories;

public class ProductCategoryService :
    CrudAppService<
        ProductCategory, 
        ProductCategoryDto, 
        Guid, 
        PagedResultRequestDto, 
        CreateUpdateProductCategoryDto
    >,
    IProductCategoryService
{
    public ProductCategoryService(IRepository<ProductCategory, Guid> repository) 
        : base(repository)
    {
    }
}
