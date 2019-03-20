using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.Persistence.Migrations
{
    public partial class CrearTablasIniciales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    Icono = table.Column<string>(nullable: true),
                    Etiqueta = table.Column<string>(nullable: true),
                    Fondo = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Ventana = table.Column<string>(nullable: true),
                    Visible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tareas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Implementacion = table.Column<string>(nullable: true),
                    Clasificacion = table.Column<string>(nullable: true),
                    Prioridad = table.Column<int>(nullable: false),
                    EsInicial = table.Column<bool>(nullable: false),
                    EnBandeja = table.Column<bool>(nullable: false),
                    Duracion = table.Column<int>(nullable: false),
                    Costo = table.Column<double>(nullable: false),
                    Documentacion = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Icono = table.Column<string>(nullable: true),
                    ModuloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tareas_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modulos",
                columns: new[] { "Id", "Descripcion", "Etiqueta", "FechaCreacion", "Fondo", "Icono", "Nombre", "Url", "Ventana", "Visible" },
                values: new object[,]
                {
                    { 1, "Indicadores", "Indicadores", new DateTime(2019, 3, 20, 15, 44, 37, 255, DateTimeKind.Local).AddTicks(4591), "caja-7", "poll", "Indicadores", "dashboard-indic", "indicadores", true },
                    { 2, "Bandeja Atencion de Solicitudes", "Atención de Solicitudes", new DateTime(2019, 3, 20, 15, 44, 37, 261, DateTimeKind.Local).AddTicks(2378), "caja-11", "description", "Atencion de Solicitudes", "bandeja", "bandeja", true },
                    { 3, "Administracion", "Administración", new DateTime(2019, 3, 20, 15, 44, 37, 261, DateTimeKind.Local).AddTicks(2472), "caja-12", "supervised_user_circle", "Administracion", "bandeja3", "administracion", true },
                    { 4, "Atencion al cliente", "Atención al Cliente", new DateTime(2019, 3, 20, 15, 44, 37, 261, DateTimeKind.Local).AddTicks(2481), "caja-5", "contact_phone", "Atencion al Cliente", "en-construccion", "atencionCliente", true },
                    { 5, "Caja Mayor", "Caja Mayor", new DateTime(2019, 3, 20, 15, 44, 37, 261, DateTimeKind.Local).AddTicks(2489), "caja-2", "money", "Caja Mayor", "en-construccion", "cajaMayor", true },
                    { 6, "Girasoles", "Girasoles", new DateTime(2019, 3, 20, 15, 44, 37, 261, DateTimeKind.Local).AddTicks(2498), "caja-3", "icon-girasoles", "Girasoles", "en-construccion", "girasoles", true },
                    { 7, "Control de Cajas", "Control de Cajas", new DateTime(2019, 3, 20, 15, 44, 37, 261, DateTimeKind.Local).AddTicks(2507), "caja-4", "playlist_add_check", "Control de Cajas", "en-construccion", "controlCaas", true },
                    { 8, "Gestion de Materiales", "Gestión de Materiales", new DateTime(2019, 3, 20, 15, 44, 37, 261, DateTimeKind.Local).AddTicks(2515), "caja-6", "build", "Gestion de Materiales", "en-construccion", "gestionMateriales", true },
                    { 9, "Auditorias", "Auditorías", new DateTime(2019, 3, 20, 15, 44, 37, 261, DateTimeKind.Local).AddTicks(2519), "caja-8", "search", "Auditorias", "en-construccion", "auditorias", true }
                });

            migrationBuilder.InsertData(
                table: "tareas",
                columns: new[] { "Id", "Clasificacion", "Costo", "Descripcion", "Documentacion", "Duracion", "EnBandeja", "EsInicial", "Estado", "Icono", "Implementacion", "ModuloId", "Nombre", "Prioridad", "Url" },
                values: new object[,]
                {
                    { 1, null, 0.0, "cargar datos", null, 300, false, true, null, "edit", null, 1, "Cargar Datos", 1, null },
                    { 2, null, 0.0, "Autorizacion", null, 120, true, false, null, "icon-invertir", null, 1, "Autorizar Registro", 1, null },
                    { 3, null, 0.0, "Solicitar Retiro", null, 2, false, true, null, "icon-punto-de-venta", null, 1, "Solicitar Retiro", 1, null },
                    { 6, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 1, "Prestamo", 1, null },
                    { 8, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 1, "Actualizar Datos", 1, null },
                    { 10, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 1, "Actualizar Adicionales", 1, null },
                    { 11, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 1, "Aumentar Linea", 1, null },
                    { 13, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 1, "Enviar EDC", 1, null },
                    { 4, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 2, "Autorizar Retiro", 1, null },
                    { 5, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 2, "Solicitar Tarjeta", 1, null },
                    { 7, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 2, "Debito Automatico", 1, null },
                    { 9, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 2, "Activar Cuenta", 1, null },
                    { 12, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 2, "Cambiar Cierre", 1, null },
                    { 14, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 2, "Registros Fallidos", 1, null },
                    { 15, null, 0.0, "Autorizar Retiro", null, 8, true, false, null, "icon-adicionales", null, 2, "Actualizar Datos Automatico", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tareas_ModuloId",
                table: "tareas",
                column: "ModuloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tareas");

            migrationBuilder.DropTable(
                name: "Modulos");
        }
    }
}
