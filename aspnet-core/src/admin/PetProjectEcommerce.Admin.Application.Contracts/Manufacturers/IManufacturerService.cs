using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PetProjectEcommerce.Admin.Manufacturers;

public interface IManufacturerService
    : ICrudAppService<ManufacturerDto, Guid, PagedResultRequestDto, CreateUpdateManufacturer>
{
    Task<PagedResultDto<ManufacturerInListDto>> GetListFilterAsync(BaseListFilterDto input);
    Task<List<ManufacturerInListDto>> GetListAllAsync();
}
