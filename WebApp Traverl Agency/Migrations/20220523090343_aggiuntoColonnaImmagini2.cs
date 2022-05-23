using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Traverl_Agency.Migrations
{
    public partial class aggiuntoColonnaImmagini2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Immagine",
                table: "Pacchetto_Viaggio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Immagine",
                table: "Pacchetto_Viaggio");
        }
    }
}
