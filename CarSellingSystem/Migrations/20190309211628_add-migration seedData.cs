using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSellingSystem.Migrations
{
    public partial class addmigrationseedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES ('Make2')");
            migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES ('Make3')");


            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Make1-ModelA',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Make1'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Make1-ModelB',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Make1'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Make1-ModelC',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Make1'))");

            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Make2-ModelA',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Make2'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Make2-ModelB',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Make2'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Make2-ModelC',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Make2'))");

            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Make3-ModelA',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Make3'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Make3-ModelB',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Make3'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Make3-ModelC',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MAKES WHERE NAME IN ('Make1','Make2','Make3')");
        }
    }
}
