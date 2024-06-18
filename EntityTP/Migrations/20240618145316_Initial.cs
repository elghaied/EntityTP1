using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityTP.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdresseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeVoie = table.Column<int>(type: "int", nullable: false),
                    LieuDit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdresseId);
                });

            migrationBuilder.CreateTable(
                name: "Societes",
                columns: table => new
                {
                    SocieteId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societes", x => x.SocieteId);
                    table.ForeignKey(
                        name: "FK_Societes_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdresseSociete",
                columns: table => new
                {
                    AdressesAdresseId = table.Column<long>(type: "bigint", nullable: false),
                    EtablissementsSocieteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresseSociete", x => new { x.AdressesAdresseId, x.EtablissementsSocieteId });
                    table.ForeignKey(
                        name: "FK_AdresseSociete_Adresses_AdressesAdresseId",
                        column: x => x.AdressesAdresseId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdresseSociete_Societes_EtablissementsSocieteId",
                        column: x => x.EtablissementsSocieteId,
                        principalTable: "Societes",
                        principalColumn: "SocieteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    PersonneId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdressePrincipaleId = table.Column<long>(type: "bigint", nullable: true),
                    AdresseSecondaireId = table.Column<long>(type: "bigint", nullable: true),
                    SocieteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.PersonneId);
                    table.ForeignKey(
                        name: "FK_Personnes_Adresses_AdressePrincipaleId",
                        column: x => x.AdressePrincipaleId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId");
                    table.ForeignKey(
                        name: "FK_Personnes_Adresses_AdresseSecondaireId",
                        column: x => x.AdresseSecondaireId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId");
                    table.ForeignKey(
                        name: "FK_Personnes_Societes_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "Societes",
                        principalColumn: "SocieteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonneSyndiquees",
                columns: table => new
                {
                    PersonneId = table.Column<long>(type: "bigint", nullable: false),
                    Syndicat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSyndication = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonneSyndiquees", x => x.PersonneId);
                    table.ForeignKey(
                        name: "FK_PersonneSyndiquees_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "PersonneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdresseSociete_EtablissementsSocieteId",
                table: "AdresseSociete",
                column: "EtablissementsSocieteId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_AdressePrincipaleId",
                table: "Personnes",
                column: "AdressePrincipaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_AdresseSecondaireId",
                table: "Personnes",
                column: "AdresseSecondaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_SocieteId",
                table: "Personnes",
                column: "SocieteId");

            migrationBuilder.CreateIndex(
                name: "IX_Societes_AdresseId",
                table: "Societes",
                column: "AdresseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdresseSociete");

            migrationBuilder.DropTable(
                name: "PersonneSyndiquees");

            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "Societes");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
