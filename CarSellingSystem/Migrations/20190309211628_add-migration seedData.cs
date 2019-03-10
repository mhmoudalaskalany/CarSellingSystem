using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSellingSystem.Migrations
{
    public partial class addmigrationseedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES ('BMW')");
            migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES ('Honda')");
            migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES ('KIA')");


            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('BMW 2010',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'BMW'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('BMW 2012',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'BMW'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('BMW 2015',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'BMW'))");

            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Honda 2013',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Honda'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Honda 2014',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Honda'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('Honda 2017',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'Honda'))");

            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('KIA 2011',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'KIA'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('KIA 2014',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'KIA'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES ('KIA 2019',(SELECT TOP(1) ID FROM MAKES WHERE NAME LIKE 'KIA'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MAKES WHERE NAME IN ('BMW','Honda','KIA')");
        }
    }
}
