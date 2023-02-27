using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_code_first_tutorial.Migrations
{
    /// <inheritdoc />
    public partial class addeditemsandfixedanerror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Sales",
                table: "Customers",
                type: "decimal(9,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Customers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.AlterColumn<decimal>(
                name: "Sales",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Active",
                table: "Customers",
                type: "decimal(9,2)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
