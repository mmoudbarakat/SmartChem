using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartChem.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtomicNumber = table.Column<int>(type: "int", nullable: false),
                    AtomicMass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElementName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valence = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");
        }
    }
}
