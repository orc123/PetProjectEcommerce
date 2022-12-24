using System.Threading.Tasks;

namespace PetProjectEcommerce.Data;

public interface IPetProjectEcommerceDbSchemaMigrator
{
    Task MigrateAsync();
}
