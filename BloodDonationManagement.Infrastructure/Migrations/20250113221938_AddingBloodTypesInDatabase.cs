using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingBloodTypesInDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"""
                  INSERT INTO BloodStocks(Id, BloodType, RhFactor, Quantity)
                  VALUES(NEWID(), 1, 1, 0);

                  INSERT INTO BloodStocks(Id, BloodType, RhFactor, Quantity)
                  VALUES(NEWID(), 1, 2, 0);

                  INSERT INTO BloodStocks(Id, BloodType, RhFactor, Quantity)
                  VALUES(NEWID(), 2, 1, 0);

                  INSERT INTO BloodStocks(Id, BloodType, RhFactor, Quantity)
                  VALUES(NEWID(), 2, 2, 0);

                  INSERT INTO BloodStocks(Id, BloodType, RhFactor, Quantity)
                  VALUES(NEWID(), 3, 1, 0);

                  INSERT INTO BloodStocks(Id, BloodType, RhFactor, Quantity)
                  VALUES(NEWID(), 3, 2, 0);

                  INSERT INTO BloodStocks(Id, BloodType, RhFactor, Quantity)
                  VALUES(NEWID(), 4, 1, 0);

                  INSERT INTO BloodStocks(Id, BloodType, RhFactor, Quantity)
                  VALUES(NEWID(), 4, 2, 0);
              """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
