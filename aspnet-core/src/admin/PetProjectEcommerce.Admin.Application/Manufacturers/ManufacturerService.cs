
namespace PetProjectEcommerce.Admin.Manufacturers;

public class ManufacturerService :
    CrudAppService<
        Manufacturer,
        ManufacturerDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateManufacturer
    >,
    IManufacturerService

{
    public ManufacturerService(IRepository<Manufacturer, Guid> repository) : base(repository)
    {
    }

    public async Task<List<ManufacturerInListDto>> GetListAllAsync()
    {
        var query = (await Repository.GetQueryableAsync())
              .Where(x => x.IsActive);
        return ObjectMapper.Map<List<Manufacturer>, List<ManufacturerInListDto>>(query.ToList());
    }

    public async Task<PagedResultDto<ManufacturerInListDto>> GetListFilterAsync(BaseListFilterDto input)
    {
        var query = await Repository.GetQueryableAsync();

        query = query
            .WhereIf(!string.IsNullOrEmpty(input.Keyword), x => x.Name.Contains(input.Keyword));
        var total = query.Count();

        var data = query.Skip(input.SkipCount)
                 .Take(input.MaxResultCount)
                 .ToList();
        return new PagedResultDto<ManufacturerInListDto>(total, ObjectMapper.Map<List<Manufacturer>, List<ManufacturerInListDto>>(data));
    }
}
