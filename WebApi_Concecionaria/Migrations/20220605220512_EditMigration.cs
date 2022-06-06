using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Concecionaria.Migrations
{
    public partial class EditMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Usuario",
                newName: "Nombre");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Usuario",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Usuario",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuario",
                newName: "Username");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Usuario",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
