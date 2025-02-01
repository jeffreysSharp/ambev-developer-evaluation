﻿// <auto-generated />
using System;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ambev.DeveloperEvaluation.WebApi.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20250201050114_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SocialNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("cae2cd2e-9790-42aa-82e2-21bf9624be89"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3341),
                            Email = "ameckiff1@icio.us",
                            Name = "Archie Meckiff",
                            Phone = "1251145281",
                            SocialNumber = "117-25-1588"
                        },
                        new
                        {
                            Id = new Guid("58296386-7f48-4f6b-912e-59c68bcb7dfb"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3345),
                            Email = "bpetracek2@dagondesign.com",
                            Name = "Bethina Petracek",
                            Phone = "2784864410",
                            SocialNumber = "807-31-1052"
                        },
                        new
                        {
                            Id = new Guid("91f42b48-25d0-43dd-ba3a-a38b7f36c99b"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3348),
                            Email = "esimmons3@webeden.co.uk",
                            Name = "Eloise Simmons",
                            Phone = "5673473269",
                            SocialNumber = "687-16-2264"
                        },
                        new
                        {
                            Id = new Guid("e2e26006-cd35-4999-9518-a1539eb7db26"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3351),
                            Email = "ppillman4@parallels.com",
                            Name = "Phyllys Pillman",
                            Phone = "4453959379",
                            SocialNumber = "512-17-6944"
                        },
                        new
                        {
                            Id = new Guid("94e826b8-f3d5-4269-beb4-04de803154fb"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3354),
                            Email = "hodeoran5@about.com",
                            Name = "Hildagarde O'Deoran",
                            Phone = "4707864856",
                            SocialNumber = "457-86-4530"
                        },
                        new
                        {
                            Id = new Guid("19a0faf2-f480-4c60-94b5-dfd5f0263a99"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3356),
                            Email = "baulsford6@goo.gl",
                            Name = "Binnie Aulsford",
                            Phone = "9814345966",
                            SocialNumber = "552-29-4372"
                        },
                        new
                        {
                            Id = new Guid("34d172ad-45a1-43ad-8add-4fac88cbf405"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3359),
                            Email = "lcranney7@walmart.com",
                            Name = "Leonid Cranney",
                            Phone = "7247173033",
                            SocialNumber = "523-53-3047"
                        },
                        new
                        {
                            Id = new Guid("1351af4c-e8a5-4971-9202-b793d8c1af5e"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3365),
                            Email = "rmcclary8@nbcnews.com",
                            Name = "Robinett McClary",
                            Phone = "6461435318",
                            SocialNumber = "884-29-8560"
                        },
                        new
                        {
                            Id = new Guid("189bb010-a93b-429e-a732-c2efd62ce667"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3368),
                            Email = "blujan9@exblog.jp",
                            Name = "Barbra Lujan",
                            Phone = "3958797276",
                            SocialNumber = "314-65-1589"
                        });
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed2f764e-c20d-4e15-a6f9-6a7e745b6a7b"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3015),
                            Description = "Guaraná Antarctica Zero 350ml Lata",
                            Image = "image.jpg",
                            Name = "Guaraná Antarctica Zero",
                            Price = 3.3900000000000001,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("2fe254f9-2eed-4c4e-927b-226857b7556b"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3022),
                            Description = "Pepsi Black 350ml Lata",
                            Image = "image.jpg",
                            Name = "Pepsi Black 350ml",
                            Price = 2.6899999999999999,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("49e9bf43-9849-4c51-8f0f-0946dc2b1699"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3025),
                            Description = "Guaraná Antarctica Zero 2L",
                            Image = "image.jpg",
                            Name = "Guaraná Antarctica Zero",
                            Price = 9.4900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("f1c2394f-c505-4560-ad5c-465665d37329"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3028),
                            Description = "Guaraná Antarctica 2L",
                            Image = "image.jpg",
                            Name = "Guaraná Antarctica",
                            Price = 9.4900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("6ac62a66-2817-4e69-ae26-ecc389205761"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3030),
                            Description = "Guaraná Antarctica 350ml Lata",
                            Image = "image.jpg",
                            Name = "Guaraná Antarctica 350ml",
                            Price = 3.3900000000000001,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("6a88c0c9-20fa-427d-b488-e692819f70a9"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3048),
                            Description = "Sukita 2L",
                            Image = "image.jpg",
                            Name = "Sukita 2L",
                            Price = 6.29,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("041e92d7-9d91-4490-a419-a5faf3c87db3"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3050),
                            Description = "Soda Antarctica 350ml",
                            Image = "image.jpg",
                            Name = "Soda Antarctica 350ml",
                            Price = 2.9900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("08b48844-0036-4d87-a79c-8355d5b6b4f3"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3053),
                            Description = "Pepsi Twist 350ml",
                            Image = "image.jpg",
                            Name = "Pepsi Twist 350ml",
                            Price = 2.9900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("958a28f6-ef0c-4993-af8b-691c13469588"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3055),
                            Description = "Soda Antarctica Zero 2L",
                            Image = "image.jpg",
                            Name = "Soda Antarctica Zero 2L",
                            Price = 8.1899999999999995,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("6fa7f0bc-18c4-4356-8628-9cc7ccb10670"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3058),
                            Description = "Tônica Antarctica 350ml",
                            Image = "image.jpg",
                            Name = "Tônica Antarctica 350ml",
                            Price = 3.5899999999999999,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("1af5d1dd-decc-4b49-ab14-f37954140a77"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3061),
                            Description = "Tônica Antarctica 350ml",
                            Image = "image.jpg",
                            Name = "Tônica Antarctica 350ml",
                            Price = 3.5899999999999999,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("1543c94c-f943-443c-b26c-5b38ee1fecab"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3063),
                            Description = "Tônica Antarctica Gengibre 269ml",
                            Image = "image.jpg",
                            Name = "Tônica Antarctica Gengibre 269ml",
                            Price = 2.6899999999999999,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("2448f2e3-009c-4993-86cb-93165f0409e1"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3066),
                            Description = "Sukita Uva 350ml",
                            Image = "image.jpg",
                            Name = "Sukita Uva 350ml",
                            Price = 2.9900000000000002,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("d1f16582-1d45-43bc-ac01-894e9ba88138"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3071),
                            Description = "Sukita 1L",
                            Image = "image.jpg",
                            Name = "Sukita 1L",
                            Price = 4.8899999999999997,
                            Stock = 100
                        });
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("boolean");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateSaleMade")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Discount")
                        .HasColumnType("numeric");

                    b.Property<int>("SaleNumber")
                        .HasColumnType("integer");

                    b.Property<Guid>("SalesBrancheId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalSaleAmount")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("SalesBrancheId")
                        .IsUnique();

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.SaleItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SaleId")
                        .IsUnique();

                    b.ToTable("SaleItems", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.SalesBranch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.HasKey("Id");

                    b.ToTable("SalesBranches", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5be0a150-314d-4ea1-8358-729b6d8a2c2c"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3410),
                            Name = "Camaçari",
                            State = "BA"
                        },
                        new
                        {
                            Id = new Guid("ec610d40-c9c2-4f70-92a0-2171df64152e"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3415),
                            Name = "Caruaru",
                            State = "PE"
                        },
                        new
                        {
                            Id = new Guid("34093644-f1af-4bcd-ae42-b8ad76848504"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3418),
                            Name = "Contagem",
                            State = "MG"
                        },
                        new
                        {
                            Id = new Guid("92a325b4-53e7-47f9-9a74-723f39245438"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3421),
                            Name = "Curitiba",
                            State = "PR"
                        },
                        new
                        {
                            Id = new Guid("323d3bc1-7b55-4c2e-900d-c46a878461ad"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3423),
                            Name = "Guarulhos",
                            State = "SP"
                        },
                        new
                        {
                            Id = new Guid("bfeef6bf-ee91-470f-9bda-09d9d2b4a109"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3425),
                            Name = "Itajáí",
                            State = "SC"
                        },
                        new
                        {
                            Id = new Guid("a6761b34-7577-48fb-ac01-e8c28bca0795"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3431),
                            Name = "Itapissuma",
                            State = "PE"
                        },
                        new
                        {
                            Id = new Guid("199ca56b-a6fa-4099-927e-71b09ad1991a"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3433),
                            Name = "Jacareí",
                            State = "SP"
                        },
                        new
                        {
                            Id = new Guid("859c1fd5-188c-4ae3-b369-173b6425efbf"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3435),
                            Name = "Jaguariúna",
                            State = "SP"
                        },
                        new
                        {
                            Id = new Guid("87123122-c04e-4ad5-b743-da55ea6b7351"),
                            Active = true,
                            CreatedAt = new DateTime(2025, 2, 1, 5, 1, 13, 736, DateTimeKind.Utc).AddTicks(3438),
                            Name = "Jundiaí",
                            State = "SP"
                        });
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Sale", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Customer", "Customer")
                        .WithOne("Sale")
                        .HasForeignKey("Ambev.DeveloperEvaluation.Domain.Entities.Sale", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.SalesBranch", "SalesBranche")
                        .WithOne("Sale")
                        .HasForeignKey("Ambev.DeveloperEvaluation.Domain.Entities.Sale", "SalesBrancheId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("SalesBranche");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.SaleItem", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Product", "Product")
                        .WithOne("SaleItem")
                        .HasForeignKey("Ambev.DeveloperEvaluation.Domain.Entities.SaleItem", "SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Sale", "Sale")
                        .WithMany("SaleItems")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Sale")
                        .IsRequired();
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Product", b =>
                {
                    b.Navigation("SaleItem")
                        .IsRequired();
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Sale", b =>
                {
                    b.Navigation("SaleItems");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.SalesBranch", b =>
                {
                    b.Navigation("Sale")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
