using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace PetProjectEcommerce.Data;

/* This is used if database provider does't define
 * IPetProjectEcommerceDbSchemaMigrator implementation.
 */
public class NullPetProjectEcommerceDbSchemaMigrator : IPetProjectEcommerceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
