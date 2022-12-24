using Volo.Abp.Modularity;

namespace PetProjectEcommerce.Admin;

[DependsOn(
    typeof(PetProjectEcommerceAdminApplicationModule),
    typeof(PetProjectEcommerceDomainTestModule)
    )]
public class PetProjectEcommerceAdminApplicationTestModule : AbpModule
{

}
