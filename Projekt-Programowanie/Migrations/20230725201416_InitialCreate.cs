using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_Programowanie.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slowa",
                columns: table => new
                {
                    ID_Slowa = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NazwaSlowa = table.Column<string>(type: "TEXT", nullable: false),
                    Kategoria = table.Column<string>(type: "TEXT", nullable: false),
                    Dl_Slowa = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slowa", x => x.ID_Slowa);
                });

            migrationBuilder.CreateTable(
                name: "Wzory",
                columns: table => new
                {
                    ID_Wzoru = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rozmiar = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wzory", x => x.ID_Wzoru);
                });

            migrationBuilder.CreateTable(
                name: "Pytania",
                columns: table => new
                {
                    ID_Pytania = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tresc = table.Column<string>(type: "TEXT", nullable: false),
                    Trudnosc = table.Column<int>(type: "INTEGER", nullable: false),
                    OdpowiedzID_Slowa = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pytania", x => x.ID_Pytania);
                    table.ForeignKey(
                        name: "FK_Pytania_Slowa_OdpowiedzID_Slowa",
                        column: x => x.OdpowiedzID_Slowa,
                        principalTable: "Slowa",
                        principalColumn: "ID_Slowa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Krzyzowki",
                columns: table => new
                {
                    ID_Krzyzowki = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Trudnosc = table.Column<int>(type: "INTEGER", nullable: false),
                    Pyt1ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Pyt2ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Pyt3ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Pyt4ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Pyt5ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Pyt6ID = table.Column<int>(type: "INTEGER", nullable: false),
                    WzorID_Wzoru = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Krzyzowki", x => x.ID_Krzyzowki);
                    table.ForeignKey(
                        name: "FK_Krzyzowki_Pytania_Pyt1ID",
                        column: x => x.Pyt1ID,
                        principalTable: "Pytania",
                        principalColumn: "ID_Pytania",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Krzyzowki_Pytania_Pyt2ID",
                        column: x => x.Pyt2ID,
                        principalTable: "Pytania",
                        principalColumn: "ID_Pytania",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Krzyzowki_Pytania_Pyt3ID",
                        column: x => x.Pyt3ID,
                        principalTable: "Pytania",
                        principalColumn: "ID_Pytania",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Krzyzowki_Pytania_Pyt4ID",
                        column: x => x.Pyt4ID,
                        principalTable: "Pytania",
                        principalColumn: "ID_Pytania",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Krzyzowki_Pytania_Pyt5ID",
                        column: x => x.Pyt5ID,
                        principalTable: "Pytania",
                        principalColumn: "ID_Pytania",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Krzyzowki_Pytania_Pyt6ID",
                        column: x => x.Pyt6ID,
                        principalTable: "Pytania",
                        principalColumn: "ID_Pytania",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Krzyzowki_Wzory_WzorID_Wzoru",
                        column: x => x.WzorID_Wzoru,
                        principalTable: "Wzory",
                        principalColumn: "ID_Wzoru",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TabeleWynikow",
                columns: table => new
                {
                    ID_Wynikow = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Czas = table.Column<int>(type: "INTEGER", nullable: false),
                    Trudnosc = table.Column<int>(type: "INTEGER", nullable: false),
                    KrzyzowkaID_Krzyzowki = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabeleWynikow", x => x.ID_Wynikow);
                    table.ForeignKey(
                        name: "FK_TabeleWynikow_Krzyzowki_KrzyzowkaID_Krzyzowki",
                        column: x => x.KrzyzowkaID_Krzyzowki,
                        principalTable: "Krzyzowki",
                        principalColumn: "ID_Krzyzowki",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    ID_Uzytkownik = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    Najlepszy_Czas = table.Column<int>(type: "INTEGER", nullable: false),
                    Ilosc_Rozwiazanych = table.Column<int>(type: "INTEGER", nullable: false),
                    TabelaWynikowID_Wynikow = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.ID_Uzytkownik);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_TabeleWynikow_TabelaWynikowID_Wynikow",
                        column: x => x.TabelaWynikowID_Wynikow,
                        principalTable: "TabeleWynikow",
                        principalColumn: "ID_Wynikow",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Krzyzowki_Pyt1ID",
                table: "Krzyzowki",
                column: "Pyt1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Krzyzowki_Pyt2ID",
                table: "Krzyzowki",
                column: "Pyt2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Krzyzowki_Pyt3ID",
                table: "Krzyzowki",
                column: "Pyt3ID");

            migrationBuilder.CreateIndex(
                name: "IX_Krzyzowki_Pyt4ID",
                table: "Krzyzowki",
                column: "Pyt4ID");

            migrationBuilder.CreateIndex(
                name: "IX_Krzyzowki_Pyt5ID",
                table: "Krzyzowki",
                column: "Pyt5ID");

            migrationBuilder.CreateIndex(
                name: "IX_Krzyzowki_Pyt6ID",
                table: "Krzyzowki",
                column: "Pyt6ID");

            migrationBuilder.CreateIndex(
                name: "IX_Krzyzowki_WzorID_Wzoru",
                table: "Krzyzowki",
                column: "WzorID_Wzoru");

            migrationBuilder.CreateIndex(
                name: "IX_Pytania_OdpowiedzID_Slowa",
                table: "Pytania",
                column: "OdpowiedzID_Slowa");

            migrationBuilder.CreateIndex(
                name: "IX_TabeleWynikow_KrzyzowkaID_Krzyzowki",
                table: "TabeleWynikow",
                column: "KrzyzowkaID_Krzyzowki");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_TabelaWynikowID_Wynikow",
                table: "Uzytkownicy",
                column: "TabelaWynikowID_Wynikow");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "TabeleWynikow");

            migrationBuilder.DropTable(
                name: "Krzyzowki");

            migrationBuilder.DropTable(
                name: "Pytania");

            migrationBuilder.DropTable(
                name: "Wzory");

            migrationBuilder.DropTable(
                name: "Slowa");
        }
    }
}
