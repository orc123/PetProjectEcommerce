using Volo.Abp.Modularity;

namespace PetProjectEcommerce;

[DependsOn(
    typeof(PetProjectEcommerceApplicationModule),
    typeof(PetProjectEcommerceDomainTestModule)
    )]
public class PetProjectEcommerceApplicationTestModule : AbpModule
{

}
