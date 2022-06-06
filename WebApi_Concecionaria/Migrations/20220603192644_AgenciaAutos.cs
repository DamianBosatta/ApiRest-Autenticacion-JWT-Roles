using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Concecionaria.Migrations
{
    public partial class AgenciaAutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dni = table.Column<int>(type: "int", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    idVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<float>(type: "real", nullable: false),
                    fechaBaja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.idVehiculo);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    idVentas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    importe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descuento = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idVehiculo = table.Column<int>(type: "int", nullable: false),
                    vehiculoidVehiculo = table.Column<int>(type: "int", nullable: true),
                    idCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.idVentas);
                    table.ForeignKey(
                        name: "FK_Ventas_Cliente_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Vehiculo_vehiculoidVehiculo",
                        column: x => x.vehiculoidVehiculo,
                        principalTable: "Vehiculo",
                        principalColumn: "idVehiculo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_idCliente",
                table: "Ventas",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_vehiculoidVehiculo",
                table: "Ventas",
                column: "vehiculoidVehiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
