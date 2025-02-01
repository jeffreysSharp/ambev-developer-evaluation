using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    SocialNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesBranches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    SaleNumber = table.Column<int>(type: "integer", nullable: false),
                    TotalSaleAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    DateSaleMade = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cancelled = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesBrancheId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_SalesBranches_SalesBrancheId",
                        column: x => x.SalesBrancheId,
                        principalTable: "SalesBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductImage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItems_Products_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleItems_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Active", "CreatedAt", "Email", "Name", "Phone", "SocialNumber" },
                values: new object[,]
                {
                    { new Guid("1351af4c-e8a5-4971-9202-b793d8c1af5e"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3365), "rmcclary8@nbcnews.com", "Robinett McClary", "6461435318", "884-29-8560" },
                    { new Guid("189bb010-a93b-429e-a732-c2efd62ce667"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3368), "blujan9@exblog.jp", "Barbra Lujan", "3958797276", "314-65-1589" },
                    { new Guid("19a0faf2-f480-4c60-94b5-dfd5f0263a99"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3356), "baulsford6@goo.gl", "Binnie Aulsford", "9814345966", "552-29-4372" },
                    { new Guid("34d172ad-45a1-43ad-8add-4fac88cbf405"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3359), "lcranney7@walmart.com", "Leonid Cranney", "7247173033", "523-53-3047" },
                    { new Guid("58296386-7f48-4f6b-912e-59c68bcb7dfb"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3345), "bpetracek2@dagondesign.com", "Bethina Petracek", "2784864410", "807-31-1052" },
                    { new Guid("91f42b48-25d0-43dd-ba3a-a38b7f36c99b"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3348), "esimmons3@webeden.co.uk", "Eloise Simmons", "5673473269", "687-16-2264" },
                    { new Guid("94e826b8-f3d5-4269-beb4-04de803154fb"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3354), "hodeoran5@about.com", "Hildagarde O'Deoran", "4707864856", "457-86-4530" },
                    { new Guid("cae2cd2e-9790-42aa-82e2-21bf9624be89"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3341), "ameckiff1@icio.us", "Archie Meckiff", "1251145281", "117-25-1588" },
                    { new Guid("e2e26006-cd35-4999-9518-a1539eb7db26"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3351), "ppillman4@parallels.com", "Phyllys Pillman", "4453959379", "512-17-6944" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "Image", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("041e92d7-9d91-4490-a419-a5faf3c87db3"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3050), "Soda Antarctica 350ml", "image.jpg", "Soda Antarctica 350ml", 2.9900000000000002, 100 },
                    { new Guid("08b48844-0036-4d87-a79c-8355d5b6b4f3"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3053), "Pepsi Twist 350ml", "image.jpg", "Pepsi Twist 350ml", 2.9900000000000002, 100 },
                    { new Guid("1543c94c-f943-443c-b26c-5b38ee1fecab"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3063), "Tônica Antarctica Gengibre 269ml", "image.jpg", "Tônica Antarctica Gengibre 269ml", 2.6899999999999999, 100 },
                    { new Guid("1af5d1dd-decc-4b49-ab14-f37954140a77"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3061), "Tônica Antarctica 350ml", "image.jpg", "Tônica Antarctica 350ml", 3.5899999999999999, 100 },
                    { new Guid("2448f2e3-009c-4993-86cb-93165f0409e1"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3066), "Sukita Uva 350ml", "image.jpg", "Sukita Uva 350ml", 2.9900000000000002, 100 },
                    { new Guid("2fe254f9-2eed-4c4e-927b-226857b7556b"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3022), "Pepsi Black 350ml Lata", "image.jpg", "Pepsi Black 350ml", 2.6899999999999999, 100 },
                    { new Guid("49e9bf43-9849-4c51-8f0f-0946dc2b1699"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3025), "Guaraná Antarctica Zero 2L", "image.jpg", "Guaraná Antarctica Zero", 9.4900000000000002, 100 },
                    { new Guid("6a88c0c9-20fa-427d-b488-e692819f70a9"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3048), "Sukita 2L", "image.jpg", "Sukita 2L", 6.29, 100 },
                    { new Guid("6ac62a66-2817-4e69-ae26-ecc389205761"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3030), "Guaraná Antarctica 350ml Lata", "image.jpg", "Guaraná Antarctica 350ml", 3.3900000000000001, 100 },
                    { new Guid("6fa7f0bc-18c4-4356-8628-9cc7ccb10670"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3058), "Tônica Antarctica 350ml", "image.jpg", "Tônica Antarctica 350ml", 3.5899999999999999, 100 },
                    { new Guid("958a28f6-ef0c-4993-af8b-691c13469588"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3055), "Soda Antarctica Zero 2L", "image.jpg", "Soda Antarctica Zero 2L", 8.1899999999999995, 100 },
                    { new Guid("d1f16582-1d45-43bc-ac01-894e9ba88138"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3071), "Sukita 1L", "image.jpg", "Sukita 1L", 4.8899999999999997, 100 },
                    { new Guid("ed2f764e-c20d-4e15-a6f9-6a7e745b6a7b"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3015), "Guaraná Antarctica Zero 350ml Lata", "image.jpg", "Guaraná Antarctica Zero", 3.3900000000000001, 100 },
                    { new Guid("f1c2394f-c505-4560-ad5c-465665d37329"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3028), "Guaraná Antarctica 2L", "image.jpg", "Guaraná Antarctica", 9.4900000000000002, 100 }
                });

            migrationBuilder.InsertData(
                table: "SalesBranches",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("199ca56b-a6fa-4099-927e-71b09ad1991a"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3433), "Jacareí", "SP" },
                    { new Guid("323d3bc1-7b55-4c2e-900d-c46a878461ad"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3423), "Guarulhos", "SP" },
                    { new Guid("34093644-f1af-4bcd-ae42-b8ad76848504"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3418), "Contagem", "MG" },
                    { new Guid("5be0a150-314d-4ea1-8358-729b6d8a2c2c"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3410), "Camaçari", "BA" },
                    { new Guid("859c1fd5-188c-4ae3-b369-173b6425efbf"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3435), "Jaguariúna", "SP" },
                    { new Guid("87123122-c04e-4ad5-b743-da55ea6b7351"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3438), "Jundiaí", "SP" },
                    { new Guid("92a325b4-53e7-47f9-9a74-723f39245438"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3421), "Curitiba", "PR" },
                    { new Guid("a6761b34-7577-48fb-ac01-e8c28bca0795"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3431), "Itapissuma", "PE" },
                    { new Guid("bfeef6bf-ee91-470f-9bda-09d9d2b4a109"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3425), "Itajáí", "SC" },
                    { new Guid("ec610d40-c9c2-4f70-92a0-2171df64152e"), true, new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3415), "Caruaru", "PE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleId",
                table: "SaleItems",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SalesBrancheId",
                table: "Sales",
                column: "SalesBrancheId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SalesBranches");
        }
    }
}
