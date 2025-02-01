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
                    { new Guid("2048e240-dfc8-48a6-b980-4f3c5b86206a"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9994), "rmcclary8@nbcnews.com", "Robinett McClary", "6461435318", "884-29-8560" },
                    { new Guid("6053ffd7-1b6a-4cc2-bcef-95237d577702"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9997), "blujan9@exblog.jp", "Barbra Lujan", "3958797276", "314-65-1589" },
                    { new Guid("6fdc64ab-aa6e-4c9f-ae42-2b11905bdab1"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9973), "bpetracek2@dagondesign.com", "Bethina Petracek", "2784864410", "807-31-1052" },
                    { new Guid("8eb3cd08-68d7-45b5-8fb8-822ccfeb8544"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9982), "hodeoran5@about.com", "Hildagarde O'Deoran", "4707864856", "457-86-4530" },
                    { new Guid("c9c2c9ec-1568-4ee7-986a-e127108ae4c4"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9985), "baulsford6@goo.gl", "Binnie Aulsford", "9814345966", "552-29-4372" },
                    { new Guid("d6b42cb4-f752-4697-899e-9a99f3311493"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9987), "lcranney7@walmart.com", "Leonid Cranney", "7247173033", "523-53-3047" },
                    { new Guid("e2f5f0d4-1cd6-4992-906f-edb85fa9d58f"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9976), "esimmons3@webeden.co.uk", "Eloise Simmons", "5673473269", "687-16-2264" },
                    { new Guid("f069db82-8aba-4ebb-bc46-634229dc5dd4"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9979), "ppillman4@parallels.com", "Phyllys Pillman", "4453959379", "512-17-6944" },
                    { new Guid("fc280d83-cc0a-4930-9f7e-8f50a461dded"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9969), "ameckiff1@icio.us", "Archie Meckiff", "1251145281", "117-25-1588" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "Image", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("079eefe5-3d75-4c57-b502-b378ec1f9056"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9639), "Guaraná Antarctica 350ml Lata", "image.jpg", "Guaraná Antarctica 350ml", 3.3900000000000001, 100 },
                    { new Guid("173aa8a2-e96c-40bd-96bc-31e70302f4ab"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9656), "Sukita 2L", "image.jpg", "Sukita 2L", 6.29, 100 },
                    { new Guid("3f4cf060-8e84-4be7-b1c8-9fdb1c5d9ca1"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9659), "Soda Antarctica 350ml", "image.jpg", "Soda Antarctica 350ml", 2.9900000000000002, 100 },
                    { new Guid("650bbb5a-0171-4545-aef6-a59afff8a01a"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9669), "Tônica Antarctica 350ml", "image.jpg", "Tônica Antarctica 350ml", 3.5899999999999999, 100 },
                    { new Guid("75f2d66b-c1ec-4164-b103-e4ced535553d"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9679), "Sukita Uva 350ml", "image.jpg", "Sukita Uva 350ml", 2.9900000000000002, 100 },
                    { new Guid("7a5e0ea7-431b-416c-b5c3-b4777201337f"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9629), "Pepsi Black 350ml Lata", "image.jpg", "Pepsi Black 350ml", 2.6899999999999999, 100 },
                    { new Guid("86ab33a0-2c86-4129-841c-f7c80a76a2ac"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9672), "Tônica Antarctica 350ml", "image.jpg", "Tônica Antarctica 350ml", 3.5899999999999999, 100 },
                    { new Guid("8d569be4-b1c0-454b-8b6f-7ef38fe4e42e"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9665), "Soda Antarctica Zero 2L", "image.jpg", "Soda Antarctica Zero 2L", 8.1899999999999995, 100 },
                    { new Guid("945b98d5-a5b2-4079-8d28-52043908bd2a"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9662), "Pepsi Twist 350ml", "image.jpg", "Pepsi Twist 350ml", 2.9900000000000002, 100 },
                    { new Guid("981f841b-c163-4c95-aada-e42a531cbcb8"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9675), "Tônica Antarctica Gengibre 269ml", "image.jpg", "Tônica Antarctica Gengibre 269ml", 2.6899999999999999, 100 },
                    { new Guid("9f23d251-7e56-477a-9abc-1b936469d529"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9635), "Guaraná Antarctica 2L", "image.jpg", "Guaraná Antarctica", 9.4900000000000002, 100 },
                    { new Guid("ad735563-1f77-4b2f-bb29-c0eeca159d64"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9632), "Guaraná Antarctica Zero 2L", "image.jpg", "Guaraná Antarctica Zero", 9.4900000000000002, 100 },
                    { new Guid("bec171bd-095c-41b6-954c-a63b8646014f"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9685), "Sukita 1L", "image.jpg", "Sukita 1L", 4.8899999999999997, 100 },
                    { new Guid("cf3ebffc-98ec-4a87-9d1c-012a78c61ea7"), true, new DateTime(2025, 2, 1, 6, 6, 38, 654, DateTimeKind.Utc).AddTicks(9623), "Guaraná Antarctica Zero 350ml Lata", "image.jpg", "Guaraná Antarctica Zero", 3.3900000000000001, 100 }
                });

            migrationBuilder.InsertData(
                table: "SalesBranches",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("21705693-69c8-4ca9-b9dc-e567665dcc2e"), true, new DateTime(2025, 2, 1, 6, 6, 38, 655, DateTimeKind.Utc).AddTicks(66), "Jaguariúna", "SP" },
                    { new Guid("33b30ae1-b803-4549-b49e-fa46614e1d08"), true, new DateTime(2025, 2, 1, 6, 6, 38, 655, DateTimeKind.Utc).AddTicks(54), "Guarulhos", "SP" },
                    { new Guid("40ae8903-0729-4a20-bb02-ac085b2e28f4"), true, new DateTime(2025, 2, 1, 6, 6, 38, 655, DateTimeKind.Utc).AddTicks(64), "Jacareí", "SP" },
                    { new Guid("4d6bc996-0e1e-4453-bb20-b64dea657014"), true, new DateTime(2025, 2, 1, 6, 6, 38, 655, DateTimeKind.Utc).AddTicks(42), "Camaçari", "BA" },
                    { new Guid("65bb57c1-69c8-43e1-bc84-73bffbb0cf99"), true, new DateTime(2025, 2, 1, 6, 6, 38, 655, DateTimeKind.Utc).AddTicks(62), "Itapissuma", "PE" },
                    { new Guid("82aebc50-2317-4607-847a-ca4541501241"), true, new DateTime(2025, 2, 1, 6, 6, 38, 655, DateTimeKind.Utc).AddTicks(46), "Caruaru", "PE" },
                    { new Guid("b978cc4f-3094-482e-8d00-33d93a7be7c8"), true, new DateTime(2025, 2, 1, 6, 6, 38, 655, DateTimeKind.Utc).AddTicks(69), "Jundiaí", "SP" },
                    { new Guid("d10109e8-46c5-4442-8117-68f49642afc5"), true, new DateTime(2025, 2, 1, 6, 6, 38, 655, DateTimeKind.Utc).AddTicks(49), "Contagem", "MG" },
                    { new Guid("da300b36-ad3c-490f-a005-76ac5579c2ec"), true, new DateTime(2025, 2, 1, 6, 6, 38, 655, DateTimeKind.Utc).AddTicks(51), "Curitiba", "PR" },
                    { new Guid("df9968fc-9e45-4605-a830-ef1ffdc8d298"), true, new DateTime(2025, 2, 1, 6, 6, 38, 655, DateTimeKind.Utc).AddTicks(56), "Itajáí", "SC" }
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
