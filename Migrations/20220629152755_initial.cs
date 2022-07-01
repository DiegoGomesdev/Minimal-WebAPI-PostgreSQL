using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_Equipamentos.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Equipment_model_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_model",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_model", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_model_state_hourly_earnings",
                columns: table => new
                {
                    Equipment_model_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Equipment_state_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_model_state_hourly_earnings", x => x.Equipment_model_id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_position_history",
                columns: table => new
                {
                    Equipment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Lat = table.Column<int>(type: "integer", nullable: false),
                    Lon = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_position_history", x => x.Equipment_id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_state",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_state", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_state_history",
                columns: table => new
                {
                    Equipment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Equipment_state_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_state_history", x => x.Equipment_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Equipment_model");

            migrationBuilder.DropTable(
                name: "Equipment_model_state_hourly_earnings");

            migrationBuilder.DropTable(
                name: "Equipment_position_history");

            migrationBuilder.DropTable(
                name: "Equipment_state");

            migrationBuilder.DropTable(
                name: "Equipment_state_history");
        }
    }
}
