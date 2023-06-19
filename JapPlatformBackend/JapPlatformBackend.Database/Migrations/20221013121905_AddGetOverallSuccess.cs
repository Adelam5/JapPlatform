using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JapPlatformBackend.Database.Migrations
{
    public partial class AddGetOverallSuccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createSql = @"CREATE PROCEDURE [dbo].[GetOverallSuccess] 
            AS 
            BEGIN 
            SET 
            nocount on; 

            SELECT 
	            (SELECT COUNT(*) FROM AspNetUsers WHERE status = 1) /
		            CAST(COUNT(Status) AS FLOAT) * 100 AS OverallSuccessRate
            FROM AspNetUsers
            END;";

            migrationBuilder.Sql(createSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropSql = "DROP PROCEDURE [dbo].[GetOverallSuccess] ";

            migrationBuilder.Sql(dropSql);
        }
    }
}
