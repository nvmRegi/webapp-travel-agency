using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Traverl_Agency.Migrations
{
    public partial class aggiuntoTabellaRichieste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Richiesta_Informazioni",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUtente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CognomeUtente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailUtente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Richiesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacchettoViaggioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Richiesta_Informazioni", x => x.id);
                    table.ForeignKey(
                        name: "FK_Richiesta_Informazioni_Pacchetto_Viaggio_PacchettoViaggioId",
                        column: x => x.PacchettoViaggioId,
                        principalTable: "Pacchetto_Viaggio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Richiesta_Informazioni_PacchettoViaggioId",
                table: "Richiesta_Informazioni",
                column: "PacchettoViaggioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Richiesta_Informazioni");
        }
    }
}
