using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SAWBank.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "varchar(150)", nullable: false),
                    City = table.Column<string>(type: "varchar(75)", nullable: false),
                    StreetNumber = table.Column<string>(type: "varchar(5)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "varchar(255)", nullable: true),
                    ZipCode = table.Column<string>(type: "char(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentBalance = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Email = table.Column<string>(type: "varchar(75)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberCard = table.Column<string>(type: "varchar(150)", nullable: false),
                    Pin = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DepositAccountId = table.Column<int>(type: "int", nullable: false),
                    WithdrawAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_DepositAccountId",
                        column: x => x.DepositAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_WithdrawAccountId",
                        column: x => x.WithdrawAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountCustomer",
                columns: table => new
                {
                    AccountsId = table.Column<int>(type: "int", nullable: false),
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCustomer", x => new { x.AccountsId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_AccountCustomer_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountCustomer_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    BusinessNumber = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Customers_Id",
                        column: x => x.Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Customers_Id",
                        column: x => x.Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AdditionalInfo", "City", "Street", "StreetNumber", "ZipCode" },
                values: new object[,]
                {
                    { 1, null, "Bruxelles", "Rue blablabla", "5", "1000" },
                    { 2, null, "Londre", "Rue nononono", "43B", "8513" },
                    { 3, null, "Bruxelles", "Rue hihihihi", "777", "3657" },
                    { 4, null, "Bruxelles", "Rue delhaize", "21", "1000" },
                    { 5, null, "Bruxelles", "Rue repository", "156", "1000" },
                    { 6, null, "Bruxelles", "Rue formation", "98a", "1000" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Email", "Image", "IsActive", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, 1, "stef@test.com", null, true, new byte[] { 72, 184, 29, 54, 101, 234, 221, 63, 181, 23, 191, 84, 109, 221, 56, 115, 5, 6, 141, 194, 143, 245, 166, 161, 20, 14, 248, 31, 247, 113, 132, 3, 140, 255, 202, 108, 29, 111, 228, 63, 99, 103, 33, 130, 144, 21, 105, 138, 7, 247, 206, 163, 194, 184, 131, 109, 80, 15, 109, 101, 20, 25, 230, 105 }, "+320413234567", "stef" },
                    { 2, 2, "wil@test.com", null, true, new byte[] { 55, 153, 21, 146, 139, 174, 49, 219, 41, 97, 132, 28, 255, 58, 33, 248, 142, 75, 152, 221, 22, 26, 94, 200, 108, 13, 99, 74, 121, 189, 211, 200, 60, 159, 13, 122, 159, 66, 251, 145, 29, 127, 12, 102, 167, 58, 38, 153, 165, 25, 143, 238, 37, 67, 179, 4, 67, 170, 230, 141, 22, 16, 226, 7 }, "+320423234789", "wil" },
                    { 3, 3, "ad@test.com", null, true, new byte[] { 21, 216, 127, 210, 33, 85, 249, 34, 145, 223, 67, 132, 67, 249, 232, 153, 89, 106, 126, 13, 242, 199, 211, 79, 254, 5, 228, 106, 188, 227, 181, 143, 202, 210, 93, 192, 202, 166, 215, 138, 55, 47, 192, 174, 75, 94, 222, 129, 176, 105, 51, 67, 128, 140, 85, 205, 135, 226, 238, 212, 105, 161, 235, 91 }, "+320473568123", "ad" },
                    { 4, 4, "delheize@supermarket.com", null, true, new byte[] { 169, 214, 2, 40, 69, 37, 241, 232, 9, 131, 182, 99, 72, 238, 75, 86, 85, 168, 70, 55, 38, 134, 138, 50, 214, 30, 254, 79, 165, 213, 77, 53, 188, 145, 149, 65, 36, 225, 53, 78, 195, 41, 241, 179, 177, 136, 217, 207, 53, 23, 232, 4, 234, 230, 12, 4, 150, 171, 29, 134, 145, 67, 212, 20 }, "+320489234321", "Delheize" },
                    { 5, 5, "github@info.com", null, true, new byte[] { 193, 198, 49, 69, 230, 250, 211, 107, 15, 215, 236, 43, 69, 34, 149, 196, 167, 10, 230, 19, 7, 24, 223, 91, 23, 209, 142, 125, 77, 159, 171, 83, 160, 39, 31, 140, 203, 215, 41, 62, 20, 175, 168, 175, 145, 157, 238, 202, 168, 241, 243, 30, 212, 15, 229, 216, 206, 77, 147, 78, 76, 197, 246, 46 }, "+320489234333", "Github" },
                    { 6, 6, "digitalcity@info.com", null, true, new byte[] { 192, 46, 211, 178, 84, 234, 9, 23, 241, 64, 250, 39, 173, 237, 202, 179, 141, 10, 223, 92, 215, 168, 209, 167, 100, 198, 57, 19, 96, 30, 173, 32, 74, 55, 46, 112, 182, 115, 148, 252, 132, 216, 74, 187, 57, 199, 141, 15, 95, 117, 87, 172, 110, 14, 133, 53, 202, 39, 32, 80, 95, 39, 22, 230 }, "+320489232222", "DC" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BusinessNumber", "Name" },
                values: new object[,]
                {
                    { 4, "BE 0123.456.789", "Delheize" },
                    { 5, "BE 3456.789.012", "Github" },
                    { 6, "BE 3210.987.654", "Digital City" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1900, 2, 16, 17, 13, 4, 374, DateTimeKind.Unspecified), "Stefania", "Méchante" },
                    { 2, new DateTime(1930, 5, 21, 17, 13, 4, 374, DateTimeKind.Unspecified), "Wilson", "Python Expert" },
                    { 3, new DateTime(1996, 7, 17, 17, 13, 4, 374, DateTimeKind.Unspecified), "Adam", "Number One" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountCustomer_CustomersId",
                table: "AccountCustomer",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountNumber",
                table: "Accounts",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TypeId",
                table: "Accounts",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AccountId",
                table: "Cards",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_NumberCard",
                table: "Cards",
                column: "NumberCard",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_BusinessNumber",
                table: "Companies",
                column: "BusinessNumber",
                unique: true,
                filter: "[BusinessNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Username",
                table: "Customers",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DepositAccountId",
                table: "Transactions",
                column: "DepositAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WithdrawAccountId",
                table: "Transactions",
                column: "WithdrawAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCustomer");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}
