using System;
using GraphQL.Types;
using Proyecto.Core.Models;

namespace Proyecto.Api.GraphQL.Types
{
        /// <summary>
    /// Tipo que define los campos disponibles para el endpoint de tareas
    /// </summary>
    public class TareaType : ObjectGraphType<Tarea>
    {
        /// <summary>
        /// Definición de los campos disponibles para la interacción a través del endpoint.
        /// cada campo puede tener una descripción que sirve para autodocumentar el endpoint
        /// y que se puede visualizar desde graphiql.
        /// Los campos pueden ser tipos y estos sirven para navegar por las relaciones establecidas
        /// en la base de datos.
        /// </summary>
        public TareaType()
        {
            // descripcion se muestra en el entry point del servicio
            Description = "Tareas";

            // cada Field representa un campo disponible y se puede colocar
            // una descripción
            Field(f => f.Id).Description("Id de la tarea");
            Field(f => f.Nombre).Description("Nombre de la tarea");
            Field(f => f.Descripcion).Description("Descripcion de la tarea");
            Field(f => f.Implementacion).Description("Ruta de ejecución de la tarea");
            Field(f => f.Clasificacion).Description("Clasificación de la tarea");
            Field(f => f.Prioridad).Description("Prioridad de la tarea");
            Field(f => f.EsInicial).Description("Define si es una tarea de Arranque de proceso");
            Field(f => f.EnBandeja).Description("Mostrar la tarea en el menu de bandeja");
            Field(f => f.Duracion).Description("Duración de la tarea en horas");
            Field(f => f.Costo).Description("Costo estimado de la tarea");
            Field(f => f.Documentacion).Description("Documentos necesarios");
            Field(f => f.Estado).Description("Estado actual de la tarea");
            Field(f => f.Url).Description("Dirección de la aplicación a ejecutar");
            Field(f => f.Icono).Description("Icono para mostrar en el meú de la aplicación");

        }

    }

}
