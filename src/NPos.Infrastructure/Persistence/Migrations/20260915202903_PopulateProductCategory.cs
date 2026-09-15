using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPos.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PopulateProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT Categories ON;

                INSERT INTO Categories (Id, Name) VALUES 
                (1, 'Food'),
                (2, 'Beverage'),
                (3, 'Household'),
                (4, 'Fruit'),
                (5, 'Dairy'),
                (6, 'Frozen Foods'),
                (7, 'Meat'),
                (8, 'Produce'),
                (9, 'Cleaners'),
                (10, 'Personal Care');

                SET IDENTITY_INSERT Categories OFF;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10);");
        }
    }
}
