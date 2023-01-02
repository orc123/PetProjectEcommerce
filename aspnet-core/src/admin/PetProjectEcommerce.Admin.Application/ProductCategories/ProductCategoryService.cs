using PetProjectEcommerce.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
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
    private readonly IRepository<ProductCategory, Guid> _productCategoryRepository;
    public ProductCategoryService(IRepository<ProductCategory, Guid> repository) 
        : base(repository)
    {
        _productCategoryRepository = repository;
    }

    public async Task<List<ProductCategoryIntListDto>> GetListAllAsync()
    {
        var query = (await _productCategoryRepository.GetQueryableAsync())
              .Where(x => x.IsActive);
        return ObjectMapper.Map<List<ProductCategory>, List<ProductCategoryIntListDto>>(query.ToList());
    }

    public async Task<PagedResultDto<ProductCategoryIntListDto>> GetListFilterAsync(BaseListFilterDto input)
    {
        var query = await _productCategoryRepository.GetQueryableAsync();

        query = query
            .WhereIf(!string.IsNullOrEmpty(input.Keyword), x => x.Name.Contains(input.Keyword));
        var total = query.Count();

        var data = query.Skip(input.SkipCount)
                 .Take(input.MaxResultCount)
                 .ToList();
        return new PagedResultDto<ProductCategoryIntListDto>(total, ObjectMapper.Map<List<ProductCategory>, List<ProductCategoryIntListDto>>(data));
    }
}
