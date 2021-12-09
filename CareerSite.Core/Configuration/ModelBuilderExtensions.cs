using CareerSite.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.Configuration
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                new Course() { CourseId = 1, Name = "Samsung S5", Url = "samsung-s5", Price = 2000, ImageUrl = "1.jpg", Description = "iyi telefon", IsApproved = true },
                new Course() { CourseId = 2, Name = "Samsung S6", Url = "samsung-s6", Price = 3000, ImageUrl = "2.jpg", Description = "iyi telefon", IsApproved = false },
                new Course() { CourseId = 3, Name = "Samsung S7", Url = "samsung-s7", Price = 4000, ImageUrl = "3.jpg", Description = "iyi telefon", IsApproved = true },
                new Course() { CourseId = 4, Name = "Samsung S8", Url = "samsung-s8", Price = 5000, ImageUrl = "4.jpg", Description = "iyi telefon", IsApproved = false },
                new Course() { CourseId = 5, Name = "Samsung S9", Url = "samsung-s9", Price = 6000, ImageUrl = "5.jpg", Description = "iyi telefon", IsApproved = true }
            );

            builder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Name = "Telefon", Url = "telefon" },
                new Category() { CategoryId = 2, Name = "Bilgisayar", Url = "bilgisayar" },
                new Category() { CategoryId = 3, Name = "Elektronik", Url = "elektronik" },
                new Category() { CategoryId = 4, Name = "Beyaz Eşya", Url = "beyaz-esya" }
            );

            builder.Entity<CourseCategory>().HasData(
                new CourseCategory() { CourseId = 1, CategoryId = 1 },
                new CourseCategory() { CourseId = 1, CategoryId = 2 },
                new CourseCategory() { CourseId = 1, CategoryId = 3 },
                new CourseCategory() { CourseId = 2, CategoryId = 1 },
                new CourseCategory() { CourseId = 2, CategoryId = 2 },
                new CourseCategory() { CourseId = 2, CategoryId = 3 },
                new CourseCategory() { CourseId = 3, CategoryId = 4 },
                new CourseCategory() { CourseId = 4, CategoryId = 3 },
                new CourseCategory() { CourseId = 5, CategoryId = 3 },
                new CourseCategory() { CourseId = 5, CategoryId = 1 }

           );
        }
    }
}
