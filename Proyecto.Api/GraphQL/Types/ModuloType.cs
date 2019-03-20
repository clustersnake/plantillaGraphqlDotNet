using System;
using GraphQL.Types;
using Proyecto.Core;
using Proyecto.Core.Models;

namespace Proyecto.Api.GraphQL.Types
{
    /// <summary>
    /// Tipo que define los campos disponibles para el endpoint de tareas
    /// </summary>
    public class ModuloType : ObjectGraphType<Modulo>
    {
        /// <summary>
        /// Definición de los campos disponibles para la interacción a través del endpoint.
        /// cada campo puede tener una descripción que sirve para autodocumentar el endpoint
        /// y que se puede visualizar desde graphiql.
        /// Los campos pueden ser tipos y estos sirven para navegar por las relaciones establecidas
        /// en la base de datos.
        /// </summary>

        protected readonly IUnitOfWork _unitOfWork;

        public ModuloType(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            // descripcion se muestra en el entry point del servicio
            Description = "Módulos";

            // cada Field representa un campo disponible y se puede colocar
            // una descripción
            Field(x => x.Id).Description("Id del módulo");
            Field(x => x.Nombre).Description("Nombre del modulo");
            Field(x => x.Descripcion).Description("Descripcion de la tarea");
            Field(x => x.Etiqueta).Description("Etiqueta para mostrar en en la gui");
            Field(x => x.Fondo).Description("Color de fondo en el botón de la GUI");
            Field(x => x.Icono).Description("Icono para el botón de la GUI");
            Field(x => x.Url).Description("Url donde se aloja la página que sirve a la aplicación");
            Field(x => x.Ventana).Description("Título de la pestaña donde se abre la aplicación");
            Field(x => x.FechaCreacion).Description("Fecha de creación del módulo");

            //lista de tareas asociadas con el usuario
            Field<ListGraphType<TareaType>>(
                "tareas",
                "tareas pertenecientes al módulo",
                resolve : ctx => _unitOfWork.Modulos.GetTareasAsync(ctx.Source.Id)
            );
            //lista de grupos a los cuales pertenece el usuario

        }

    }
}
