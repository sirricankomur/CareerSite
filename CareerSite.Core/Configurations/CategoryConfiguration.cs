using CareerSite.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(m => m.CategoryId);

            builder.Property(m => m.NameTr).IsRequired().HasMaxLength(100);
            builder.Property(m => m.NameEn).IsRequired().HasMaxLength(100);

        }
    }
}
