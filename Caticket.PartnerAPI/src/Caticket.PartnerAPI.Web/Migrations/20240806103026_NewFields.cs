using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caticket.PartnerAPI.Web.Migrations
{
    /// <inheritdoc />
    public partial class NewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ReservationHistory");

            migrationBuilder.RenameColumn(
                name: "TicketKind",
                table: "Ticket",
                newName: "TicketType");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Spot",
                newName: "SpotStatus");

            migrationBuilder.RenameColumn(
                name: "TicketKind",
                table: "ReservationHistory",
                newName: "TicketType");

            migrationBuilder.AddColumn<string>(
                name: "OwnerLegalId",
                table: "Ticket",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "ReservationHistory",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OwnerLegalId",
                table: "ReservationHistory",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SpotName",
                table: "ReservationHistory",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Event",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Event",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "Event",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerLegalId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "ReservationHistory");

            migrationBuilder.DropColumn(
                name: "OwnerLegalId",
                table: "ReservationHistory");

            migrationBuilder.DropColumn(
                name: "SpotName",
                table: "ReservationHistory");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "TicketType",
                table: "Ticket",
                newName: "TicketKind");

            migrationBuilder.RenameColumn(
                name: "SpotStatus",
                table: "Spot",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "TicketType",
                table: "ReservationHistory",
                newName: "TicketKind");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ReservationHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
