namespace PetProjectEcommerce.Products;

public class ProductRepository :
     EfCoreRepository<PetProjectEcommerceDbContext, Product, Guid>
    , IProductRepository
    , ITransientDependency
{
    public ProductRepository(IDbContextProvider<PetProjectEcommerceDbContext> dbContextProvider) : 
        base(dbContextProvider)
    {
    }

    public async Task<List<Product>> GetProducts()
    {
        var dbSet = await GetDbSetAsync();
        var query = dbSet
            .Include(x => x.ProductCategory)
            .OrderByDescending(x => x.CreationTime)
            .Where(x => x.IsActive);
        return await query.ToListAsync();
    }

    public async Task<(int, List<Product>)> GetPagedProducts(Guid? categoryId, string keyword, int skipCount, int maxResultCount)
    {
        var dbSet = await GetDbSetAsync();
        var query = dbSet
            .WhereIf(!string.IsNullOrEmpty(keyword), x => x.Name.Contains(keyword))
            .WhereIf(categoryId.HasValue, x => x.CategoryId == categoryId.Value);

        return (
            await query
                .CountAsync(),
            await query
                .Include(x => x.ProductCategory)
                .OrderByDescending(x => x.CreationTime)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync()
            );
    }
}
