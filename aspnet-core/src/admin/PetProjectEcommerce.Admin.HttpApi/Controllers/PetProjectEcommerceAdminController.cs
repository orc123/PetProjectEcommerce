using PetProjectEcommerce.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PetProjectEcommerce.Admin.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PetProjectEcommerceAdminController : AbpControllerBase
{
    protected PetProjectEcommerceAdminController()
    {
        LocalizationResource = typeof(PetProjectEcommerceResource);
    }
}
