using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SemaforosInteligentes.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DimCarriles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCarril = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sentido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoVehiculoPermitido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimCarriles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimIntersecciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreInterseccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UbicacionGeografica = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimIntersecciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimSemaforos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AñoInstalacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimSemaforos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimTiempos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    DiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimTiempos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HechosTrafico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimTiempoId = table.Column<int>(type: "int", nullable: false),
                    DimCarrilId = table.Column<int>(type: "int", nullable: false),
                    DimInterseccionId = table.Column<int>(type: "int", nullable: false),
                    DimSemaforoId = table.Column<int>(type: "int", nullable: false),
                    CantidadVehiculos = table.Column<int>(type: "int", nullable: false),
                    TiempoEsperaSeg = table.Column<float>(type: "real", nullable: false),
                    VelocidadPromKmh = table.Column<float>(type: "real", nullable: false),
                    LuzSemaforo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HechosTrafico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HechosTrafico_DimCarriles_DimCarrilId",
                        column: x => x.DimCarrilId,
                        principalTable: "DimCarriles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HechosTrafico_DimIntersecciones_DimInterseccionId",
                        column: x => x.DimInterseccionId,
                        principalTable: "DimIntersecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HechosTrafico_DimSemaforos_DimSemaforoId",
                        column: x => x.DimSemaforoId,
                        principalTable: "DimSemaforos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HechosTrafico_DimTiempos_DimTiempoId",
                        column: x => x.DimTiempoId,
                        principalTable: "DimTiempos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HechosTrafico_DimCarrilId",
                table: "HechosTrafico",
                column: "DimCarrilId");

            migrationBuilder.CreateIndex(
                name: "IX_HechosTrafico_DimInterseccionId",
                table: "HechosTrafico",
                column: "DimInterseccionId");

            migrationBuilder.CreateIndex(
                name: "IX_HechosTrafico_DimSemaforoId",
                table: "HechosTrafico",
                column: "DimSemaforoId");

            migrationBuilder.CreateIndex(
                name: "IX_HechosTrafico_DimTiempoId",
                table: "HechosTrafico",
                column: "DimTiempoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HechosTrafico");

            migrationBuilder.DropTable(
                name: "DimCarriles");

            migrationBuilder.DropTable(
                name: "DimIntersecciones");

            migrationBuilder.DropTable(
                name: "DimSemaforos");

            migrationBuilder.DropTable(
                name: "DimTiempos");
        }
    }
}
