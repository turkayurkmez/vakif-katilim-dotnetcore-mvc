using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Infrastructure.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Felsefe" },
                    { 2, "Psikoloji" },
                    { 3, "Edebiyat" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedDate", "Description", "DiscountRate", "GenreId", "ImageUrl", "IsDeleted", "Price", "Stock", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Cara Hunter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poloisiye-Kurgu", 0.2m, 3, "https://i.dr.com.tr/cache/154x170-0/originals/0002103875001-1.jpg", null, 210m, 0, "Felix'in evide ne oldu?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "N. Crawford", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psikoloji.....", 0.15m, 2, "https://i.dr.com.tr/cache/154x170-0/originals/0002103875001-1.jpg", null, 205m, 0, "Yılanlar Bahçesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Cara Hunter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poloisiye-Kurgu", 0.2m, 3, "https://i.dr.com.tr/cache/154x170-0/originals/0002103875001-1.jpg", null, 210m, 0, "Felix'in evide ne oldu 2?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Platon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Süper klitap", 0.15m, 1, "https://i.dr.com.tr/cache/154x170-0/originals/0002103875001-1.jpg", null, 110m, 0, "Sokrat'ın savunması", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Cara Hunter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poloisiye-Kurgu", 0.2m, 1, "https://i.dr.com.tr/cache/154x170-0/originals/0002103875001-1.jpg", null, 210m, 0, "Felix'in evide ne oldu?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Cara Hunter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poloisiye-Kurgu", 0.2m, 3, "https://i.dr.com.tr/cache/154x170-0/originals/0002103875001-1.jpg", null, 210m, 0, "Felix'in evide ne oldu?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Cara Hunter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poloisiye-Kurgu", 0.2m, 2, "https://i.dr.com.tr/cache/154x170-0/originals/0002103875001-1.jpg", null, 210m, 0, "Felix'in evide ne oldu?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
