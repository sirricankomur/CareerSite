﻿// <auto-generated />
using System;
using CareerSite.Core.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CareerSite.Core.Migrations
{
    [DbContext(typeof(CareerContext))]
    partial class CareerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CareerSite.Entity.Concrete.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CourseId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Yazılım",
                            Url = "yazilim"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Sağlık",
                            Url = "saglik"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Müzik",
                            Url = "muzik"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Akademi",
                            Url = "akademi"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Finans",
                            Url = "finans"
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "Fotoğraf",
                            Url = "fotograf"
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "İşletme",
                            Url = "isletme"
                        },
                        new
                        {
                            CategoryId = 8,
                            Name = "Pazarlama",
                            Url = "pazarlama"
                        },
                        new
                        {
                            CategoryId = 9,
                            Name = "Kişisel Gelişim",
                            Url = "kisisel-gelisim"
                        },
                        new
                        {
                            CategoryId = 10,
                            Name = "Tasarım",
                            Url = "tasarim"
                        },
                        new
                        {
                            CategoryId = 11,
                            Name = "BT",
                            Url = "bt"
                        },
                        new
                        {
                            CategoryId = 12,
                            Name = "Yaşam Tarzı",
                            Url = "yasam-tarzi"
                        });
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHome")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "İlk izlenimde beden dili en önemlisidir.",
                            ImageUrl = "1.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Beden Dili",
                            Price = 50.0,
                            Url = "beden-dili"
                        },
                        new
                        {
                            CourseId = 2,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Kendinizi iyi ifade etmenin yolları.",
                            ImageUrl = "2.jpg",
                            IsApproved = false,
                            IsHome = false,
                            Name = "Etkili İletişim",
                            Price = 50.0,
                            Url = "etkili-iletisim"
                        },
                        new
                        {
                            CourseId = 3,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sıfırdan uzmanlığa C++ eğitimi",
                            ImageUrl = "3.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "C++",
                            Price = 100.0,
                            Url = "c++"
                        },
                        new
                        {
                            CourseId = 4,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sıfırdan uzmanlığa Java eğitimi",
                            ImageUrl = "4.jpg",
                            IsApproved = false,
                            IsHome = false,
                            Name = "Java",
                            Price = 200.0,
                            Url = "java"
                        },
                        new
                        {
                            CourseId = 5,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sıfırdan uzmanlığa ASP.Net Core eğitimi",
                            ImageUrl = "5.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "ASP.Net Core",
                            Price = 200.0,
                            Url = "aspnet-core"
                        },
                        new
                        {
                            CourseId = 6,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Dilinizi doğru kullanıyor musunuz?",
                            ImageUrl = "5.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Diksiyon",
                            Price = 200.0,
                            Url = "diksiyon"
                        },
                        new
                        {
                            CourseId = 7,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sıfırdan uzmanlığa Python eğitimi",
                            ImageUrl = "5.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Python",
                            Price = 150.0,
                            Url = "python"
                        },
                        new
                        {
                            CourseId = 8,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Hayata doğru adım atmanın yolları.",
                            ImageUrl = "5.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Kariyer Planlama",
                            Price = 20.0,
                            Url = "kariyer-planlama"
                        },
                        new
                        {
                            CourseId = 9,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Doğru beslenerek daha dinç hissedin.",
                            ImageUrl = "5.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Doğru Beslenme",
                            Price = 30.0,
                            Url = "dogru-beslenme"
                        },
                        new
                        {
                            CourseId = 10,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sesinizi doğru kullanıyor musunuz?",
                            ImageUrl = "5.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Şan",
                            Price = 500.0,
                            Url = "san"
                        },
                        new
                        {
                            CourseId = 11,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Neyin manevi sedasına dalın.",
                            ImageUrl = "5.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Ney",
                            Price = 200.0,
                            Url = "ney"
                        },
                        new
                        {
                            CourseId = 12,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Stresinizle baş etmenin yolları",
                            ImageUrl = "5.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Stresle Başa Çıkma",
                            Price = 50.0,
                            Url = "stresle-basa-cikma"
                        },
                        new
                        {
                            CourseId = 13,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Piyano başlangıç kursu",
                            ImageUrl = "5.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Piyano",
                            Price = 100.0,
                            Url = "piyano"
                        },
                        new
                        {
                            CourseId = 14,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Piyano başlangıç kursu",
                            ImageUrl = "5.jpg",
                            IsApproved = true,
                            IsHome = false,
                            Name = "Yoga",
                            Price = 500.0,
                            Url = "yoga"
                        });
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.CourseCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseCategory");

                    b.HasData(
                        new
                        {
                            CategoryId = 9,
                            CourseId = 1
                        },
                        new
                        {
                            CategoryId = 9,
                            CourseId = 2
                        },
                        new
                        {
                            CategoryId = 1,
                            CourseId = 3
                        },
                        new
                        {
                            CategoryId = 1,
                            CourseId = 4
                        },
                        new
                        {
                            CategoryId = 1,
                            CourseId = 5
                        },
                        new
                        {
                            CategoryId = 9,
                            CourseId = 6
                        },
                        new
                        {
                            CategoryId = 1,
                            CourseId = 7
                        },
                        new
                        {
                            CategoryId = 4,
                            CourseId = 8
                        },
                        new
                        {
                            CategoryId = 9,
                            CourseId = 8
                        },
                        new
                        {
                            CategoryId = 2,
                            CourseId = 9
                        },
                        new
                        {
                            CategoryId = 3,
                            CourseId = 10
                        },
                        new
                        {
                            CategoryId = 3,
                            CourseId = 11
                        },
                        new
                        {
                            CategoryId = 2,
                            CourseId = 12
                        },
                        new
                        {
                            CategoryId = 9,
                            CourseId = 12
                        },
                        new
                        {
                            CategoryId = 3,
                            CourseId = 13
                        },
                        new
                        {
                            CategoryId = 12,
                            CourseId = 14
                        });
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConversationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RecordNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecordState")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.RecordItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RecordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("RecordId");

                    b.ToTable("RecordItems");
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.CartItem", b =>
                {
                    b.HasOne("CareerSite.Entity.Concrete.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerSite.Entity.Concrete.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.CourseCategory", b =>
                {
                    b.HasOne("CareerSite.Entity.Concrete.Category", "Category")
                        .WithMany("CourseCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerSite.Entity.Concrete.Course", "Course")
                        .WithMany("CourseCategories")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.RecordItem", b =>
                {
                    b.HasOne("CareerSite.Entity.Concrete.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerSite.Entity.Concrete.Record", "Record")
                        .WithMany("RecordItems")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.Category", b =>
                {
                    b.Navigation("CourseCategories");
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.Course", b =>
                {
                    b.Navigation("CourseCategories");
                });

            modelBuilder.Entity("CareerSite.Entity.Concrete.Record", b =>
                {
                    b.Navigation("RecordItems");
                });
#pragma warning restore 612, 618
        }
    }
}