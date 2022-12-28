using Microsoft.EntityFrameworkCore;
using PetProjectEcommerce.Inventories;
using PetProjectEcommerce.InventoryTickets;
using PetProjectEcommerce.Manufacturers;
using PetProjectEcommerce.Orders;
using PetProjectEcommerce.ProductAttributes;
using PetProjectEcommerce.ProductCategories;
using PetProjectEcommerce.Products;
using PetProjectEcommerce.Promotions;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace PetProjectEcommerce.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class PetProjectEcommerceDbContext :
    AbpDbContext<PetProjectEcommerceDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    #region App

    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryTicket> InventoryTickets { get; set; }
    public DbSet<InventoryTicketItem> InventoryTicketItems { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderTransaction> OrderTransactions { get; set; }
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductAttributeDateTime> ProductAttributeDateTimes { get; set; }
    public DbSet<ProductAttributeDecimal> ProductAttributeDecimals { get; set; }
    public DbSet<ProductAttributeInt> ProductAttributeInts { get; set; }
    public DbSet<ProductAttributeText> ProductAttributeTexts { get; set; }
    public DbSet<ProductAttributeVarchar> ProductAttributeVarchars { get; set; }
    public DbSet<ProductLink> ProductLinks { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<PromotionCategory> PromotionCategories { get; set; }
    public DbSet<PromotionManufacturer> PromotionManufacturers { get; set; }
    public DbSet<PromotionProduct> PromotionProducts { get; set; }
    public DbSet<PromotionUsageHistory> PromotionUsageHistories { get; set; }

    #endregion

    public PetProjectEcommerceDbContext(DbContextOptions<PetProjectEcommerceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();



        /* Configure your own tables/entities inside here */

        #region App

        builder.Entity<Inventory>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}Inventories");
            b.HasKey(x => x.Id);
            b.Property(x => x.SKU)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            b.Property(x => x.StockQuantity)
                .IsRequired();
            b.HasOne(x => x.Product).WithMany(x => x.Inventories).HasConstraintName("FK_Inventory_Product").HasForeignKey(x => x.ProductId);
        });

        builder.Entity<InventoryTicket>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}InventoryTickets");
            b.HasKey(x => x.Id);
            b.Property(x => x.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
        });

        builder.Entity<InventoryTicketItem>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}InventoryTicketItems");
            b.HasKey(x => x.Id);
            b.Property(x => x.SKU)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            b.Property(x => x.BatchNumber)
               .HasMaxLength(50)
               .IsUnicode(false);

            b.HasOne(x => x.InventoryTicket).WithMany(x => x.InventoryTicketItems).HasConstraintName("FK_InventoryTicketItem_InventoryTicket").HasForeignKey(x => x.TicketId);
        });

        builder.Entity<Manufacturer>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}Manufacturer");
            b.HasKey(x => x.Id);
            b.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            b.Property(x => x.Code)
                 .HasMaxLength(50)
                 .IsUnicode(false)
                 .IsRequired();

            b.Property(x => x.Slug)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            b.Property(x => x.CoverPicture)
               .HasMaxLength(250);
        });

        builder.Entity<Order>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}Orders");
            b.HasKey(x => x.Id);
            b.Property(x => x.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            b.Property(x => x.CustomerName)
              .HasMaxLength(50)
              .IsRequired();
            b.Property(x => x.CustomerAddress)
              .HasMaxLength(250)
              .IsRequired();

            b.Property(x => x.CustomerPhoneNumber)
              .HasMaxLength(50)
              .IsRequired();

            b.HasOne(x => x.User).WithMany().HasForeignKey(x => x.CustomerUserId);
        });

        builder.Entity<OrderItem>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}OrderItems");
            b.HasKey(x => new { x.ProductId, x.OrderId });
            b.Property(x => x.SKU)
                 .HasMaxLength(50)
                 .IsUnicode(false)
                 .IsRequired();

            b.HasOne(x => x.Order).WithMany(x => x.OrderItems).HasConstraintName("FK_OrderItem_Order").HasForeignKey(x => x.OrderId);
            b.HasOne(x => x.Product).WithMany(x => x.OrderItems).HasConstraintName("FK_OrderItem_Product").HasForeignKey(x => x.ProductId);
        });

        builder.Entity<OrderTransaction>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}OrderTransactions");
            b.HasKey(x => x.Id);
            b.Property(x => x.Code)
               .HasMaxLength(50)
               .IsUnicode(false)
               .IsRequired();
            b.HasOne(x => x.Order).WithMany(x => x.OrderTransactions).HasConstraintName("FK_OrderTransaction_Order").HasForeignKey(x => x.OrderId);
            b.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        });

        builder.Entity<ProductAttribute>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}ProductAttributes");
            b.HasKey(x => x.Id);
            b.Property(x => x.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            b.Property(x => x.Label)
               .HasMaxLength(50)
               .IsRequired();
        });

        builder.Entity<ProductCategory>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}ProductCategories");
            b.HasKey(x => x.Id);
            b.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            b.Property(x => x.Code)
                 .HasMaxLength(50)
                 .IsUnicode(false)
                 .IsRequired();

            b.Property(x => x.Slug)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            b.Property(x => x.CoverPicture)
               .HasMaxLength(250);

            b.Property(x => x.SeoMetaDescription)
             .HasMaxLength(250);
        });

        builder.Entity<Product>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}Products");
            b.HasKey(x => x.Id);
            b.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            b.Property(x => x.Code)
                 .HasMaxLength(50)
                 .IsUnicode(false)
                 .IsRequired();

            b.Property(x => x.Slug)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            b.Property(x => x.SKU)
               .HasMaxLength(50)
               .IsUnicode(false)
               .IsRequired();


            b.Property(x => x.ThumbnailPicture)
               .HasMaxLength(250);

            b.Property(x => x.SeoMetaDescription)
             .HasMaxLength(250);

            b.HasOne(x => x.ProductCategory).WithMany(x => x.Products).HasConstraintName("FK_Product_ProductCategory").HasForeignKey(x => x.CategoryId);
            b.HasOne(x => x.Manufacturer).WithMany(x => x.Products).HasConstraintName("FK_Product_Manufacturer").HasForeignKey(x => x.ManufacturerId);
        });

        builder.Entity<ProductAttributeDateTime>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}ProductAttributeDateTimes");
            b.HasKey(x => x.Id);

            b.HasOne(x => x.ProductAttribute).WithMany(x => x.ProductAttributeDateTimes).HasConstraintName("FK_ProductAttributeDateTime_ProductAttribute")
                .HasForeignKey(x => x.AttributeId);
            b.HasOne(x => x.Product).WithMany(x => x.ProductAttributeDateTimes).HasConstraintName("FK_ProductAttributeDateTime_Product")
                .HasForeignKey(x => x.ProductId);
        });

        builder.Entity<ProductAttributeDecimal>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}ProductAttributeDecimals");
            b.HasKey(x => x.Id);

            b.HasOne(x => x.ProductAttribute).WithMany(x => x.ProductAttributeDecimals).HasConstraintName("FK_ProductAttributeDecimal_ProductAttribute")
               .HasForeignKey(x => x.AttributeId);
            b.HasOne(x => x.Product).WithMany(x => x.ProductAttributeDecimals).HasConstraintName("FK_ProductAttributeDecimal_Product")
                .HasForeignKey(x => x.ProductId);
        });

        builder.Entity<ProductAttributeInt>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}ProductAttributeInts");
            b.HasKey(x => x.Id);

            b.HasOne(x => x.ProductAttribute).WithMany(x => x.ProductAttributeInts).HasConstraintName("FK_ProductAttributeInt_ProductAttribute")
               .HasForeignKey(x => x.AttributeId);
            b.HasOne(x => x.Product).WithMany(x => x.ProductAttributeInts).HasConstraintName("FK_ProductAttributeInt_Product")
                .HasForeignKey(x => x.ProductId);
        });

        builder.Entity<ProductAttributeText>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}ProductAttributeTexts");
            b.HasKey(x => x.Id);
            b.Property(x => x.Value).HasMaxLength(500);

            b.HasOne(x => x.ProductAttribute).WithMany(x => x.ProductAttributeTexts).HasConstraintName("FK_ProductAttributeText_ProductAttribute")
               .HasForeignKey(x => x.AttributeId);
            b.HasOne(x => x.Product).WithMany(x => x.ProductAttributeTexts).HasConstraintName("FK_ProductAttributeText_Product")
                .HasForeignKey(x => x.ProductId);
        });

        builder.Entity<ProductAttributeVarchar>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}ProductAttributeVarchars");
            b.HasKey(x => x.Id);
            b.Property(x => x.Value).HasMaxLength(500);

            b.HasOne(x => x.ProductAttribute).WithMany(x => x.ProductAttributeVarchars).HasConstraintName("FK_ProductAttributeVarchar_ProductAttribute")
               .HasForeignKey(x => x.AttributeId);
            b.HasOne(x => x.Product).WithMany(x => x.ProductAttributeVarchars).HasConstraintName("FK_ProductAttributeVarchar_Product")
                .HasForeignKey(x => x.ProductId);
        });

        builder.Entity<ProductLink>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}ProductLinks");
            b.HasKey(x => new { x.ProductId, x.LinkedProductId });

            b.HasOne(x => x.Product).WithMany(x => x.ProductLinks).HasConstraintName("FK_ProductLink_Product")
             .HasForeignKey(x => x.ProductId);
        });

        builder.Entity<ProductReview>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}ProductReviews");
            b.HasKey(x => x.Id);
            b.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250);
            b.HasOne(x => x.Product).WithMany(x => x.ProductReviews).HasConstraintName("FK_ProductReview_Product").HasForeignKey(x => x.ProductId);
            b.HasOne(x => x.ProductReviewParent).WithMany(x => x.ProductReviewChilds).HasConstraintName("FK_ProductReview_ProductReview")
                    .HasForeignKey(x => x.ParentId);
        });

        builder.Entity<ProductTag>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}ProductTags");
            b.HasKey(x => new { x.ProductId, x.TagId });

            b.HasOne(x => x.Product).WithMany(x => x.ProductTags).HasConstraintName("FK_ProductTag_Product").HasForeignKey(x => x.ProductId);
            b.HasOne(x => x.Tag).WithMany(x => x.ProductTags).HasConstraintName("FK_ProductTag_Tag").HasForeignKey(x => x.TagId);
        });

        builder.Entity<Tag>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}Tags");
            b.HasKey(x => x.Id);
            b.Property(x => x.Id)
               .HasMaxLength(50)
               .IsRequired();
            b.Property(x => x.Name)
               .HasMaxLength(50)
               .IsRequired();
        });

        builder.Entity<Promotion>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}Promotions");
            b.HasKey(x => x.Id);
            b.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            b.Property(x => x.CouponCode)
                 .HasMaxLength(50)
                 .IsUnicode(false)
                 .IsRequired();
        });

        builder.Entity<PromotionCategory>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}PromotionCategories");
            b.HasKey(x => x.Id);

            b.HasOne(x => x.Promotion).WithMany(x => x.PromotionCategories).HasConstraintName("FK_PromotionCategory_Promotion")
               .HasForeignKey(x => x.PromotionId);
        });

        builder.Entity<PromotionManufacturer>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}PromotionManufacturers");
            b.HasKey(x => x.Id);

            b.HasOne(x => x.Promotion).WithMany(x => x.PromotionManufacturers).HasConstraintName("FK_PromotionManufacturer_Promotion")
              .HasForeignKey(x => x.PromotionId);
        });

        builder.Entity<PromotionProduct>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}PromotionProducts");
            b.HasKey(x => x.Id);

            b.HasOne(x => x.Promotion).WithMany(x => x.PromotionProducts).HasConstraintName("FK_PromotionProduct_Promotion")
              .HasForeignKey(x => x.PromotionId);;
        });

        builder.Entity<PromotionUsageHistory>(b =>
        {
            b.ToTable($"{PetProjectEcommerceConsts.DbTablePrefix}PromotionUsageHistories");
            b.HasKey(x => x.Id);

            b.HasOne(x => x.Promotion).WithMany(x => x.PromotionUsageHistories).HasConstraintName("FK_PromotionUsageHistory_Promotion")
              .HasForeignKey(x => x.PromotionId);
        });

        #endregion
    }
}
