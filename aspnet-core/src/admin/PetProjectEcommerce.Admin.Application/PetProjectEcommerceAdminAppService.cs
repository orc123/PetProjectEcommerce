using PetProjectEcommerce.Localization;

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
