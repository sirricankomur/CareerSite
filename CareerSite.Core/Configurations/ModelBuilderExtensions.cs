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
                new Course() { CourseId = 1, Name = "Beden Dili", Url = "beden-dili", Price = 50, ImageUrl = "beden-dili.jpg", Description = "İlk izlenimde beden dili en önemlisidir.", IsApproved = true },
                new Course() { CourseId = 2, Name = "Etkili İletişim", Url = "etkili-iletisim", Price = 50, ImageUrl = "etkili-iletisim.jpg", Description = "Kendinizi iyi ifade etmenin yolları.", IsApproved = false },
                new Course() { CourseId = 3, Name = "C++", Url = "c++", Price = 100, ImageUrl = "cpp.jpg", Description = "Sıfırdan uzmanlığa C++ eğitimi", IsApproved = true },
                new Course() { CourseId = 4, Name = "Java", Url = "java", Price = 200, ImageUrl = "java.jpg", Description = "Sıfırdan uzmanlığa Java eğitimi", IsApproved = false },
                new Course() { CourseId = 5, Name = "ASP.Net Core", Url = "aspnet-core", Price = 200, ImageUrl = "aspnet-core.jpg", Description = "Sıfırdan uzmanlığa ASP.Net Core eğitimi", IsApproved = true },
                new Course() { CourseId = 6, Name = "Diksiyon", Url = "diksiyon", Price = 200, ImageUrl = "diksiyon.jpg", Description = "Dilinizi doğru kullanıyor musunuz?", IsApproved = true },
                new Course() { CourseId = 7, Name = "Python", Url = "python", Price = 150, ImageUrl = "python.jpg", Description = "Sıfırdan uzmanlığa Python eğitimi", IsApproved = true },
                new Course() { CourseId = 8, Name = "Kariyer Planlama", Url = "kariyer-planlama", Price = 20, ImageUrl = "kariyer-planlama.jpg", Description = "Hayata doğru adım atmanın yolları.", IsApproved = true },
                new Course() { CourseId = 9, Name = "Doğru Beslenme", Url = "dogru-beslenme", Price = 30, ImageUrl = "dogru-beslenme.jpg", Description = "Doğru beslenerek daha dinç hissedin.", IsApproved = true },
                new Course() { CourseId = 10, Name = "Şan", Url = "san", Price = 500, ImageUrl = "san.jpg", Description = "Sesinizi doğru kullanıyor musunuz?", IsApproved = true },
                new Course() { CourseId = 11, Name = "Ney", Url = "ney", Price = 200, ImageUrl = "ney.jpg", Description = "Neyin manevi sedasına dalın.", IsApproved = true },
                new Course() { CourseId = 12, Name = "Stresle Başa Çıkma", Url = "stresle-basa-cikma", Price = 50, ImageUrl = "stresle-basa-cikma.jpg", Description = "Stresinizle baş etmenin yolları", IsApproved = true },
                new Course() { CourseId = 13, Name = "Piyano", Url = "piyano", Price = 100, ImageUrl = "piyano.jpg", Description = "Piyano başlangıç kursu", IsApproved = true },
                new Course() { CourseId = 14, Name = "Yoga", Url = "yoga", Price = 500, ImageUrl = "yoga.jpg", Description = "Piyano başlangıç kursu", IsApproved = true }

                );

            builder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Name = "Yazılım", Url = "yazilim" },
                new Category() { CategoryId = 2, Name = "Sağlık", Url = "saglik" },
                new Category() { CategoryId = 3, Name = "Müzik", Url = "muzik" },
                new Category() { CategoryId = 4, Name = "Akademi", Url = "akademi" },
                new Category() { CategoryId = 5, Name = "Finans", Url = "finans" },
                new Category() { CategoryId = 6, Name = "Fotoğraf", Url = "fotograf" },
                new Category() { CategoryId = 7, Name = "İşletme", Url = "isletme" },
                new Category() { CategoryId = 8, Name = "Pazarlama", Url = "pazarlama" },
                new Category() { CategoryId = 9, Name = "Kişisel Gelişim", Url = "kisisel-gelisim" },
                new Category() { CategoryId = 10, Name = "Tasarım", Url = "tasarim" },
                new Category() { CategoryId = 11, Name = "BT", Url = "bt" },
                new Category() { CategoryId = 12, Name = "Yaşam Tarzı", Url = "yasam-tarzi" }

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
