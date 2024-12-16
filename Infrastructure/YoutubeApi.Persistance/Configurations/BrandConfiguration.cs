using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;


namespace YoutubeApi.Persistance.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);

            Faker faker = new("tr");
            Brand brand = new()
            {
                Id = 1,
                Name = faker.Commerce.Department(),
                CreateDate = DateTime.Now,
                IsDeleted = false,
            };
            Brand brand1 = new()
            {
                Id = 2,
                Name = faker.Commerce.Department(),
                CreateDate = DateTime.Now,
                IsDeleted = false
            };
            Brand brand2 = new Brand() { Id = 3, Name = faker.Commerce.Department(), CreateDate = DateTime.Now, IsDeleted = true };
            builder.HasData(brand, brand1, brand2);
        }
    }
}
