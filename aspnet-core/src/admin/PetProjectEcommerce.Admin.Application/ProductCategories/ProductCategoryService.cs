using System.Linq.Dynamic.Core;

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

    public async Task<List<ProductCategoryIntListDto>> GetListAllAsync()
    {
        var query = (await Repository.GetQueryableAsync())
              .Where(x => x.IsActive);
        return ObjectMapper.Map<List<ProductCategory>, List<ProductCategoryIntListDto>>(query.ToList());
    }

    public async Task<PagedResultDto<ProductCategoryIntListDto>> GetListFilterAsync(BaseListFilterDto input)
    {
        var query = await Repository.GetQueryableAsync();

        query = query
            .WhereIf(!string.IsNullOrEmpty(input.Keyword), x => x.Name.Contains(input.Keyword));
        var total = query.Count();

        var data = query.Skip(input.SkipCount)
                 .Take(input.MaxResultCount)
                 .ToList();
        return new PagedResultDto<ProductCategoryIntListDto>(total, ObjectMapper.Map<List<ProductCategory>, List<ProductCategoryIntListDto>>(data));
    }
}
