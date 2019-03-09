using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSellingSystem.Migrations
{
    public partial class seedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO FEATURES (NAME) VALUES ('FEATURE1')");
            migrationBuilder.Sql("INSERT INTO FEATURES (NAME) VALUES ('FEATURE2')");
            migrationBuilder.Sql("INSERT INTO FEATURES (NAME) VALUES ('FEATURE3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM FEATURES");
        }
    }
}
