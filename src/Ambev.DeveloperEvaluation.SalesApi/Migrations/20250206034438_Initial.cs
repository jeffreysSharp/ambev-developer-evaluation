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
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    SocialNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    TotalSaleAmount = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_SalesBranches_SalesBrancheId",
                        column: x => x.SalesBrancheId,
                        principalTable: "SalesBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    TotalSaleItemAmount = table.Column<double>(type: "double precision", nullable: false),
                    Discount = table.Column<double>(type: "double precision", nullable: false),
                    TotalPriceDiscount = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItems_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Phone", "SocialNumber", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("271cd039-421d-4527-b5a6-8628ceb22476"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9697), "ameckiff1@icio.us", "Archie Meckiff", "1251145281", "117-25-1588", 1, null },
                    { new Guid("366dd965-ea7b-4497-a563-001c3ee7cb45"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9718), "baulsford6@goo.gl", "Binnie Aulsford", "9814345966", "552-29-4372", 1, null },
                    { new Guid("455138fd-4148-44a1-9294-7c10056d6357"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9711), "ppillman4@parallels.com", "Phyllys Pillman", "4453959379", "512-17-6944", 1, null },
                    { new Guid("8a8b7deb-2da3-423d-b6ee-1bb98a550dab"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9715), "hodeoran5@about.com", "Hildagarde O'Deoran", "4707864856", "457-86-4530", 1, null },
                    { new Guid("9e895ff9-ef4e-4484-a1ab-fb4ee34ae916"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9722), "lcranney7@walmart.com", "Leonid Cranney", "7247173033", "523-53-3047", 1, null },
                    { new Guid("a2bce999-9078-43c5-a07f-dda872426ba7"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9730), "blujan9@exblog.jp", "Barbra Lujan", "3958797276", "314-65-1589", 1, null },
                    { new Guid("b5ad3765-3f41-44bb-a863-d42a03efc60e"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9726), "rmcclary8@nbcnews.com", "Robinett McClary", "6461435318", "884-29-8560", 1, null },
                    { new Guid("c180df72-7893-4c43-9aac-cc3e285f56db"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9703), "bpetracek2@dagondesign.com", "Bethina Petracek", "2784864410", "807-31-1052", 1, null },
                    { new Guid("e636ec5b-47bd-4368-8277-3625162b2f00"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9707), "esimmons3@webeden.co.uk", "Eloise Simmons", "5673473269", "687-16-2264", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "Name", "Price", "Status", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("230168d5-4fc4-499b-b67e-f8b04c901d85"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9602), "Tônica Antarctica 350ml", "image.jpg", "Tônica Antarctica 350ml", 3.5899999999999999, 1, 100, null },
                    { new Guid("4ac72fff-c897-4126-ab19-dd2756451d96"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9589), "Sukita 2L", "image.jpg", "Sukita 2L", 6.29, 1, 100, null },
                    { new Guid("4c653cff-229f-48f7-abf5-c1cf66823093"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9582), "Guaraná Antarctica 2L", "image.jpg", "Guaraná Antarctica", 9.4900000000000002, 1, 100, null },
                    { new Guid("58bbc2f5-7416-4419-8748-7ac584acb352"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9609), "Tônica Antarctica Gengibre 269ml", "image.jpg", "Tônica Antarctica Gengibre 269ml", 2.6899999999999999, 1, 100, null },
                    { new Guid("63f35e42-8f53-4a27-a0c7-06ed75391b25"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9606), "Tônica Antarctica 350ml", "image.jpg", "Tônica Antarctica 350ml", 3.5899999999999999, 1, 100, null },
                    { new Guid("7c48f801-5dbd-40ee-b41c-b04c64cd75de"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9574), "Pepsi Black 350ml Lata", "image.jpg", "Pepsi Black 350ml", 2.6899999999999999, 1, 100, null },
                    { new Guid("7fa0352c-fc7f-4f75-b7a4-a294aabb829b"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9616), "Sukita 1L", "image.jpg", "Sukita 1L", 4.8899999999999997, 1, 100, null },
                    { new Guid("842a0194-b06c-4ad2-aaec-9d67892742b2"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9578), "Guaraná Antarctica Zero 2L", "image.jpg", "Guaraná Antarctica Zero", 9.4900000000000002, 1, 100, null },
                    { new Guid("9e66a4a7-b333-41b3-a794-fa77c1d13bdc"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9592), "Soda Antarctica 350ml", "image.jpg", "Soda Antarctica 350ml", 2.9900000000000002, 1, 100, null },
                    { new Guid("d9269a37-c3b7-4e7f-a39a-922efae167d9"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9596), "Pepsi Twist 350ml", "image.jpg", "Pepsi Twist 350ml", 2.9900000000000002, 1, 100, null },
                    { new Guid("debd81f5-7b98-4c63-a482-8f0123bfa093"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9586), "Guaraná Antarctica 350ml Lata", "image.jpg", "Guaraná Antarctica 350ml", 3.3900000000000001, 1, 100, null },
                    { new Guid("e9792765-f7b8-4c82-897b-80b2e274a801"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9612), "Sukita Uva 350ml", "image.jpg", "Sukita Uva 350ml", 2.9900000000000002, 1, 100, null },
                    { new Guid("f5a14523-ceba-4b9d-825f-a53a8db6630f"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9567), "Guaraná Antarctica Zero 350ml Lata", "image.jpg", "Guaraná Antarctica Zero", 3.3900000000000001, 1, 100, null },
                    { new Guid("ffe564eb-da81-4497-be09-fe9333de6ec2"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9599), "Soda Antarctica Zero 2L", "image.jpg", "Soda Antarctica Zero 2L", 8.1899999999999995, 1, 100, null }
                });

            migrationBuilder.InsertData(
                table: "SalesBranches",
                columns: new[] { "Id", "CreatedAt", "Name", "State", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0cacb00b-a4d2-4a14-a7e1-9e73e9c70fc6"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9805), "Caruaru", "PE", 1, null },
                    { new Guid("28ced3eb-027c-4d7b-a689-52ae4b04dc60"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9821), "Itapissuma", "PE", 1, null },
                    { new Guid("3033ae94-060e-4343-ae4b-10912207a58e"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9808), "Contagem", "MG", 1, null },
                    { new Guid("3b97be5a-165c-4c65-97b8-717b52bdcc8f"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9827), "Jaguariúna", "SP", 1, null },
                    { new Guid("7102849b-38dc-4b08-b598-117b92455984"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9830), "Jundiaí", "SP", 1, null },
                    { new Guid("82d01876-9ce5-43f2-b872-f2f838652a82"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9801), "Camaçari", "BA", 1, null },
                    { new Guid("9e1408e3-d9dc-45d4-868a-41518512fa18"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9811), "Curitiba", "PR", 1, null },
                    { new Guid("d7e7b5e2-e159-413a-958a-3babbb72e0d3"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9815), "Guarulhos", "SP", 1, null },
                    { new Guid("f810cf41-08bf-4703-bd80-6096f8034aa8"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9824), "Jacareí", "SP", 1, null },
                    { new Guid("fd883c2c-6c26-4bbc-b60b-5bfda7e72152"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9818), "Itajáí", "SC", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Phone", "Role", "Status", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("82d298ed-ffba-4ede-b907-c4ade280d538"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9260), "freicharz2@irs.gov", "vxpeC202\"+", "6155049411", "Customer", "Active", null, "bquare2" },
                    { new Guid("a660d744-fae9-4539-9fa6-5a7cd346df60"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9241), "jeferson.almeida@ambev.com", "Teste@123", "11997541210", "Admin", "Active", null, "jeferson.almeida" },
                    { new Guid("c72f4e16-7751-4604-940f-5d2512301a83"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9256), "kdurn1@51.la", "guetH908~", "2129615239", "Manager", "Active", null, "harkin1" },
                    { new Guid("de74526e-5311-409f-a3d2-a0f0ec44f475"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9252), "cdepinna0@ucsd.edu", "ypgeD344.s", "9023970118", "Admin", "Active", null, "nsloane0" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "SaleNumber", "SalesBrancheId", "Status", "TotalSaleAmount", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a8b93163-6e0f-431f-baac-2c5a0c69bca5"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9976), new Guid("e636ec5b-47bd-4368-8277-3625162b2f00"), 3, new Guid("3033ae94-060e-4343-ae4b-10912207a58e"), 1, 26.899999999999999, null },
                    { new Guid("d38c0ac9-1dc4-4432-bfda-42fcaaa70b2d"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9944), new Guid("271cd039-421d-4527-b5a6-8628ceb22476"), 1, new Guid("82d01876-9ce5-43f2-b872-f2f838652a82"), 1, 33.899999999999999, null },
                    { new Guid("e33ff51d-cc6a-4f1e-92db-008c43b1b1e5"), new DateTime(2025, 2, 6, 3, 44, 37, 545, DateTimeKind.Utc).AddTicks(9954), new Guid("c180df72-7893-4c43-9aac-cc3e285f56db"), 2, new Guid("0cacb00b-a4d2-4a14-a7e1-9e73e9c70fc6"), 1, 26.899999999999999, null }
                });

            migrationBuilder.InsertData(
                table: "SaleItems",
                columns: new[] { "Id", "CreatedAt", "Discount", "Price", "ProductId", "Quantity", "SaleId", "Status", "TotalPriceDiscount", "TotalSaleItemAmount", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("44151fb7-26d6-43fe-8c41-f35afe2b225a"), new DateTime(2025, 2, 6, 3, 44, 37, 546, DateTimeKind.Utc).AddTicks(44), 10.0, 6.29, new Guid("4ac72fff-c897-4126-ab19-dd2756451d96"), 10, new Guid("d38c0ac9-1dc4-4432-bfda-42fcaaa70b2d"), 1, 56.609999999999999, 62.899999999999999, null },
                    { new Guid("52a842c5-8312-4507-a597-29e1b542e873"), new DateTime(2025, 2, 6, 3, 44, 37, 546, DateTimeKind.Utc).AddTicks(61), 10.0, 9.4900000000000002, new Guid("4c653cff-229f-48f7-abf5-c1cf66823093"), 10, new Guid("d38c0ac9-1dc4-4432-bfda-42fcaaa70b2d"), 1, 85.409999999999997, 94.900000000000006, null },
                    { new Guid("a07e4de7-d0bf-4706-bcc9-54d22f07b918"), new DateTime(2025, 2, 6, 3, 44, 37, 546, DateTimeKind.Utc).AddTicks(38), 10.0, 3.5899999999999999, new Guid("230168d5-4fc4-499b-b67e-f8b04c901d85"), 10, new Guid("d38c0ac9-1dc4-4432-bfda-42fcaaa70b2d"), 1, 33.210000000000001, 36.899999999999999, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleId",
                table: "SaleItems",
                column: "SaleId");

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
                name: "Products");

            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SalesBranches");
        }
    }
}
