using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSellingSystem.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO FEATURES (NAME) VALUES ('Turbo Cooler')");
            migrationBuilder.Sql("INSERT INTO FEATURES (NAME) VALUES ('Air Conditioner')");
            migrationBuilder.Sql("INSERT INTO FEATURES (NAME) VALUES ('4 * 4')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM FEATURES");
        }
    }
}
