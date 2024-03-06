using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Infrastructure.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class changeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Books",
                type: "bit",
                nullable: true);

            //migrationBuilder.UpdateData(
            //    table: "Books",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "IsActive",
            //    value: null);

            //migrationBuilder.UpdateData(
            //    table: "Books",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    column: "IsActive",
            //    value: null);

            //migrationBuilder.UpdateData(
            //    table: "Books",
            //    keyColumn: "Id",
            //    keyValue: 3,
            //    column: "IsActive",
            //    value: null);

            //migrationBuilder.UpdateData(
            //    table: "Books",
            //    keyColumn: "Id",
            //    keyValue: 4,
            //    column: "IsActive",
            //    value: null);

            //migrationBuilder.UpdateData(
            //    table: "Books",
            //    keyColumn: "Id",
            //    keyValue: 5,
            //    column: "IsActive",
            //    value: null);

            //migrationBuilder.UpdateData(
            //    table: "Books",
            //    keyColumn: "Id",
            //    keyValue: 6,
            //    column: "IsActive",
            //    value: null);

            //migrationBuilder.UpdateData(
            //    table: "Books",
            //    keyColumn: "Id",
            //    keyValue: 7,
            //    column: "IsActive",
            //    value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Books");
        }
    }
}
