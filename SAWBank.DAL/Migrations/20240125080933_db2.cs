using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SAWBank.DAL.Migrations
{
    /// <inheritdoc />
    public partial class db2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "CurrentBalance", "IsActive", "IsSuspended", "TypeId" },
                values: new object[,]
                {
                    { 1, "BE-22-1111-333-4444", 10000, true, false, 1 },
                    { 2, "BE-22-1111-333-5555", 500, true, false, 2 },
                    { 3, "BE-22-1111-333-4888", 400000, true, false, 1 },
                    { 4, "BE-22-1111-444-4444", 0, true, false, 1 },
                    { 5, "BE-22-1111-383-4444", 100000000, true, false, 1 },
                    { 6, "BE-24-1111-333-4444", 200000000, true, false, 1 },
                    { 7, "BE-22-1177-333-4444", 500, true, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "AccountId", "IsBlocked", "NumberCard", "Pin" },
                values: new object[,]
                {
                    { 1, 1, false, "0000-1234-5678-9012", new byte[] { 215, 137, 24, 209, 21, 50, 4, 74, 80, 37, 155, 22, 60, 194, 121, 21, 102, 122, 47, 131, 242, 98, 102, 27, 5, 154, 90, 26, 200, 214, 180, 88, 251, 216, 2, 44, 3, 180, 19, 94, 27, 183, 197, 48, 43, 218, 157, 35, 98, 241, 156, 47, 201, 193, 146, 241, 183, 54, 207, 108, 84, 73, 40, 73 } },
                    { 2, 3, false, "1111-1234-5678-9012", new byte[] { 144, 51, 53, 0, 119, 97, 239, 136, 81, 186, 226, 140, 69, 191, 220, 57, 196, 202, 144, 250, 65, 148, 33, 238, 159, 15, 55, 151, 181, 206, 124, 89, 134, 216, 10, 143, 37, 49, 191, 93, 199, 166, 237, 174, 114, 39, 0, 53, 212, 80, 237, 8, 143, 15, 208, 87, 254, 8, 95, 166, 183, 201, 177, 162 } },
                    { 3, 4, false, "2222-1234-5678-9012", new byte[] { 100, 110, 180, 94, 210, 96, 87, 11, 249, 247, 72, 68, 117, 157, 253, 70, 200, 80, 239, 193, 146, 4, 64, 95, 250, 175, 253, 2, 89, 201, 2, 21, 247, 54, 185, 142, 50, 134, 26, 157, 231, 114, 70, 17, 244, 95, 130, 200, 104, 180, 55, 140, 53, 123, 50, 110, 214, 53, 98, 149, 24, 109, 184, 64 } },
                    { 4, 5, false, "3333-1234-5678-9012", new byte[] { 250, 85, 102, 64, 30, 225, 232, 58, 85, 21, 38, 42, 251, 45, 158, 109, 55, 180, 16, 41, 16, 93, 84, 136, 169, 43, 172, 202, 34, 171, 6, 90, 14, 156, 180, 178, 150, 31, 109, 180, 117, 153, 175, 161, 43, 5, 83, 222, 8, 23, 149, 131, 49, 66, 167, 104, 14, 254, 183, 221, 100, 138, 95, 12 } },
                    { 5, 6, false, "4444-1234-5678-9012", new byte[] { 214, 62, 200, 103, 175, 171, 114, 79, 67, 173, 225, 223, 130, 208, 132, 26, 220, 137, 170, 175, 84, 184, 147, 125, 63, 130, 100, 6, 193, 226, 50, 36, 227, 241, 252, 4, 28, 48, 118, 124, 64, 16, 178, 158, 84, 183, 49, 77, 116, 0, 134, 245, 13, 94, 108, 15, 144, 68, 90, 45, 41, 16, 221, 208 } },
                    { 6, 7, false, "5555-1234-5678-9012", new byte[] { 102, 140, 224, 214, 109, 152, 170, 81, 77, 141, 91, 85, 247, 107, 228, 245, 92, 81, 196, 94, 166, 216, 9, 41, 239, 200, 103, 183, 142, 244, 56, 187, 164, 196, 130, 82, 146, 127, 31, 5, 42, 200, 240, 46, 161, 123, 209, 160, 70, 251, 71, 8, 144, 156, 170, 238, 66, 199, 159, 79, 135, 40, 75, 185 } }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
