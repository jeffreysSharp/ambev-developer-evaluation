using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;
using System.Xml.Linq;

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

        #region Insert Products        
        modelBuilder.Entity<Product>().HasData(

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Guaraná Antarctica Zero",
                Description = "Guaraná Antarctica Zero 350ml Lata",
                Price = 3.39,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Pepsi Black 350ml",
                Description = "Pepsi Black 350ml Lata",
                Price = 2.69,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Guaraná Antarctica Zero",
                Description = "Guaraná Antarctica Zero 2L",
                Price = 9.49,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Guaraná Antarctica",
                Description = "Guaraná Antarctica 2L",
                Price = 9.49,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Guaraná Antarctica 350ml",
                Description = "Guaraná Antarctica 350ml Lata",
                Price = 3.39,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sukita 2L",
                Description = "Sukita 2L",
                Price = 6.29,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Soda Antarctica 350ml",
                Description = "Soda Antarctica 350ml",
                Price = 2.99,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Pepsi Twist 350ml",
                Description = "Pepsi Twist 350ml",
                Price = 2.99,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Soda Antarctica Zero 2L",
                Description = "Soda Antarctica Zero 2L",
                Price = 8.19,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Tônica Antarctica 350ml",
                Description = "Tônica Antarctica 350ml",
                Price = 3.59,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Tônica Antarctica 350ml",
                Description = "Tônica Antarctica 350ml",
                Price = 3.59,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Tônica Antarctica Gengibre 269ml",
                Description = "Tônica Antarctica Gengibre 269ml",
                Price = 2.69,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sukita Uva 350ml",
                Description = "Sukita Uva 350ml",
                Price = 2.99,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sukita 1L",
                Description = "Sukita 1L",
                Price = 4.89,
                Image = "image.jpg",
                Stock = 100,
                CreatedAt = DateTime.UtcNow,
                Active = true
            }
        );
        #endregion

        #region Insert Customers
        modelBuilder.Entity<Customer>().HasData(

            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Archie Meckiff",
                Email = "ameckiff1@icio.us",
                Phone = "1251145281",
                SocialNumber = "117-25-1588",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Bethina Petracek",
                Email = "bpetracek2@dagondesign.com",
                Phone = "2784864410",
                SocialNumber = "807-31-1052",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Eloise Simmons",
                Email = "esimmons3@webeden.co.uk",
                Phone = "5673473269",
                SocialNumber = "687-16-2264",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Phyllys Pillman",
                Email = "ppillman4@parallels.com",
                Phone = "4453959379",
                SocialNumber = "512-17-6944",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Hildagarde O'Deoran",
                Email = "hodeoran5@about.com",
                Phone = "4707864856",
                SocialNumber = "457-86-4530",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Binnie Aulsford",
                Email = "baulsford6@goo.gl",
                Phone = "9814345966",
                SocialNumber = "552-29-4372",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Leonid Cranney",
                Email = "lcranney7@walmart.com",
                Phone = "7247173033",
                SocialNumber = "523-53-3047",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Robinett McClary",
                Email = "rmcclary8@nbcnews.com",
                Phone = "6461435318",
                SocialNumber = "884-29-8560",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Barbra Lujan",
                Email = "blujan9@exblog.jp",
                Phone = "3958797276",
                SocialNumber = "314-65-1589",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            }
        );
        #endregion

        #region Insert  Sales Branch
        modelBuilder.Entity<SalesBranch>().HasData(

            new SalesBranch
            {
                Id = Guid.NewGuid(),
                Name = "Camaçari",
                State = "BA",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new SalesBranch
            {
                Id = Guid.NewGuid(),
                Name = "Caruaru",
                State = "PE",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new SalesBranch
            {
                Id = Guid.NewGuid(),
                Name = "Contagem",
                State = "MG",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new SalesBranch
            {
                Id = Guid.NewGuid(),
                Name = "Curitiba",
                State = "PR",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new SalesBranch
            {
                Id = Guid.NewGuid(),
                Name = "Guarulhos",
                State = "SP",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new SalesBranch
            {
                Id = Guid.NewGuid(),
                Name = "Itajáí",
                State = "SC",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new SalesBranch
            {
                Id = Guid.NewGuid(),
                Name = "Itapissuma",
                State = "PE",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new SalesBranch
            {
                Id = Guid.NewGuid(),
                Name = "Jacareí",
                State = "SP",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new SalesBranch
            {
                Id = Guid.NewGuid(),
                Name = "Jaguariúna",
                State = "SP",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            },
            new SalesBranch
            {
                Id = Guid.NewGuid(),
                Name = "Jundiaí",
                State = "SP",
                CreatedAt = DateTime.UtcNow,
                Active = true,
            }
         );
        #endregion
    }
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
               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
        );

        return new DefaultContext(builder.Options);
    }
}