using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PetProjectEcommerce.Admin.Products;

public interface IProductService :
    ICrudAppService<ProductDto, Guid, PagedResultRequestDto, CreateUpdateProductDto>
{
    Task<PagedResultDto<ProductIntListDto>> GetListFilterAsync(ProductListFilterDto input);
    Task<List<ProductIntListDto>> GetListAllAsync();
}
