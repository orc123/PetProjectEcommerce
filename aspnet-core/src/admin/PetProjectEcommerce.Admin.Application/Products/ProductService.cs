using PetProjectEcommerce.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PetProjectEcommerce.Admin.Products;

public class ProductService :
    CrudAppService<
        Product,
        ProductDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateProductDto
    >,
    IProductService
{
    private readonly IRepository<Product, Guid> _productRepository;
    public ProductService(IRepository<Product, Guid> repository) : base(repository)
    {
        _productRepository = repository;
    }

    public async Task<List<ProductIntListDto>> GetListAllAsync()
    {
        var query = (await _productRepository.GetQueryableAsync())
           .Where(x => x.IsActive);
        return ObjectMapper.Map<List<Product>, List<ProductIntListDto>>(query.ToList());
    }

    public async Task<PagedResultDto<ProductIntListDto>> GetListFilterAsync(ProductListFilterDto input)
    {
        var query = await _productRepository.GetQueryableAsync();

        query = query
            .WhereIf(!string.IsNullOrEmpty(input.Keyword), x => x.Name.Contains(input.Keyword))
            .WhereIf(input.CategoryId.HasValue, x => x.CategoryId == input.CategoryId.Value);
        var total = query.Count();

        var data = query.Skip(input.SkipCount)
                 .Take(input.MaxResultCount)
                 .ToList();
        return new PagedResultDto<ProductIntListDto>(total, ObjectMapper.Map<List<Product>, List<ProductIntListDto>>(data));
    }
}
