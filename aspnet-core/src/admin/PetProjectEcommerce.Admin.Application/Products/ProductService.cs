using System.Text.RegularExpressions;
using Volo.Abp;
using Volo.Abp.BlobStoring;

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
    private readonly ProductManager _productManager;
    private readonly IBlobContainer<ProductThumbnailPictureContainer> _fileContainer;
    public ProductService(
        IProductRepository repository,
        ProductManager productManager,
        IBlobContainer<ProductThumbnailPictureContainer> fileContainer
    ) : base(repository)
    {
        _productRepository = repository;
        _productManager = productManager;
        _fileContainer = fileContainer;
    }

    public async Task<List<ProductIntListDto>> GetListAllAsync()
    {
        var data = await _productRepository.GetProducts();
        return ObjectMapper.Map<List<Product>, List<ProductIntListDto>>(data);
    }

    public async Task<PagedResultDto<ProductIntListDto>> GetListFilterAsync(ProductListFilterDto input)
    {
        var (total, data) = await _productRepository.GetPagedProducts(
                input.CategoryId, input.Keyword, input.SkipCount, input.MaxResultCount);

        return new PagedResultDto<ProductIntListDto>(total, ObjectMapper.Map<List<Product>, List<ProductIntListDto>>(data));
    }

    public override async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
    {
        var product = await _productManager.CreateAsync(Guid.NewGuid(), input.ManufacturerId, input.Name, input.Code,
            input.Description, input.ProductType, input.SKU, input.Slug, input.SortOrder, input.Visibility, input.IsActive,
            input.CategoryId, input.SeoMetaDescription, "", input.SellPrice);

        if (input.ThumbnailPictureContent != null && input.ThumbnailPictureContent.Length > 0)
        {
            await SaveThumbnailImageAsync(input.ThumbnailPictureName, input.ThumbnailPictureContent);
            product.ThumbnailPicture = input.ThumbnailPictureName;
        }

        var result = await _productRepository.InsertAsync(product);
        return ObjectMapper.Map<Product, ProductDto>(result);
    }

    public override async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
    {
        var product = await _productRepository.GetAsync(id);
        if (product == null)
        {
            throw new UserFriendlyException("Sản phẩm với mã này không tồn tại", PetProjectEcommerceDomainErrorCodes.ProductSKUAlreadyExists);
        }
        var productNameExit = await _productRepository.AnyAsync(x => x.Id != id && x.Name == input.Name);
        if (productNameExit)
        {
            throw new UserFriendlyException("Tên sản phẩm đã tồn tại", PetProjectEcommerceDomainErrorCodes.ProductNameAlreadyExists);
        }

        var productCodeExit = await _productRepository.AnyAsync(x => x.Id != id && x.Code == input.Code);
        if (productCodeExit)
        {
            throw new UserFriendlyException("Mã sản phẩm đã tồn tại", PetProjectEcommerceDomainErrorCodes.ProductCodeAlreadyExists);
        }

        var productSKUExit = await _productRepository.AnyAsync(x => x.Id != id && x.SKU == input.SKU);
        if (productSKUExit)
        {
            throw new UserFriendlyException("Mã SKU đã tồn tại", PetProjectEcommerceDomainErrorCodes.ProductSKUAlreadyExists);
        }
        product.ManufacturerId = input.ManufacturerId;
        product.Name = input.Name;
        product.Code = input.Code;
        product.Slug = input.Slug;
        product.ProductType = input.ProductType;
        product.SKU = input.SKU;
        product.SortOrder = input.SortOrder;
        product.Visibility = input.Visibility;
        product.IsActive = input.IsActive;
        product.SeoMetaDescription = input.SeoMetaDescription;
        product.Description = input.Description;
        if (input.ThumbnailPictureContent != null && input.ThumbnailPictureContent.Length > 0)
        {
            await SaveThumbnailImageAsync(input.ThumbnailPictureName, input.ThumbnailPictureContent);
            product.ThumbnailPicture = input.ThumbnailPictureName;
        }
        product.SellPrice = input.SellPrice;
        await Repository.UpdateAsync(product);

        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    private async Task SaveThumbnailImageAsync(string fileName, string base64)
    {
        Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
        base64 = regex.Replace(base64, string.Empty);
        byte[] bytes = Convert.FromBase64String(base64);
        await _fileContainer.SaveAsync(fileName, bytes, overrideExisting: true);
    }

}
