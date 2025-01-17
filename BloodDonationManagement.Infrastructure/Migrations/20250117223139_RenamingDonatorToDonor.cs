using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamingDonatorToDonor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Donators_DonatorId",
                table: "Donations");

            migrationBuilder.DropTable(
                name: "Donators");

            migrationBuilder.RenameColumn(
                name: "DonatorId",
                table: "Donations",
                newName: "DonorId");

            migrationBuilder.RenameIndex(
                name: "IX_Donations_DonatorId",
                table: "Donations",
                newName: "IX_Donations_DonorId");

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: false),
                    RhFactor = table.Column<int>(type: "int", nullable: false),
                    Address_PublicArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Donors_DonorId",
                table: "Donations",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Donors_DonorId",
                table: "Donations");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.RenameColumn(
                name: "DonorId",
                table: "Donations",
                newName: "DonatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Donations_DonorId",
                table: "Donations",
                newName: "IX_Donations_DonatorId");

            migrationBuilder.CreateTable(
                name: "Donators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RhFactor = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Address_Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Address_PublicArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donators", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Donators_DonatorId",
                table: "Donations",
                column: "DonatorId",
                principalTable: "Donators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
