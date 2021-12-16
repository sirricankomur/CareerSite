using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerSite.Core.Migrations
{
    public partial class NameTr : Migration
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
                    UrlTr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    UrlTr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                columns: new[] { "CategoryId", "NameEn", "NameTr", "UrlEn", "UrlTr" },
                values: new object[,]
                {
                    { 1, "Software", "Yazılım", "Software", "yazilim" },
                    { 12, "Life Style", "Yaşam Tarzı", "Life-Style", "yasam-tarzi" },
                    { 11, "IT", "BT", "it", "bt" },
                    { 10, "Design", "Tasarım", "Design", "tasarim" },
                    { 8, "Marketing", "Pazarlama", "Marketing", "pazarlama" },
                    { 7, "Management", "İşletme", "Management", "isletme" },
                    { 9, "Self-Improvement", "Kişisel Gelişim", "self-improvement", "kisisel-gelisim" },
                    { 5, "Finance", "Finans", "Finance", "finans" },
                    { 4, "Academy", "Akademi", "Academy", "akademi" },
                    { 3, "Music", "Müzik", "Music", "muzik" },
                    { 2, "Health", "Sağlık", "Health", "saglik" },
                    { 6, "Photograph", "Fotoğraf", "Photograph", "fotograf" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "DescriptionEn", "DescriptionTr", "ImageUrl", "IsApproved", "IsHome", "NameEn", "NameTr", "Price", "UrlEn", "UrlTr" },
                values: new object[,]
                {
                    { 8, "Ways to take a step towards life.", "Hayata doğru adım atmanın yolları.", "kariyer-planlama.jpg", true, false, "Career Planning", "Kariyer Planlama", 20.0, "Career-planning", "kariyer-planlama" },
                    { 12, "", "Stresinizle baş etmenin yolları", "stresle-basa-cikma.jpg", true, false, "Coping with Stress", "Stresle Başa Çıkma", 50.0, "Coping-with-Stress", "stresle-basa-cikma" },
                    { 11, "Dive into the spiritual sound of Ney.", "Neyin manevi sedasına dalın.", "ney.jpg", true, false, "Ney", "Ney", 200.0, "ney", "ney" },
                    { 10, "Are you using your voice correctly?", "Sesinizi doğru kullanıyor musunuz?", "san.jpg", true, false, "Singing", "Şan", 500.0, "singing", "san" },
                    { 9, "Feel more vigorous by eating right.", "Doğru beslenerek daha dinç hissedin.", "dogru-beslenme.jpg", true, false, "Proper Nutrition", "Doğru Beslenme", 30.0, "proper-nutrition", "dogru-beslenme" },
                    { 7, "Python training from scratch to pro", "Sıfırdan uzmanlığa Python eğitimi", "python.jpg", true, false, "Python", "Python", 150.0, "python", "python" },
                    { 1, "Body language is the most important at first impression.", "İlk izlenimde beden dili en önemlisidir.", "beden-dili.jpg", true, false, "Body Language", "Beden Dili", 50.0, "body-language", "beden-dili" },
                    { 5, "Asp.Net Core training from scratch to pro", "Sıfırdan uzmanlığa ASP.Net Core eğitimi", "aspnet-core.jpg", true, false, "ASP.Net Core", "ASP.Net Core", 200.0, "aspnet-core", "" },
                    { 4, "Java training from scratch to pro", "Sıfırdan uzmanlığa Java eğitimi", "java.jpg", false, false, "Java", "Java", 200.0, "java", "java" },
                    { 3, "C++ training from scratch to pro", "Sıfırdan uzmanlığa C++ eğitimi", "cpp.jpg", true, false, "C++", "C++", 100.0, "cpp", "cpp" },
                    { 2, "", "Kendinizi iyi ifade etmenin yolları.", "etkili-iletisim.jpg", false, false, "Effective communication", "Etkili İletişim", 50.0, "effective-communication", "etkili-iletisim" },
                    { 13, "Piano beginner course", "Piyano başlangıç kursu", "piyano.jpg", true, false, "Piano", "Piyano", 100.0, "piano", "piyano" },
                    { 6, "Are you using your language correctly?", "Dilinizi doğru kullanıyor musunuz?", "diksiyon.jpg", true, false, "Diction", "Diksiyon", 200.0, "diction", "diksiyon" },
                    { 14, "Yoga beginner course", "Yoga başlangıç kursu", "yoga.jpg", true, false, "Yoga", "Yoga", 500.0, "yoga", "yoga" }
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
