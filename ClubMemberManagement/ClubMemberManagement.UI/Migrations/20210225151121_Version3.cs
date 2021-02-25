using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubMemberManagement.UI.Migrations
{
    public partial class Version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BetragZuZahlen",
                table: "MembershipPayment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "GiltAb",
                table: "MembershipFee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GiltBis",
                table: "MembershipFee",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BetragZuZahlen",
                table: "MembershipPayment");

            migrationBuilder.DropColumn(
                name: "GiltAb",
                table: "MembershipFee");

            migrationBuilder.DropColumn(
                name: "GiltBis",
                table: "MembershipFee");
        }
    }
}
