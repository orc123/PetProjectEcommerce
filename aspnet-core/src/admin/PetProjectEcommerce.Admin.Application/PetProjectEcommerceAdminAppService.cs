using System;
using System.Collections.Generic;
using System.Text;
using PetProjectEcommerce.Localization;
using Volo.Abp.Application.Services;

namespace PetProjectEcommerce.Admin;

/* Inherit your application services from this class.
 */
public abstract class PetProjectEcommerceAdminAppService : ApplicationService
{
    protected PetProjectEcommerceAdminAppService()
    {
        LocalizationResource = typeof(PetProjectEcommerceResource);
    }
}
