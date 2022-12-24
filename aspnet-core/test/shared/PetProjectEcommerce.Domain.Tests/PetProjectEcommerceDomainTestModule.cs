using PetProjectEcommerce.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace PetProjectEcommerce;

[DependsOn(
    typeof(PetProjectEcommerceEntityFrameworkCoreTestModule)
    )]
public class PetProjectEcommerceDomainTestModule : AbpModule
{

}
