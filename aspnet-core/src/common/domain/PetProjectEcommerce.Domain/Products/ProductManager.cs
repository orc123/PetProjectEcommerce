using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace PetProjectEcommerce.Products;

public class ProductManager : DomainService
{
	private readonly IProductRepository _productRepository;
	public ProductManager(IProductRepository productRepository)
	{
		_productRepository = productRepository;
	}

	public async Task<Product> CreateAsync(
        Guid id,
        Guid manufacturerId,
        string name,
        string code,
        string description,
        ProductType productType,
        string sKU,
        string slug,
        int sortOrder,
        bool visibility,
        bool isActive,
        Guid categoryId,
        string seoMetaDescription,
        string thumbnailPicture,
        double sellPrice
    )
	{
        var productNameExit = await _productRepository.AnyAsync(x => x.Name == name);
        if (productNameExit)
        {
            throw new UserFriendlyException("Tên sản phẩm đã tồn tại", PetProjectEcommerceDomainErrorCodes.ProductNameAlreadyExists);
        }

        var productCodeExit = await _productRepository.AnyAsync(x => x.Code == code);
        if (productCodeExit)
        {
            throw new UserFriendlyException("Mã sản phẩm đã tồn tại", PetProjectEcommerceDomainErrorCodes.ProductCodeAlreadyExists);
        }

        var productSKUExit = await _productRepository.AnyAsync(x => x.SKU == sKU);
        if (productSKUExit)
        {
            throw new UserFriendlyException("Mã SKU đã tồn tại", PetProjectEcommerceDomainErrorCodes.ProductSKUAlreadyExists);
        }

        return new Product(id, manufacturerId, name, code, description, productType, sKU,
            slug, sortOrder, visibility, isActive, categoryId, seoMetaDescription, thumbnailPicture, sellPrice);
	}
}
