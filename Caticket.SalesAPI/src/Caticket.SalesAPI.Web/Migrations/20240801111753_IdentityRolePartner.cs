using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caticket.SalesAPI.Web.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRolePartner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8590def-4132-4495-9bb9-b1f19c4e03c1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73780cda-0757-4253-97fe-0277a4f9f9f9", null, "partner", "PARTNER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73780cda-0757-4253-97fe-0277a4f9f9f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8590def-4132-4495-9bb9-b1f19c4e03c1", null, "partner", null });
        }
    }
}
