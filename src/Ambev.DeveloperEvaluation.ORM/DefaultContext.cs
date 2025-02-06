using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SalesBranch> SalesBranches { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        #region Insert Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.Parse("a660d744-fae9-4539-9fa6-5a7cd346df60"),
                Username = "jeferson.almeida",
                Email = "jeferson.almeida@ambev.com",
                Phone = "11997541210",
                Password = "Teste@123",
                Role = UserRole.Admin,
                Status = Status.Active,
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = Guid.Parse("de74526e-5311-409f-a3d2-a0f0ec44f475"),
                Username = "nsloane0",
                Email = "cdepinna0@ucsd.edu",
                Phone = "9023970118",
                Password = "ypgeD344.s",
                Role = UserRole.Admin,
                Status = Status.Active,
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = Guid.Parse("c72f4e16-7751-4604-940f-5d2512301a83"),
                Username = "harkin1",
                Email = "kdurn1@51.la",
                Phone = "2129615239",
                Password = "guetH908~",
                Role = UserRole.Manager,
                Status = Status.Active,
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = Guid.Parse("82d298ed-ffba-4ede-b907-c4ade280d538"),
                Username = "bquare2",
                Email = "freicharz2@irs.gov",
                Phone = "6155049411",
                Password = "vxpeC202\"+",
                Role = UserRole.Customer,
                Status = Status.Active,
                CreatedAt = DateTime.UtcNow
            }
        );
        #endregion

        #region Insert Products        
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.Parse("f5a14523-ceba-4b9d-825f-a53a8db6630f"),
                Name = "Guaraná Antarctica Zero",
                Description = "Guaraná Antarctica Zero 350ml Lata",
                Price = 3.39,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("7c48f801-5dbd-40ee-b41c-b04c64cd75de"),
                Name = "Pepsi Black 350ml",
                Description = "Pepsi Black 350ml Lata",
                Price = 2.69,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("842a0194-b06c-4ad2-aaec-9d67892742b2"),
                Name = "Guaraná Antarctica Zero",
                Description = "Guaraná Antarctica Zero 2L",
                Price = 9.49,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("4c653cff-229f-48f7-abf5-c1cf66823093"),
                Name = "Guaraná Antarctica",
                Description = "Guaraná Antarctica 2L",
                Price = 9.49,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("debd81f5-7b98-4c63-a482-8f0123bfa093"),
                Name = "Guaraná Antarctica 350ml",
                Description = "Guaraná Antarctica 350ml Lata",
                Price = 3.39,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("4ac72fff-c897-4126-ab19-dd2756451d96"),
                Name = "Sukita 2L",
                Description = "Sukita 2L",
                Price = 6.29,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("9e66a4a7-b333-41b3-a794-fa77c1d13bdc"),
                Name = "Soda Antarctica 350ml",
                Description = "Soda Antarctica 350ml",
                Price = 2.99,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("d9269a37-c3b7-4e7f-a39a-922efae167d9"),
                Name = "Pepsi Twist 350ml",
                Description = "Pepsi Twist 350ml",
                Price = 2.99,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("ffe564eb-da81-4497-be09-fe9333de6ec2"),
                Name = "Soda Antarctica Zero 2L",
                Description = "Soda Antarctica Zero 2L",
                Price = 8.19,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("230168d5-4fc4-499b-b67e-f8b04c901d85"),
                Name = "Tônica Antarctica 350ml",
                Description = "Tônica Antarctica 350ml",
                Price = 3.59,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("63f35e42-8f53-4a27-a0c7-06ed75391b25"),
                Name = "Tônica Antarctica 350ml",
                Description = "Tônica Antarctica 350ml",
                Price = 3.59,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("58bbc2f5-7416-4419-8748-7ac584acb352"),
                Name = "Tônica Antarctica Gengibre 269ml",
                Description = "Tônica Antarctica Gengibre 269ml",
                Price = 2.69,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("e9792765-f7b8-4c82-897b-80b2e274a801"),
                Name = "Sukita Uva 350ml",
                Description = "Sukita Uva 350ml",
                Price = 2.99,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Product
            {
                Id = Guid.Parse("7fa0352c-fc7f-4f75-b7a4-a294aabb829b"),
                Name = "Sukita 1L",
                Description = "Sukita 1L",
                Price = 4.89,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            }
        );
        #endregion

        #region Insert Customers
        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = Guid.Parse("271cd039-421d-4527-b5a6-8628ceb22476"),
                Name = "Archie Meckiff",
                Email = "ameckiff1@icio.us",
                Phone = "1251145281",
                SocialNumber = "117-25-1588",
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Customer
            {
                Id = Guid.Parse("c180df72-7893-4c43-9aac-cc3e285f56db"),
                Name = "Bethina Petracek",
                Email = "bpetracek2@dagondesign.com",
                Phone = "2784864410",
                SocialNumber = "807-31-1052",
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Customer
            {
                Id = Guid.Parse("e636ec5b-47bd-4368-8277-3625162b2f00"),
                Name = "Eloise Simmons",
                Email = "esimmons3@webeden.co.uk",
                Phone = "5673473269",
                SocialNumber = "687-16-2264",
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Customer
            {
                Id = Guid.Parse("455138fd-4148-44a1-9294-7c10056d6357"),
                Name = "Phyllys Pillman",
                Email = "ppillman4@parallels.com",
                Phone = "4453959379",
                SocialNumber = "512-17-6944",
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Customer
            {
                Id = Guid.Parse("8a8b7deb-2da3-423d-b6ee-1bb98a550dab"),
                Name = "Hildagarde O'Deoran",
                Email = "hodeoran5@about.com",
                Phone = "4707864856",
                SocialNumber = "457-86-4530",
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Customer
            {
                Id = Guid.Parse("366dd965-ea7b-4497-a563-001c3ee7cb45"),
                Name = "Binnie Aulsford",
                Email = "baulsford6@goo.gl",
                Phone = "9814345966",
                SocialNumber = "552-29-4372",
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Customer
            {
                Id = Guid.Parse("9e895ff9-ef4e-4484-a1ab-fb4ee34ae916"),
                Name = "Leonid Cranney",
                Email = "lcranney7@walmart.com",
                Phone = "7247173033",
                SocialNumber = "523-53-3047",
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Customer
            {
                Id = Guid.Parse("b5ad3765-3f41-44bb-a863-d42a03efc60e"),
                Name = "Robinett McClary",
                Email = "rmcclary8@nbcnews.com",
                Phone = "6461435318",
                SocialNumber = "884-29-8560",
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Customer
            {
                Id = Guid.Parse("a2bce999-9078-43c5-a07f-dda872426ba7"),
                Name = "Barbra Lujan",
                Email = "blujan9@exblog.jp",
                Phone = "3958797276",
                SocialNumber = "314-65-1589",
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            }
        );
        #endregion

        #region Insert  Sales Branch
        modelBuilder.Entity<SalesBranch>().HasData(
           new SalesBranch
           {
               Id = Guid.Parse("82d01876-9ce5-43f2-b872-f2f838652a82"),
               Name = "Camaçari",
               State = "BA",
               CreatedAt = DateTime.UtcNow,
               Status = Status.Active
           },
           new SalesBranch
           {
               Id = Guid.Parse("0cacb00b-a4d2-4a14-a7e1-9e73e9c70fc6"),
               Name = "Caruaru",
               State = "PE",
               CreatedAt = DateTime.UtcNow,
               Status = Status.Active
           },
           new SalesBranch
           {
               Id = Guid.Parse("3033ae94-060e-4343-ae4b-10912207a58e"),
               Name = "Contagem",
               State = "MG",
               CreatedAt = DateTime.UtcNow,
               Status = Status.Active
           },
           new SalesBranch
           {
               Id = Guid.Parse("9e1408e3-d9dc-45d4-868a-41518512fa18"),
               Name = "Curitiba",
               State = "PR",
               CreatedAt = DateTime.UtcNow,
               Status = Status.Active
           },
           new SalesBranch
           {
               Id = Guid.Parse("d7e7b5e2-e159-413a-958a-3babbb72e0d3"),
               Name = "Guarulhos",
               State = "SP",
               CreatedAt = DateTime.UtcNow,
               Status = Status.Active
           },
           new SalesBranch
           {
               Id = Guid.Parse("fd883c2c-6c26-4bbc-b60b-5bfda7e72152"),
               Name = "Itajáí",
               State = "SC",
               CreatedAt = DateTime.UtcNow,
               Status = Status.Active
           },
           new SalesBranch
           {
               Id = Guid.Parse("28ced3eb-027c-4d7b-a689-52ae4b04dc60"),
               Name = "Itapissuma",
               State = "PE",
               CreatedAt = DateTime.UtcNow,
               Status = Status.Active
           },
           new SalesBranch
           {
               Id = Guid.Parse("f810cf41-08bf-4703-bd80-6096f8034aa8"),
               Name = "Jacareí",
               State = "SP",
               CreatedAt = DateTime.UtcNow,
               Status = Status.Active
           },
           new SalesBranch
           {
               Id = Guid.Parse("3b97be5a-165c-4c65-97b8-717b52bdcc8f"),
               Name = "Jaguariúna",
               State = "SP",
               CreatedAt = DateTime.UtcNow,
               Status = Status.Active
           },
           new SalesBranch
           {
               Id = Guid.Parse("7102849b-38dc-4b08-b598-117b92455984"),
               Name = "Jundiaí",
               State = "SP",
               CreatedAt = DateTime.UtcNow,
               Status = Status.Active
           }
         );
        #endregion

        #region Insert Sales
        modelBuilder.Entity<Sale>().HasData(
            new Sale
            {
                Id = Guid.Parse("d38c0ac9-1dc4-4432-bfda-42fcaaa70b2d"),
                SaleNumber = 1,
                TotalSaleAmount = 33.90,
                CustomerId = Guid.Parse("271cd039-421d-4527-b5a6-8628ceb22476"),
                SalesBrancheId = Guid.Parse("82d01876-9ce5-43f2-b872-f2f838652a82"),
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Sale
            {
                Id = Guid.Parse("e33ff51d-cc6a-4f1e-92db-008c43b1b1e5"),
                SaleNumber = 2,
                TotalSaleAmount = 26.90,
                CustomerId = Guid.Parse("c180df72-7893-4c43-9aac-cc3e285f56db"),
                SalesBrancheId = Guid.Parse("0cacb00b-a4d2-4a14-a7e1-9e73e9c70fc6"),
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new Sale
            {
                Id = Guid.Parse("a8b93163-6e0f-431f-baac-2c5a0c69bca5"),
                SaleNumber = 3,
                TotalSaleAmount = 26.90,
                CustomerId = Guid.Parse("e636ec5b-47bd-4368-8277-3625162b2f00"),
                SalesBrancheId = Guid.Parse("3033ae94-060e-4343-ae4b-10912207a58e"),
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            });
        #endregion

        #region Insert Sale Items
        modelBuilder.Entity<SaleItem>().HasData(
            new SaleItem
            {
                Id = Guid.Parse("a07e4de7-d0bf-4706-bcc9-54d22f07b918"),
                Quantity = 10,
                Price = 3.59,
                TotalSaleItemAmount = 36.90,
                Discount = 10,
                TotalPriceDiscount = 33.21,
                SaleId = Guid.Parse("d38c0ac9-1dc4-4432-bfda-42fcaaa70b2d"),
                ProductId = Guid.Parse("230168d5-4fc4-499b-b67e-f8b04c901d85"),
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new SaleItem
            {
                Id = Guid.Parse("44151fb7-26d6-43fe-8c41-f35afe2b225a"),
                Quantity = 10,
                Price = 6.29,
                TotalSaleItemAmount = 62.90,
                Discount = 10,
                TotalPriceDiscount = 56.61,
                SaleId = Guid.Parse("d38c0ac9-1dc4-4432-bfda-42fcaaa70b2d"),
                ProductId = Guid.Parse("4ac72fff-c897-4126-ab19-dd2756451d96"),
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            },
            new SaleItem
            {
                Id = Guid.Parse("52a842c5-8312-4507-a597-29e1b542e873"),
                Quantity = 10,
                Price = 9.49,
                TotalSaleItemAmount = 94.90,
                Discount = 10,
                TotalPriceDiscount = 85.41,
                SaleId = Guid.Parse("d38c0ac9-1dc4-4432-bfda-42fcaaa70b2d"),
                ProductId = Guid.Parse("4c653cff-229f-48f7-abf5-c1cf66823093"),
                CreatedAt = DateTime.UtcNow,
                Status = Status.Active
            }
        );
        #endregion

    }

    public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        public DefaultContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DefaultContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseNpgsql(
                   connectionString,
                   b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.SalesApi")
            );

            return new DefaultContext(builder.Options);
        }
    }
}