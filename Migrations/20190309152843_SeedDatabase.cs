using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSellingSystem.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //insert makes
            migrationBuilder.Sql("INSERT INTO MAKES (Name) VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO MAKES (Name) VALUES ('Make2')");
            migrationBuilder.Sql("INSERT INTO MAKES (Name) VALUES ('Make3')");

            //insert models by selecting the id of the inserted makes to avoid woring id association if we downgraded our database
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('Make1-ModelA',(SELECT ID FROM MAKES WHERE NAME LIKE 'Make1'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('Make1-ModelB',(SELECT ID FROM MAKES WHERE NAME LIKE 'Make1'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('Make1-ModelC',(SELECT ID FROM MAKES WHERE NAME LIKE 'Make1'))");

            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('Make1-ModelA',(SELECT ID FROM MAKES WHERE NAME LIKE 'Make2'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('Make1-ModelB',(SELECT ID FROM MAKES WHERE NAME LIKE 'Make2'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('Make1-ModelC',(SELECT ID FROM MAKES WHERE NAME LIKE 'Make2'))");

            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('Make1-ModelA',(SELECT ID FROM MAKES WHERE NAME LIKE 'Make3'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('Make1-ModelB',(SELECT ID FROM MAKES WHERE NAME LIKE 'Make3'))");
            migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('Make1-ModelC',(SELECT ID FROM MAKES WHERE NAME LIKE 'Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MAKES WHERE NAME IN ('Make1','Make2','Make3')");
        }
    }
}
