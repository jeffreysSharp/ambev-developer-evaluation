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
                    { new Guid("1f48eeee-4d8b-4312-acf4-56f1243e3c44"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4138), "ameckiff1@icio.us", "Archie Meckiff", "1251145281", "117-25-1588" },
                    { new Guid("51569342-73cf-4f59-9d8d-c62b5c3c69c7"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4141), "bpetracek2@dagondesign.com", "Bethina Petracek", "2784864410", "807-31-1052" },
                    { new Guid("5ad186b5-3af2-4a11-89d4-9d13458265b0"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4160), "rmcclary8@nbcnews.com", "Robinett McClary", "6461435318", "884-29-8560" },
                    { new Guid("77a7541c-7382-49c9-9ab6-371c01c26746"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4155), "baulsford6@goo.gl", "Binnie Aulsford", "9814345966", "552-29-4372" },
                    { new Guid("78347967-d1cb-47ec-a994-588205f39c23"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4157), "lcranney7@walmart.com", "Leonid Cranney", "7247173033", "523-53-3047" },
                    { new Guid("a4cdda75-0ecf-47bd-90c0-fa590b496dcc"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4144), "esimmons3@webeden.co.uk", "Eloise Simmons", "5673473269", "687-16-2264" },
                    { new Guid("b67494b8-7e5a-42b2-b6fc-836e9bb11827"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4162), "blujan9@exblog.jp", "Barbra Lujan", "3958797276", "314-65-1589" },
                    { new Guid("d3e0999e-b488-471d-ab77-6f5844ccf500"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4152), "hodeoran5@about.com", "Hildagarde O'Deoran", "4707864856", "457-86-4530" },
                    { new Guid("e0275f14-afb5-4401-8194-67a7b19e020e"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4147), "ppillman4@parallels.com", "Phyllys Pillman", "4453959379", "512-17-6944" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "Name", "Price", "Status", "Stock" },
                values: new object[,]
                {
                    { new Guid("06d7a669-6bb8-48b6-9abb-f32fb9c54722"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4030), "Pepsi Black 350ml Lata", "image.jpg", "Pepsi Black 350ml", 2.6899999999999999, 1, 100 },
                    { new Guid("0a551424-303d-4583-bf3b-6f933315184d"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4055), "Guaraná Antarctica 2L", "image.jpg", "Guaraná Antarctica", 9.4900000000000002, 1, 100 },
                    { new Guid("1b8ca000-fedd-40ba-82c3-64b84026c7a9"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4063), "Soda Antarctica 350ml", "image.jpg", "Soda Antarctica 350ml", 2.9900000000000002, 1, 100 },
                    { new Guid("30b4765b-b54d-4f54-8390-e68352f2d469"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4065), "Pepsi Twist 350ml", "image.jpg", "Pepsi Twist 350ml", 2.9900000000000002, 1, 100 },
                    { new Guid("4bce8fc8-b34b-4ac1-bffa-3c6411d14520"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4070), "Tônica Antarctica 350ml", "image.jpg", "Tônica Antarctica 350ml", 3.5899999999999999, 1, 100 },
                    { new Guid("593543e8-9f03-4123-973e-1cff38dd9ed6"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4026), "Guaraná Antarctica Zero 350ml Lata", "image.jpg", "Guaraná Antarctica Zero", 3.3900000000000001, 1, 100 },
                    { new Guid("6779577d-73f8-417a-b253-bda918f22c82"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4076), "Tônica Antarctica 350ml", "image.jpg", "Tônica Antarctica 350ml", 3.5899999999999999, 1, 100 },
                    { new Guid("8cd5b2e4-09e8-4b86-ac8e-6535c194f947"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4052), "Guaraná Antarctica Zero 2L", "image.jpg", "Guaraná Antarctica Zero", 9.4900000000000002, 1, 100 },
                    { new Guid("bee9eadb-49a8-48dc-a8f6-6b830ed67ecb"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4085), "Sukita 1L", "image.jpg", "Sukita 1L", 4.8899999999999997, 1, 100 },
                    { new Guid("d17d70e1-04e7-4f7a-8200-a36896df9831"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4081), "Sukita Uva 350ml", "image.jpg", "Sukita Uva 350ml", 2.9900000000000002, 1, 100 },
                    { new Guid("d9f83b1b-0305-4088-bafb-2c09fca64727"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4068), "Soda Antarctica Zero 2L", "image.jpg", "Soda Antarctica Zero 2L", 8.1899999999999995, 1, 100 },
                    { new Guid("de171cb3-d814-467c-9fd0-c3ad5a266e40"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4060), "Sukita 2L", "image.jpg", "Sukita 2L", 6.29, 1, 100 },
                    { new Guid("eb6dbc13-4ef8-4125-941a-8bea30945bcc"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4079), "Tônica Antarctica Gengibre 269ml", "image.jpg", "Tônica Antarctica Gengibre 269ml", 2.6899999999999999, 1, 100 },
                    { new Guid("ef54ad49-fc73-4d98-b43c-76627aaf367f"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4057), "Guaraná Antarctica 350ml Lata", "image.jpg", "Guaraná Antarctica 350ml", 3.3900000000000001, 1, 100 }
                });

            migrationBuilder.InsertData(
                table: "SalesBranches",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("0e8802bd-d427-4c5c-9ccd-af0b40594eb7"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4219), "Itapissuma", "PE" },
                    { new Guid("2b253be0-e8c9-4da8-af6a-b5b3ed1506ae"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4207), "Contagem", "MG" },
                    { new Guid("4d159590-04a7-4513-8afd-8cddfaed25cc"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4217), "Itajáí", "SC" },
                    { new Guid("638c20ab-51d1-4d7f-a8bc-08a4cd866296"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4201), "Camaçari", "BA" },
                    { new Guid("81a5c076-10a3-495f-92f4-ef672d3b0a48"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4212), "Curitiba", "PR" },
                    { new Guid("884eea63-1c31-42d7-b35d-31941a94eeec"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4273), "Jacareí", "SP" },
                    { new Guid("a5f3b56d-3ca1-487c-baf3-f48885f46527"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4278), "Jundiaí", "SP" },
                    { new Guid("b0857121-06c2-4ccf-9904-2a228d8283e0"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4214), "Guarulhos", "SP" },
                    { new Guid("e9ede15a-9fee-45b2-b93e-0451a4a1f31e"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4205), "Caruaru", "PE" },
                    { new Guid("eff40c31-3f16-446f-aadd-d152dc2c24b9"), true, new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(4276), "Jaguariúna", "SP" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Phone", "Role", "Status", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("254a0880-51b5-42d3-949f-878575a0aa7f"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(3760), "kdurn1@51.la", "guetH908~", "2129615239", "Manager", "Active", null, "harkin1" },
                    { new Guid("40d639e8-6493-44d1-b6a0-223e718798da"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(3756), "cdepinna0@ucsd.edu", "ypgeD344.s", "9023970118", "Admin", "Active", null, "nsloane0" },
                    { new Guid("62087d5d-55d7-43f5-9e64-228e188d6f7a"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(3763), "freicharz2@irs.gov", "vxpeC202\"+", "6155049411", "Customer", "Active", null, "bquare2" },
                    { new Guid("89823805-b8ed-4d08-b457-625513edf33e"), new DateTime(2025, 2, 1, 20, 46, 5, 848, DateTimeKind.Utc).AddTicks(3752), "jeferson.almeida@ambev.com", "Teste@123", "11997541210", "Admin", "Active", null, "jeferson.almeida" }
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
