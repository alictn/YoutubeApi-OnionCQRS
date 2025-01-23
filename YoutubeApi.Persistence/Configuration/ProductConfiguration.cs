using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new Faker();

            Product product1 = new()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 1,//Brand'in içinden direkt almaya çalış
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Random.Decimal(10, 1000),
                CreatedDate = DateTime.Now,
                IsDeleted = true,
            };

            Product product2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 3,//Brand'in içinden direkt almaya çalış
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Random.Decimal(10, 1000),
                CreatedDate = DateTime.Now,
                IsDeleted = true,
            };
            builder.HasData(product1, product2);
        }
    }
}
