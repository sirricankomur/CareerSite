using CareerSite.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.Configuration
{
    public class CourseCategoryConfiguration : IEntityTypeConfiguration<CourseCategory>
    {
        public void Configure(EntityTypeBuilder<CourseCategory> builder)
        {
            builder.HasKey(c => new { c.CategoryId, c.CourseId });
        }
    }
}
