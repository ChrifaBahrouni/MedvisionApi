using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedvisionApi.Migrations
{
    /// <inheritdoc />
    public partial class first1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "email", "name", "password", "phone", "photo_url" },
                values: new object[,]
                {
                    { 1, "chrifa.bahrouni@gmail.com", " chrifa bahrouni", "123456", "99828278", "https://www.google.com" },
                    { 2, "chrifa.bahrouni123@gmail.com", " chrifa ", "123456", "99828278", "https://www.google.com" },
                    { 3, "islem@gmail.com", " Islem", "123456", "99828278", "https://www.google.com" }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "countcomment", "countlike", "countshare", "description", "reserve", "time", "UserId" },
                values: new object[] { 3, 0, 0, 0, "islem@gmail.com", 0, 123456, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
