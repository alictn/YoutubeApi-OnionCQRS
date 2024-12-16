using Microsoft.EntityFrameworkCore;
using YoutubeApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YoutubeApi.Persistance.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new Faker("tr");
            Detail detail1 = new()
            {
                Id = 1,
                Title = faker.Lorem.Sentence(4),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 1,
                CreateDate = DateTime.Now,
                IsDeleted = false,
            };
            Detail detail2 = new()
            {
                Id = 2,
                Title = faker.Lorem.Sentence(5),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 3,
                CreateDate = DateTime.Now,
                IsDeleted = false,
            };
            Detail detail3 = new()
            {
                Id = 3,
                Title = faker.Lorem.Sentence(5),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4,
                CreateDate = DateTime.Now,
                IsDeleted = false,
            };
            builder.HasData(detail1, detail2, detail3);
        }
    }
}
