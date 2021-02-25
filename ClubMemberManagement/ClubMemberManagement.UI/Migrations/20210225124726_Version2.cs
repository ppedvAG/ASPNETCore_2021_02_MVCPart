using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubMemberManagement.UI.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "MembershipFee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgeRule",
                table: "MembershipFee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearsInClub",
                table: "MembershipFee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearsInClubRule",
                table: "MembershipFee",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "MembershipFee");

            migrationBuilder.DropColumn(
                name: "AgeRule",
                table: "MembershipFee");

            migrationBuilder.DropColumn(
                name: "YearsInClub",
                table: "MembershipFee");

            migrationBuilder.DropColumn(
                name: "YearsInClubRule",
                table: "MembershipFee");
        }
    }
}
