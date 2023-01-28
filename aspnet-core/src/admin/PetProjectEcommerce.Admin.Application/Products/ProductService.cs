
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
    private readonly IProductRepository _productRepository;
    public ProductService(
        IProductRepository repository
    ) : base(repository)
    {
        _productRepository = repository;
    }

    public async Task<List<ProductIntListDto>> GetListAllAsync()
    {
        var data = (await _productRepository.GetQueryableAsync())
           .Where(x => x.IsActive)
           .Select(x => ObjectMapper.Map<Product, ProductIntListDto>(x))
           .ToList();
        return data;
    }

    public async Task<PagedResultDto<ProductIntListDto>> GetListFilterAsync(ProductListFilterDto input)
    {
        var (total, data) = await _productRepository.GetPagedProducts(
                input.CategoryId, input.Keyword, input.SkipCount, input.MaxResultCount);

        return new PagedResultDto<ProductIntListDto>(total, ObjectMapper.Map<List<Product>, List<ProductIntListDto>>(data));
    }

    public override Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
    {
        return base.CreateAsync(input);
    }

    public override Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
    {
        return base.UpdateAsync(id, input);
    }

}
