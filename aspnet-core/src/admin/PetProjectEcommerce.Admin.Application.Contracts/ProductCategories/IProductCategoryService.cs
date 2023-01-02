using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PetProjectEcommerce.Admin.ProductCategories;

public interface IProductCategoryService :
    ICrudAppService<ProductCategoryDto, Guid, PagedResultRequestDto, CreateUpdateProductCategoryDto>
{
    Task<PagedResultDto<ProductCategoryIntListDto>> GetListFilterAsync(BaseListFilterDto input);
    Task<List<ProductCategoryIntListDto>> GetListAllAsync();

}
