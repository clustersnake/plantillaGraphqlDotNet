using System;
using Microsoft.EntityFrameworkCore;
using Proyecto.Core.Models;

namespace Proyecto.Persistence
{
      public class ProyectoContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // mensajes de error mejorados para entity framework
            optionsBuilder.EnableSensitiveDataLogging();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=prueba;User ID=sa; Password=p4ng34");
            }
        }
        public ProyectoContext()
        {

        }
        public ProyectoContext(DbContextOptions<ProyectoContext> options) : base(options) {}
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Tarea> Tareas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir nombres personalizados para las tablas utilizando
            // fluent API
            /* modelBuilder.Entity<Actividad>().ToTable("Actividades")
            .HasOne(x => x.UsuarioOrigen)
            .WithMany()
            .HasForeignKey(x => x.UsuarioOrigenId);
 */
   
   
            // cargar módulos
            modelBuilder.Entity<Modulo>().HasData(
                new Modulo { Id = 1, Nombre = "Indicadores", Descripcion = "Indicadores", FechaCreacion = DateTime.Now, Icono = "poll", Etiqueta = "Indicadores", Fondo = "caja-7", Url = "dashboard-indic", Ventana = "indicadores", Visible = true },
                new Modulo { Id = 2, Nombre = "Atencion de Solicitudes", Descripcion = "Bandeja Atencion de Solicitudes", FechaCreacion = DateTime.Now, Icono = "description", Etiqueta = "Atención de Solicitudes", Fondo = "caja-11", Url = "bandeja", Ventana = "bandeja", Visible = true },
                new Modulo { Id = 3, Nombre = "Administracion", Descripcion = "Administracion", FechaCreacion = DateTime.Now, Icono = "supervised_user_circle", Etiqueta = "Administración", Fondo = "caja-12", Url = "bandeja3", Ventana = "administracion", Visible = true },
                new Modulo { Id = 4, Nombre = "Atencion al Cliente", Descripcion = "Atencion al cliente", FechaCreacion = DateTime.Now, Icono = "contact_phone", Etiqueta = "Atención al Cliente", Fondo = "caja-5", Url = "en-construccion", Ventana = "atencionCliente", Visible = true },
                new Modulo { Id = 5, Nombre = "Caja Mayor", Descripcion = "Caja Mayor", FechaCreacion = DateTime.Now, Icono = "money", Etiqueta = "Caja Mayor", Fondo = "caja-2", Url = "en-construccion", Ventana = "cajaMayor", Visible = true },
                new Modulo { Id = 6, Nombre = "Girasoles", Descripcion = "Girasoles", FechaCreacion = DateTime.Now, Icono = "icon-girasoles", Etiqueta = "Girasoles", Fondo = "caja-3", Url = "en-construccion", Ventana = "girasoles", Visible = true },
                new Modulo { Id = 7, Nombre = "Control de Cajas", Descripcion = "Control de Cajas", FechaCreacion = DateTime.Now, Icono = "playlist_add_check", Etiqueta = "Control de Cajas", Fondo = "caja-4", Url = "en-construccion", Ventana = "controlCaas", Visible = true },
                new Modulo { Id = 8, Nombre = "Gestion de Materiales", Descripcion = "Gestion de Materiales", FechaCreacion = DateTime.Now, Icono = "build", Etiqueta = "Gestión de Materiales", Fondo = "caja-6", Url = "en-construccion", Ventana = "gestionMateriales", Visible = true },
                new Modulo { Id = 9, Nombre = "Auditorias", Descripcion = "Auditorias", FechaCreacion = DateTime.Now, Icono = "search", Etiqueta = "Auditorías", Fondo = "caja-8", Url = "en-construccion", Ventana = "auditorias", Visible = true }
            );

   
            // tareas
            // se asocian 15 tareas con dos procesos, 
            modelBuilder.Entity<Tarea>().HasData(
                new Tarea { Id = 1, ModuloId = 1, Nombre = "Cargar Datos", Descripcion = "cargar datos", Prioridad = 1, Duracion = 300, EsInicial = true, EnBandeja = false, Icono = "edit" },
                new Tarea { Id = 2, ModuloId = 1, Nombre = "Autorizar Registro", Descripcion = "Autorizacion", Prioridad = 1, Duracion = 120, EsInicial = false, EnBandeja = true, Icono = "icon-invertir" },
                new Tarea { Id = 3, ModuloId = 1, Nombre = "Solicitar Retiro", Descripcion = "Solicitar Retiro", Prioridad = 1, Duracion = 2, EsInicial = true, EnBandeja = false, Icono = "icon-punto-de-venta" },
                new Tarea { Id = 4, ModuloId = 2, Nombre = "Autorizar Retiro", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" },
                new Tarea { Id = 5, ModuloId = 2, Nombre = "Solicitar Tarjeta", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" },
                new Tarea { Id = 6, ModuloId = 1, Nombre = "Prestamo", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" },
                new Tarea { Id = 7, ModuloId = 2, Nombre = "Debito Automatico", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" },
                new Tarea { Id = 8, ModuloId = 1, Nombre = "Actualizar Datos", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" },
                new Tarea { Id = 9, ModuloId = 2, Nombre = "Activar Cuenta", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" },
                new Tarea { Id = 10, ModuloId = 1, Nombre = "Actualizar Adicionales", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" },
                new Tarea { Id = 11, ModuloId = 1, Nombre = "Aumentar Linea", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" },
                new Tarea { Id = 12, ModuloId = 2, Nombre = "Cambiar Cierre", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" },
                new Tarea { Id = 13, ModuloId = 1, Nombre = "Enviar EDC", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" },
                new Tarea { Id = 14, ModuloId = 2, Nombre = "Registros Fallidos", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" },
                new Tarea { Id = 15, ModuloId = 2, Nombre = "Actualizar Datos Automatico", Descripcion = "Autorizar Retiro", Prioridad = 1, Duracion = 8, EsInicial = false, EnBandeja = true, Icono = "icon-adicionales" }
            );

   
        }
    }

}
