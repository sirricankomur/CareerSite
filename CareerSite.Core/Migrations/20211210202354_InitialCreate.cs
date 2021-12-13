using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerSite.Core.Migrations
{
    public partial class InitialCreate : Migration
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                columns: new[] { "CategoryId", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Yazılım", "yazilim" },
                    { 12, "Yaşam Tarzı", "yasam-tarzi" },
                    { 11, "BT", "bt" },
                    { 10, "Tasarım", "tasarim" },
                    { 8, "Pazarlama", "pazarlama" },
                    { 7, "İşletme", "isletme" },
                    { 9, "Kişisel Gelişim", "kisisel-gelisim" },
                    { 5, "Finans", "finans" },
                    { 4, "Akademi", "akademi" },
                    { 3, "Müzik", "muzik" },
                    { 2, "Sağlık", "saglik" },
                    { 6, "Fotoğraf", "fotograf" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "ImageUrl", "IsApproved", "IsHome", "Name", "Price", "Url" },
                values: new object[,]
                {
                    { 8, "Hayata doğru adım atmanın yolları.", "5.jpg", true, false, "Kariyer Planlama", 20.0, "kariyer-planlama" },
                    { 12, "Stresinizle baş etmenin yolları", "5.jpg", true, false, "Stresle Başa Çıkma", 50.0, "stresle-basa-cikma" },
                    { 11, "Neyin manevi sedasına dalın.", "5.jpg", true, false, "Ney", 200.0, "ney" },
                    { 10, "Sesinizi doğru kullanıyor musunuz?", "5.jpg", true, false, "Şan", 500.0, "san" },
                    { 9, "Doğru beslenerek daha dinç hissedin.", "5.jpg", true, false, "Doğru Beslenme", 30.0, "dogru-beslenme" },
                    { 7, "Sıfırdan uzmanlığa Python eğitimi", "5.jpg", true, false, "Python", 150.0, "python" },
                    { 1, "İlk izlenimde beden dili en önemlisidir.", "1.jpg", true, false, "Beden Dili", 50.0, "beden-dili" },
                    { 5, "Sıfırdan uzmanlığa ASP.Net Core eğitimi", "5.jpg", true, false, "ASP.Net Core", 200.0, "aspnet-core" },
                    { 4, "Sıfırdan uzmanlığa Java eğitimi", "4.jpg", false, false, "Java", 200.0, "java" },
                    { 3, "Sıfırdan uzmanlığa C++ eğitimi", "3.jpg", true, false, "C++", 100.0, "c++" },
                    { 2, "Kendinizi iyi ifade etmenin yolları.", "2.jpg", false, false, "Etkili İletişim", 50.0, "etkili-iletisim" },
                    { 13, "Piyano başlangıç kursu", "5.jpg", true, false, "Piyano", 100.0, "piyano" },
                    { 6, "Dilinizi doğru kullanıyor musunuz?", "5.jpg", true, false, "Diksiyon", 200.0, "diksiyon" },
                    { 14, "Piyano başlangıç kursu", "5.jpg", true, false, "Yoga", 500.0, "yoga" }
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
