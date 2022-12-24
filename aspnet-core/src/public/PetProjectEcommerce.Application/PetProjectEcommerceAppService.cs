using System;
using System.Collections.Generic;
using System.Text;
using PetProjectEcommerce.Localization;
using Volo.Abp.Application.Services;

namespace PetProjectEcommerce;

/* Inherit your application services from this class.
 */
public abstract class PetProjectEcommerceAppService : ApplicationService
{
    protected PetProjectEcommerceAppService()
    {
        LocalizationResource = typeof(PetProjectEcommerceResource);
    }
}
