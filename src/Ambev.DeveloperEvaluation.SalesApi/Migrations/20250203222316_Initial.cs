using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.SalesApi.Migrations
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
                    Status = table.Column<int>(type: "integer", nullable: false)
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
                    Status = table.Column<int>(type: "integer", nullable: false)
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
                    Status = table.Column<int>(type: "integer", nullable: false)
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
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
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
                    Status = table.Column<int>(type: "integer", nullable: false)
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
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Phone", "SocialNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("0e72e824-615c-461e-9249-f0cc06257278"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(865), "rmcclary8@nbcnews.com", "Robinett McClary", "6461435318", "884-29-8560", 1 },
                    { new Guid("6cd7f643-e0d9-469b-b0a4-1a7a9c97c8c5"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(851), "ppillman4@parallels.com", "Phyllys Pillman", "4453959379", "512-17-6944", 1 },
                    { new Guid("851507b8-c4a4-4eed-bde7-ff29b74d7f1d"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(858), "baulsford6@goo.gl", "Binnie Aulsford", "9814345966", "552-29-4372", 1 },
                    { new Guid("9435d6a7-07f8-4a12-86e3-9caf9a1f8c30"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(847), "esimmons3@webeden.co.uk", "Eloise Simmons", "5673473269", "687-16-2264", 1 },
                    { new Guid("a0b0b471-6afc-4c12-ba5a-f3c04f3eeab5"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(854), "hodeoran5@about.com", "Hildagarde O'Deoran", "4707864856", "457-86-4530", 1 },
                    { new Guid("b059c38c-497c-4031-a378-486c9fb9ae43"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(861), "lcranney7@walmart.com", "Leonid Cranney", "7247173033", "523-53-3047", 1 },
                    { new Guid("d68102c9-1ff1-4a15-9592-bf7281d693bc"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(834), "ameckiff1@icio.us", "Archie Meckiff", "1251145281", "117-25-1588", 1 },
                    { new Guid("d84302b2-38a5-4890-a097-3f682e22b0f2"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(843), "bpetracek2@dagondesign.com", "Bethina Petracek", "2784864410", "807-31-1052", 1 },
                    { new Guid("f0bd57bd-df9f-4ffd-9f13-a5f8ba97a20b"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(868), "blujan9@exblog.jp", "Barbra Lujan", "3958797276", "314-65-1589", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "Name", "Price", "Status", "Stock" },
                values: new object[,]
                {
                    { new Guid("0218022f-b28a-4186-b38a-adb79b4b03a0"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(738), "Tônica Antarctica 350ml", "image.jpg", "Tônica Antarctica 350ml", 3.5899999999999999, 1, 100 },
                    { new Guid("043fda51-5f45-4ef7-9fac-1dda0c20a9f3"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(702), "Guaraná Antarctica Zero 2L", "image.jpg", "Guaraná Antarctica Zero", 9.4900000000000002, 1, 100 },
                    { new Guid("0c69bcd8-a0f4-40af-b986-e2ec383b46f9"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(734), "Tônica Antarctica 350ml", "image.jpg", "Tônica Antarctica 350ml", 3.5899999999999999, 1, 100 },
                    { new Guid("1cdbb9e1-30d7-4c64-8361-b2a6b2ed7d0c"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(706), "Guaraná Antarctica 2L", "image.jpg", "Guaraná Antarctica", 9.4900000000000002, 1, 100 },
                    { new Guid("1e11394a-241a-46b9-8b63-1eca0c97252a"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(745), "Sukita Uva 350ml", "image.jpg", "Sukita Uva 350ml", 2.9900000000000002, 1, 100 },
                    { new Guid("4a81f541-ee75-4434-802c-3e0fea9934e2"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(731), "Soda Antarctica Zero 2L", "image.jpg", "Soda Antarctica Zero 2L", 8.1899999999999995, 1, 100 },
                    { new Guid("73ba83aa-5457-413a-814e-b80d0015eca7"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(713), "Sukita 2L", "image.jpg", "Sukita 2L", 6.29, 1, 100 },
                    { new Guid("81332a02-f937-4e13-91ea-9a68fb5d5349"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(710), "Guaraná Antarctica 350ml Lata", "image.jpg", "Guaraná Antarctica 350ml", 3.3900000000000001, 1, 100 },
                    { new Guid("952a9e54-c256-4e73-95a8-17ea241d61e9"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(741), "Tônica Antarctica Gengibre 269ml", "image.jpg", "Tônica Antarctica Gengibre 269ml", 2.6899999999999999, 1, 100 },
                    { new Guid("d99e5619-acf8-4457-8072-8764d3bf9465"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(727), "Pepsi Twist 350ml", "image.jpg", "Pepsi Twist 350ml", 2.9900000000000002, 1, 100 },
                    { new Guid("e16b8014-2d59-4eb0-94b9-63d32b5ce612"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(694), "Guaraná Antarctica Zero 350ml Lata", "image.jpg", "Guaraná Antarctica Zero", 3.3900000000000001, 1, 100 },
                    { new Guid("ea422f67-faf9-471c-9697-e787a9f10e12"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(717), "Soda Antarctica 350ml", "image.jpg", "Soda Antarctica 350ml", 2.9900000000000002, 1, 100 },
                    { new Guid("f66f4753-699b-421a-bf3f-8d46a9ac6477"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(749), "Sukita 1L", "image.jpg", "Sukita 1L", 4.8899999999999997, 1, 100 },
                    { new Guid("ff779b48-d32d-4594-846e-bb73774a2179"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(698), "Pepsi Black 350ml Lata", "image.jpg", "Pepsi Black 350ml", 2.6899999999999999, 1, 100 }
                });

            migrationBuilder.InsertData(
                table: "SalesBranches",
                columns: new[] { "Id", "CreatedAt", "Name", "State", "Status" },
                values: new object[,]
                {
                    { new Guid("0fa8e63e-f881-40ee-82ad-5d2e039fc8e3"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(962), "Jaguariúna", "SP", 1 },
                    { new Guid("5c9cb422-f7b1-47d5-b115-7bdffe902b14"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(934), "Camaçari", "BA", 1 },
                    { new Guid("6414124f-2154-4bfc-a7d5-fe8db16d243b"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(945), "Curitiba", "PR", 1 },
                    { new Guid("7fdd65fd-05cf-440a-96b5-750200b2e1ef"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(956), "Jacareí", "SP", 1 },
                    { new Guid("ad2bb90b-f014-4e03-a932-2b804cdfc26b"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(938), "Caruaru", "PE", 1 },
                    { new Guid("bb4b9e3e-52f4-43d1-9ab0-74f9a676a922"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(950), "Itajáí", "SC", 1 },
                    { new Guid("e3927d22-d28e-4545-a7a8-03f2f8f613df"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(953), "Itapissuma", "PE", 1 },
                    { new Guid("f68d81fb-eeaa-49b2-9528-a8c3fd49d196"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(942), "Contagem", "MG", 1 },
                    { new Guid("f89908fc-e13d-4e46-9c44-35f44ea90537"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(948), "Guarulhos", "SP", 1 },
                    { new Guid("fd388b70-c6f0-4c34-b4dc-ebb9fb587f74"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(965), "Jundiaí", "SP", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Phone", "Role", "Status", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("205b14c3-5b78-4df0-a3f4-bc44b821d1a4"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(119), "kdurn1@51.la", "guetH908~", "2129615239", "Manager", "Active", null, "harkin1" },
                    { new Guid("50213d88-dc36-4670-b351-a435a26e53f6"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(138), "freicharz2@irs.gov", "vxpeC202\"+", "6155049411", "Customer", "Active", null, "bquare2" },
                    { new Guid("8432d35d-4f79-493c-9ccd-a69a81912d1a"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(109), "jeferson.almeida@ambev.com", "Teste@123", "11997541210", "Admin", "Active", null, "jeferson.almeida" },
                    { new Guid("c7c02971-074d-4a02-87c0-692df1bf1b5d"), new DateTime(2025, 2, 3, 22, 23, 15, 618, DateTimeKind.Utc).AddTicks(114), "cdepinna0@ucsd.edu", "ypgeD344.s", "9023970118", "Admin", "Active", null, "nsloane0" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleId",
                table: "SaleItems",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SalesBrancheId",
                table: "Sales",
                column: "SalesBrancheId");
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
