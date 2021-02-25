using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubMemberManagement.UI.Migrations
{
    public partial class Version1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geburtstag = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vereinseintritt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Straße = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hausnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PLZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MembershipFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Betrag = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipFee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    MembershipFeeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembershipPayment_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembershipPayment_MembershipFee_MembershipFeeId",
                        column: x => x.MembershipFeeId,
                        principalTable: "MembershipFee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberPaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentHistory_MembershipPayment_MemberPaymentId",
                        column: x => x.MemberPaymentId,
                        principalTable: "MembershipPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembershipPayment_MemberId",
                table: "MembershipPayment",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipPayment_MembershipFeeId",
                table: "MembershipPayment",
                column: "MembershipFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistory_MemberPaymentId",
                table: "PaymentHistory",
                column: "MemberPaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentHistory");

            migrationBuilder.DropTable(
                name: "MembershipPayment");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "MembershipFee");
        }
    }
}
