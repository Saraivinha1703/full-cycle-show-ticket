using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caticket.PartnerAPI.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingTenantId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Ticket",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Spot",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "ReservationHistory",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Event",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Spot");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ReservationHistory");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Event");
        }
    }
}
