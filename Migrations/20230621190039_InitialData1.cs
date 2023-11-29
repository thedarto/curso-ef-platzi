using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("444d704f-9ef9-430e-89d1-9520c2bc5010"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 21, 19, 0, 39, 356, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("444d704f-9ef9-430e-89d1-9520c2bc5011"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 21, 19, 0, 39, 356, DateTimeKind.Utc).AddTicks(4592));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("444d704f-9ef9-430e-89d1-9520c2bc5010"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 20, 0, 5, 49, 602, DateTimeKind.Local).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("444d704f-9ef9-430e-89d1-9520c2bc5011"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 20, 0, 5, 49, 602, DateTimeKind.Local).AddTicks(8911));
        }
    }
}
