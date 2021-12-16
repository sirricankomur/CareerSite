using CareerSite.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.Configurations
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                new Course() { CourseId = 1, NameTr = "Beden Dili", UrlTr = "beden-dili", DescriptionTr = "İlk izlenimde beden dili en önemlisidir.", NameEn = "Body Language", UrlEn = "body-language", DescriptionEn = "Body language is the most important at first impression.", Price = 50, ImageUrl = "beden-dili.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 2, NameTr = "Etkili İletişim", UrlTr = "etkili-iletisim", DescriptionTr = "Kendinizi iyi ifade etmenin yolları.", NameEn = "Effective communication", UrlEn = "effective-communication", DescriptionEn = "", Price = 50, ImageUrl = "etkili-iletisim.jpg", IsHome = true, IsApproved = false },
                new Course() { CourseId = 3, NameTr = "C++", UrlTr = "cpp", DescriptionTr = "Sıfırdan uzmanlığa C++ eğitimi", NameEn = "C++", UrlEn = "cpp", DescriptionEn = "C++ training from scratch to pro", Price = 100, ImageUrl = "cpp.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 4, NameTr = "Java", UrlTr = "java", DescriptionTr = "Sıfırdan uzmanlığa Java eğitimi", NameEn = "Java", UrlEn = "java", DescriptionEn = "Java training from scratch to pro", Price = 200, ImageUrl = "java.jpg", IsHome = true, IsApproved = false },
                new Course() { CourseId = 5, NameTr = "ASP.Net Core", UrlTr = "", DescriptionTr = "Sıfırdan uzmanlığa ASP.Net Core eğitimi", NameEn = "ASP.Net Core", UrlEn = "aspnet-core", DescriptionEn = "Asp.Net Core training from scratch to pro", Price = 200, ImageUrl = "aspnet-core.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 6, NameTr = "Diksiyon", UrlTr = "diksiyon", DescriptionTr = "Dilinizi doğru kullanıyor musunuz?", NameEn = "Diction", UrlEn = "diction", DescriptionEn = "Are you using your language correctly?", Price = 200, ImageUrl = "diksiyon.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 7, NameTr = "Python", UrlTr = "python", DescriptionTr = "Sıfırdan uzmanlığa Python eğitimi", NameEn = "Python", UrlEn = "python", DescriptionEn = "Python training from scratch to pro", Price = 150, ImageUrl = "python.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 8, NameTr = "Kariyer Planlama", UrlTr = "kariyer-planlama", DescriptionTr = "Hayata doğru adım atmanın yolları.", NameEn = "Career Planning", UrlEn = "Career-planning", DescriptionEn = "Ways to take a step towards life.", Price = 20, ImageUrl = "kariyer-planlama.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 9, NameTr = "Doğru Beslenme", UrlTr = "dogru-beslenme", DescriptionTr = "Doğru beslenerek daha dinç hissedin.", NameEn = "Proper Nutrition", UrlEn = "proper-nutrition", DescriptionEn = "Feel more vigorous by eating right.", Price = 30, ImageUrl = "dogru-beslenme.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 10, NameTr = "Şan", UrlTr = "san", DescriptionTr = "Sesinizi doğru kullanıyor musunuz?", NameEn = "Singing", UrlEn = "singing", DescriptionEn = "Are you using your voice correctly?", Price = 500, ImageUrl = "san.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 11, NameTr = "Ney", UrlTr = "ney", DescriptionTr = "Neyin manevi sedasına dalın.", NameEn = "Ney", UrlEn = "ney", DescriptionEn = "Dive into the spiritual sound of Ney.", Price = 200, ImageUrl = "ney.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 12, NameTr = "Stresle Başa Çıkma", UrlTr = "stresle-basa-cikma", DescriptionTr = "Stresinizle baş etmenin yolları", NameEn = "Coping with Stress", UrlEn = "Coping-with-Stress", DescriptionEn = "", Price = 50, ImageUrl = "stresle-basa-cikma.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 13, NameTr = "Piyano", UrlTr = "piyano", DescriptionTr = "Piyano başlangıç kursu", NameEn = "Piano", UrlEn = "piano", DescriptionEn = "Piano beginner course", Price = 100, ImageUrl = "piyano.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 14, NameTr = "Yoga", UrlTr = "yoga", DescriptionTr = "Yoga başlangıç kursu", NameEn = "Yoga", UrlEn = "yoga", DescriptionEn = "Yoga beginner course", Price = 500, ImageUrl = "yoga.jpg", IsHome = true, IsApproved = true }

                );

            builder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, NameTr = "Yazılım", UrlTr = "yazilim", NameEn = "Software", UrlEn = "Software" },
                new Category() { CategoryId = 2, NameTr = "Sağlık", UrlTr = "saglik", NameEn = "Health", UrlEn = "Health" },
                new Category() { CategoryId = 3, NameTr = "Müzik", UrlTr = "muzik", NameEn = "Music", UrlEn = "Music" },
                new Category() { CategoryId = 4, NameTr = "Akademi", UrlTr = "akademi", NameEn = "Academy", UrlEn = "Academy" },
                new Category() { CategoryId = 5, NameTr = "Finans", UrlTr = "finans", NameEn = "Finance", UrlEn = "Finance" },
                new Category() { CategoryId = 6, NameTr = "Fotoğraf", UrlTr = "fotograf", NameEn = "Photograph", UrlEn = "Photograph" },
                new Category() { CategoryId = 7, NameTr = "İşletme", UrlTr = "isletme", NameEn = "Management", UrlEn = "Management" },
                new Category() { CategoryId = 8, NameTr = "Pazarlama", UrlTr = "pazarlama", NameEn = "Marketing", UrlEn = "Marketing" },
                new Category() { CategoryId = 9, NameTr = "Kişisel Gelişim", UrlTr = "kisisel-gelisim", NameEn = "Self-Improvement", UrlEn = "self-improvement" },
                new Category() { CategoryId = 10, NameTr = "Tasarım", UrlTr = "tasarim", NameEn = "Design", UrlEn = "Design" },
                new Category() { CategoryId = 11, NameTr = "BT", UrlTr = "bt", NameEn = "IT", UrlEn = "it" },
                new Category() { CategoryId = 12, NameTr = "Yaşam Tarzı", UrlTr = "yasam-tarzi", NameEn = "Life Style", UrlEn = "Life-Style" }

            );

            builder.Entity<CourseCategory>().HasData(
                new CourseCategory() { CourseId = 1, CategoryId = 9 },
                new CourseCategory() { CourseId = 2, CategoryId = 9 },
                new CourseCategory() { CourseId = 3, CategoryId = 1 },
                new CourseCategory() { CourseId = 4, CategoryId = 1 },
                new CourseCategory() { CourseId = 5, CategoryId = 1 },
                new CourseCategory() { CourseId = 6, CategoryId = 9 },
                new CourseCategory() { CourseId = 7, CategoryId = 1 },
                new CourseCategory() { CourseId = 8, CategoryId = 4 },
                new CourseCategory() { CourseId = 8, CategoryId = 9 },
                new CourseCategory() { CourseId = 9, CategoryId = 2 },
                new CourseCategory() { CourseId = 10, CategoryId = 3 },
                new CourseCategory() { CourseId = 11, CategoryId = 3 },
                new CourseCategory() { CourseId = 12, CategoryId = 2 },
                new CourseCategory() { CourseId = 12, CategoryId = 9 },
                new CourseCategory() { CourseId = 13, CategoryId = 3 },
                new CourseCategory() { CourseId = 14, CategoryId = 12 }

           );
        }
    }
}
