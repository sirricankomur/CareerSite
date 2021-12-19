using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerSite.Core.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    DescriptionTr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    RecordState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategory", x => new { x.CategoryId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCategory_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordItems_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordItems_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "NameEn", "NameTr", "Url" },
                values: new object[,]
                {
                    { 1, "Software", "Yazılım", "yazilim" },
                    { 12, "Life Style", "Yaşam Tarzı", "yasam-tarzi" },
                    { 11, "IT", "BT", "bt" },
                    { 10, "Design", "Tasarım", "tasarim" },
                    { 8, "Marketing", "Pazarlama", "pazarlama" },
                    { 7, "Management", "İşletme", "isletme" },
                    { 9, "Self-Improvement", "Kişisel Gelişim", "kisisel-gelisim" },
                    { 5, "Finance", "Finans", "finans" },
                    { 4, "Academy", "Akademi", "akademi" },
                    { 3, "Music", "Müzik", "muzik" },
                    { 2, "Health", "Sağlık", "saglik" },
                    { 6, "Photograph", "Fotoğraf", "fotograf" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "DescriptionEn", "DescriptionTr", "ImageUrl", "IsApproved", "IsHome", "NameEn", "NameTr", "Price", "Url" },
                values: new object[,]
                {
                    { 8, "Ways to take a step towards life.", "Hayata doğru adım atmanın yolları.", "kariyer-planlama.jpg", true, true, "Career Planning", "Kariyer Planlama", 20.0, "kariyer-planlama" },
                    { 12, "", "Stresinizle baş etmenin yolları", "stresle-basa-cikma.jpg", true, true, "Coping with Stress", "Stresle Başa Çıkma", 50.0, "stresle-basa-cikma" },
                    { 11, "Dive into the spiritual sound of Ney.", "Neyin manevi sedasına dalın.", "ney.jpg", true, true, "Ney", "Ney", 200.0, "ney" },
                    { 10, "Are you using your voice correctly?", "Sesinizi doğru kullanıyor musunuz?", "san.jpg", true, true, "Singing", "Şan", 500.0, "san" },
                    { 9, "Feel more vigorous by eating right.", "Doğru beslenerek daha dinç hissedin.", "dogru-beslenme.jpg", true, true, "Proper Nutrition", "Doğru Beslenme", 30.0, "dogru-beslenme" },
                    { 7, "Python training from scratch to pro", "Sıfırdan uzmanlığa Python eğitimi", "python.jpg", true, true, "Python", "Python", 150.0, "python" },
                    { 1, "Body language is the most important at first impression.", "İlk izlenimde beden dili en önemlisidir.", "beden-dili.jpg", true, true, "Body Language", "Beden Dili", 50.0, "beden-dili" },
                    { 5, "Asp.Net Core training from scratch to pro", "Sıfırdan uzmanlığa ASP.Net Core eğitimi", "aspnet-core.jpg", true, true, "ASP.Net Core", "ASP.Net Core", 200.0, "" },
                    { 4, "Java training from scratch to pro", "Sıfırdan uzmanlığa Java eğitimi", "java.jpg", false, true, "Java", "Java", 200.0, "java" },
                    { 3, "C++ training from scratch to pro", "Sıfırdan uzmanlığa C++ eğitimi", "cpp.jpg", true, true, "C++", "C++", 100.0, "cpp" },
                    { 2, "", "Kendinizi iyi ifade etmenin yolları.", "etkili-iletisim.jpg", false, true, "Effective communication", "Etkili İletişim", 50.0, "etkili-iletisim" },
                    { 13, "Piano beginner course", "Piyano başlangıç kursu", "piyano.jpg", true, true, "Piano", "Piyano", 100.0, "piyano" },
                    { 6, "Are you using your language correctly?", "Dilinizi doğru kullanıyor musunuz?", "diksiyon.jpg", true, true, "Diction", "Diksiyon", 200.0, "diksiyon" },
                    { 14, "Yoga beginner course", "Yoga başlangıç kursu", "yoga.jpg", true, true, "Yoga", "Yoga", 500.0, "yoga" }
                });

            migrationBuilder.InsertData(
                table: "CourseCategory",
                columns: new[] { "CategoryId", "CourseId" },
                values: new object[,]
                {
                    { 9, 1 },
                    { 9, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 9, 6 },
                    { 1, 7 },
                    { 4, 8 },
                    { 9, 8 },
                    { 2, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 2, 12 },
                    { 9, 12 },
                    { 3, 13 },
                    { 12, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CourseId",
                table: "CartItems",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategory_CourseId",
                table: "CourseCategory",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordItems_CourseId",
                table: "RecordItems",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordItems_RecordId",
                table: "RecordItems",
                column: "RecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CourseCategory");

            migrationBuilder.DropTable(
                name: "RecordItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
