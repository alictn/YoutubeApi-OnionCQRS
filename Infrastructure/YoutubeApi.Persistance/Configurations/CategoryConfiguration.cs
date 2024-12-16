using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistance.Configurations
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
         public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new()
            {
                Id = 1,
                Name = "Electirik",
                Priority = 1,
                ParentId = 0,
                IsDeleted = false,
                CreateDate = DateTime.Now,
            };

            Category category2 = new()
            { Id = 1,Name = "Moda",Priority = 2,ParentId = 0,IsDeleted = false,CreateDate = DateTime.Now,};
            Category parent1 = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                Priority = 1,
                ParentId = category1.Id,
                IsDeleted = false,
                CreateDate = DateTime.Now,
            };

            Category parent2 = new()
            {
                Id = 4,
                Name = "Kadın",
                Priority =1,
                ParentId = 2,
                IsDeleted = false,
                CreateDate = DateTime.Now,
            };



        }
    }
}
