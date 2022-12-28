using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProjectEcommerce.Migrations
{
    public partial class CreateBussinessEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppInventoryTickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TicketType = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApproverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInventoryTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppManufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CoverPicture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Visibility = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppManufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    ShippingFee = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Subtotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    GrandTotal = table.Column<double>(type: "float", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CustomerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOrders_AbpUsers_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppProductAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Visibility = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsUnique = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CoverPicture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Visibility = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SeoMetaDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPromotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CouponCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RequireUseCouponCode = table.Column<bool>(type: "bit", nullable: false),
                    ValidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    DiscountUnit = table.Column<int>(type: "int", nullable: false),
                    LimitedUsageTimes = table.Column<bool>(type: "bit", nullable: false),
                    MaximumDiscountAmount = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPromotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppTags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppInventoryTicketItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SKU = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BatchNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInventoryTicketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryTicketItem_InventoryTicket",
                        column: x => x.TicketId,
                        principalTable: "AppInventoryTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppOrderTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrderTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOrderTransactions_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderTransaction_Order",
                        column: x => x.OrderId,
                        principalTable: "AppOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Visibility = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeoMetaDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ThumbnailPicture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Manufacturer",
                        column: x => x.ManufacturerId,
                        principalTable: "AppManufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory",
                        column: x => x.CategoryId,
                        principalTable: "AppProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppPromotionCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPromotionCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionCategory_Promotion",
                        column: x => x.PromotionId,
                        principalTable: "AppPromotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppPromotionManufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufactureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPromotionManufacturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionManufacturer_Promotion",
                        column: x => x.PromotionId,
                        principalTable: "AppPromotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppPromotionProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPromotionProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionProduct_Promotion",
                        column: x => x.PromotionId,
                        principalTable: "AppPromotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppPromotionUsageHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPromotionUsageHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionUsageHistory_Promotion",
                        column: x => x.PromotionId,
                        principalTable: "AppPromotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppInventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SKU = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Product",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppOrderItems",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SKU = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrderItems", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderItem_Order",
                        column: x => x.OrderId,
                        principalTable: "AppOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppProductAttributeDateTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductAttributeDateTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeDateTime_Product",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeDateTime_ProductAttribute",
                        column: x => x.AttributeId,
                        principalTable: "AppProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppProductAttributeDecimals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductAttributeDecimals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeDecimal_Product",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeDecimal_ProductAttribute",
                        column: x => x.AttributeId,
                        principalTable: "AppProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppProductAttributeInts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductAttributeInts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeInt_Product",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeInt_ProductAttribute",
                        column: x => x.AttributeId,
                        principalTable: "AppProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppProductAttributeTexts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductAttributeTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeText_Product",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeText_ProductAttribute",
                        column: x => x.AttributeId,
                        principalTable: "AppProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppProductAttributeVarchars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductAttributeVarchars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeVarchar_Product",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeVarchar_ProductAttribute",
                        column: x => x.AttributeId,
                        principalTable: "AppProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppProductLinks",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinkedProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductLinks", x => new { x.ProductId, x.LinkedProductId });
                    table.ForeignKey(
                        name: "FK_ProductLink_Product",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppProductReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReview_Order",
                        column: x => x.OrderId,
                        principalTable: "AppOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReview_Product",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReview_ProductReview",
                        column: x => x.ParentId,
                        principalTable: "AppProductReviews",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppProductTags",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductTags", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTag_Product",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTag_Tag",
                        column: x => x.TagId,
                        principalTable: "AppTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppInventories_ProductId",
                table: "AppInventories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInventoryTicketItems_TicketId",
                table: "AppInventoryTicketItems",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrderItems_OrderId",
                table: "AppOrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_CustomerUserId",
                table: "AppOrders",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrderTransactions_OrderId",
                table: "AppOrderTransactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrderTransactions_UserId",
                table: "AppOrderTransactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductAttributeDateTimes_AttributeId",
                table: "AppProductAttributeDateTimes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductAttributeDateTimes_ProductId",
                table: "AppProductAttributeDateTimes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductAttributeDecimals_AttributeId",
                table: "AppProductAttributeDecimals",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductAttributeDecimals_ProductId",
                table: "AppProductAttributeDecimals",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductAttributeInts_AttributeId",
                table: "AppProductAttributeInts",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductAttributeInts_ProductId",
                table: "AppProductAttributeInts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductAttributeTexts_AttributeId",
                table: "AppProductAttributeTexts",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductAttributeTexts_ProductId",
                table: "AppProductAttributeTexts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductAttributeVarchars_AttributeId",
                table: "AppProductAttributeVarchars",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductAttributeVarchars_ProductId",
                table: "AppProductAttributeVarchars",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductReviews_OrderId",
                table: "AppProductReviews",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductReviews_ParentId",
                table: "AppProductReviews",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductReviews_ProductId",
                table: "AppProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_CategoryId",
                table: "AppProducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_ManufacturerId",
                table: "AppProducts",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductTags_TagId",
                table: "AppProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPromotionCategories_PromotionId",
                table: "AppPromotionCategories",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPromotionManufacturers_PromotionId",
                table: "AppPromotionManufacturers",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPromotionProducts_PromotionId",
                table: "AppPromotionProducts",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPromotionUsageHistories_PromotionId",
                table: "AppPromotionUsageHistories",
                column: "PromotionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInventories");

            migrationBuilder.DropTable(
                name: "AppInventoryTicketItems");

            migrationBuilder.DropTable(
                name: "AppOrderItems");

            migrationBuilder.DropTable(
                name: "AppOrderTransactions");

            migrationBuilder.DropTable(
                name: "AppProductAttributeDateTimes");

            migrationBuilder.DropTable(
                name: "AppProductAttributeDecimals");

            migrationBuilder.DropTable(
                name: "AppProductAttributeInts");

            migrationBuilder.DropTable(
                name: "AppProductAttributeTexts");

            migrationBuilder.DropTable(
                name: "AppProductAttributeVarchars");

            migrationBuilder.DropTable(
                name: "AppProductLinks");

            migrationBuilder.DropTable(
                name: "AppProductReviews");

            migrationBuilder.DropTable(
                name: "AppProductTags");

            migrationBuilder.DropTable(
                name: "AppPromotionCategories");

            migrationBuilder.DropTable(
                name: "AppPromotionManufacturers");

            migrationBuilder.DropTable(
                name: "AppPromotionProducts");

            migrationBuilder.DropTable(
                name: "AppPromotionUsageHistories");

            migrationBuilder.DropTable(
                name: "AppInventoryTickets");

            migrationBuilder.DropTable(
                name: "AppProductAttributes");

            migrationBuilder.DropTable(
                name: "AppOrders");

            migrationBuilder.DropTable(
                name: "AppProducts");

            migrationBuilder.DropTable(
                name: "AppTags");

            migrationBuilder.DropTable(
                name: "AppPromotions");

            migrationBuilder.DropTable(
                name: "AppManufacturer");

            migrationBuilder.DropTable(
                name: "AppProductCategories");
        }
    }
}
