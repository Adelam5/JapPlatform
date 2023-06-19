using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JapPlatformBackend.Database.Migrations
{
    public partial class AddGetSelectionsSuccessSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createSql = @"CREATE PROCEDURE [dbo].[GetSelectionsSuccess] 
            AS 
            BEGIN 
            SET 
            nocount on; 

            SELECT 
                selections.Id AS Id, 

                selections.Name AS SelectionName, 

                programs.Name AS ProgramName, 

	            (SELECT COUNT(*) FROM AspNetUsers WHERE status = 1 AND selections.Id = AspNetUsers.SelectionId ) / 
	                CAST(COUNT(AspNetUsers.Status) AS FLOAT) * 100 AS SuccessRate

            FROM selections JOIN programs 
            ON selections.ProgramId = programs.Id 
            JOIN AspNetUsers 
            ON selections.Id = AspNetUsers.SelectionId 
            GROUP BY selections.Id, selections.Name, programs.Name 
            END;";

            migrationBuilder.Sql(createSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropSql = "DROP PROCEDURE [dbo].[GetSelectionsSuccess] ";

            migrationBuilder.Sql(dropSql);
        }
    }
}
