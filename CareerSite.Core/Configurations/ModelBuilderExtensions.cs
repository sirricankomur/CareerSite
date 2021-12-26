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
                new Course() { CourseId = 1, NameTr = "Beden Dili", Url = "beden-dili", DescriptionTr = "İlk izlenimde beden dili en önemlisidir.", NameEn = "Body Language", DescriptionEn = "Body language is the most important at first impression.", Price = 50, ImageUrl = "beden-dili.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 2, NameTr = "Etkili İletişim", Url = "etkili-iletisim", DescriptionTr = "Kendinizi iyi ifade etmenin yolları.", NameEn = "Effective communication", DescriptionEn = "Ways to express yourself well.", Price = 50, ImageUrl = "etkili-iletisim.jpg", IsHome = true, IsApproved = false },
                new Course() { CourseId = 3, NameTr = "C++", Url = "cpp", DescriptionTr = "Sıfırdan uzmanlığa C++ eğitimi", NameEn = "C++", DescriptionEn = "C++ training from scratch to pro", Price = 100, ImageUrl = "cpp.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 4, NameTr = "Java", Url = "java", DescriptionTr = "Sıfırdan uzmanlığa Java eğitimi", NameEn = "Java", DescriptionEn = "Java training from scratch to pro", Price = 200, ImageUrl = "java.jpg", IsHome = true, IsApproved = false },
                new Course() { CourseId = 5, NameTr = "ASP.Net Core", Url = "", DescriptionTr = "Sıfırdan uzmanlığa ASP.Net Core eğitimi", NameEn = "ASP.Net Core", DescriptionEn = "Asp.Net Core training from scratch to pro", Price = 200, ImageUrl = "aspnet-core.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 6, NameTr = "Diksiyon", Url = "diksiyon", DescriptionTr = "Dilinizi doğru kullanıyor musunuz?", NameEn = "Diction", DescriptionEn = "Are you using your language correctly?", Price = 200, ImageUrl = "diksiyon.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 7, NameTr = "Python", Url = "python", DescriptionTr = "Sıfırdan uzmanlığa Python eğitimi", NameEn = "Python", DescriptionEn = "Python training from scratch to pro", Price = 150, ImageUrl = "python.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 8, NameTr = "Kariyer Planlama", Url = "kariyer-planlama", DescriptionTr = "Hayata doğru adım atmanın yolları.", NameEn = "Career Planning", DescriptionEn = "Ways to take a step towards life.", Price = 20, ImageUrl = "kariyer-planlama.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 9, NameTr = "Doğru Beslenme", Url = "dogru-beslenme", DescriptionTr = "Doğru beslenerek daha dinç hissedin.", NameEn = "Proper Nutrition", DescriptionEn = "Feel more vigorous by eating right.", Price = 30, ImageUrl = "dogru-beslenme.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 10, NameTr = "Şan", Url = "san", DescriptionTr = "Sesinizi doğru kullanıyor musunuz?", NameEn = "Singing", DescriptionEn = "Are you using your voice correctly?", Price = 500, ImageUrl = "san.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 11, NameTr = "Ney", Url = "ney", DescriptionTr = "Neyin manevi sedasına dalın.", NameEn = "Ney", DescriptionEn = "Dive into the spiritual sound of Ney.", Price = 200, ImageUrl = "ney.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 12, NameTr = "Stresle Başa Çıkma", Url = "stresle-basa-cikma", DescriptionTr = "Stresinizle baş etmenin yolları", NameEn = "Coping with Stress", DescriptionEn = "Ways to deal with your stress", Price = 50, ImageUrl = "stresle-basa-cikma.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 13, NameTr = "Piyano", Url = "piyano", DescriptionTr = "Piyano başlangıç kursu", NameEn = "Piano", DescriptionEn = "Piano beginner course", Price = 100, ImageUrl = "piyano.jpg", IsHome = true, IsApproved = true },
                new Course() { CourseId = 14, NameTr = "Yoga", Url = "yoga", DescriptionTr = "Yoga başlangıç kursu", NameEn = "Yoga", DescriptionEn = "Yoga beginner course", Price = 500, ImageUrl = "yoga.jpg", IsHome = true, IsApproved = true }

                );

            builder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, NameTr = "Yazılım", Url = "yazilim", NameEn = "Software" },
                new Category() { CategoryId = 2, NameTr = "Sağlık", Url = "saglik", NameEn = "Health" },
                new Category() { CategoryId = 3, NameTr = "Müzik", Url = "muzik", NameEn = "Music" },
                new Category() { CategoryId = 4, NameTr = "Akademi", Url = "akademi", NameEn = "Academy" },
                new Category() { CategoryId = 5, NameTr = "Finans", Url = "finans", NameEn = "Finance" },
                new Category() { CategoryId = 6, NameTr = "Fotoğraf", Url = "fotograf", NameEn = "Photograph" },
                new Category() { CategoryId = 7, NameTr = "İşletme", Url = "isletme", NameEn = "Management" },
                new Category() { CategoryId = 8, NameTr = "Pazarlama", Url = "pazarlama", NameEn = "Marketing" },
                new Category() { CategoryId = 9, NameTr = "Kişisel Gelişim", Url = "kisisel-gelisim", NameEn = "Self-Improvement" },
                new Category() { CategoryId = 10, NameTr = "Tasarım", Url = "tasarim", NameEn = "Design" },
                new Category() { CategoryId = 11, NameTr = "BT", Url = "bt", NameEn = "IT" },
                new Category() { CategoryId = 12, NameTr = "Yaşam Tarzı", Url = "yasam-tarzi", NameEn = "Life Style" }

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
