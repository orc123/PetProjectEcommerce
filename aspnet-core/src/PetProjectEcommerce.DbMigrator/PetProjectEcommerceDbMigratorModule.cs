using PetProjectEcommerce.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace PetProjectEcommerce.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PetProjectEcommerceEntityFrameworkCoreModule),
    typeof(PetProjectEcommerceApplicationContractsModule)
    )]
public class PetProjectEcommerceDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
