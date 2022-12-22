using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace PetProjectEcommerce;

[Dependency(ReplaceServices = true)]
public class PetProjectEcommerceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "PetProjectEcommerce";
}
