using PetProjectEcommerce.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PetProjectEcommerce.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PetProjectEcommerceController : AbpControllerBase
{
    protected PetProjectEcommerceController()
    {
        LocalizationResource = typeof(PetProjectEcommerceResource);
    }
}
