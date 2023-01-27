using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PetProjectEcommerce.Admin.Manufacturers;

public class ManufacturerInListDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
}
