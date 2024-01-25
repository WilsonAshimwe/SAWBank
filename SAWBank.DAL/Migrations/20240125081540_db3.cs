using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAWBank.DAL.Migrations
{
    /// <inheritdoc />
    public partial class db3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"

                     INSERT INTO [dbo].[AccountCustomer]
                           ([AccountsId]
                           ,[CustomersId])
                     VALUES
                           (1,1),(2,1),(3,2),(4,3),(5,4),(6,5),(7,6)
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
