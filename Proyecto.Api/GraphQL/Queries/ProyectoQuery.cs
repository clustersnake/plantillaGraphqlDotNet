using System;
using GraphQL.Types;
using Proyecto.Api.GraphQL.Types;
using Proyecto.Core;

namespace Proyecto.Api.GraphQL.Queries
{
       /// <summary>
    /// Punto de entrada para la interacción con Graphql
    /// </summary>
    public class ProyectoQuery : ObjectGraphType<object>
    {

        protected readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Endpoint para realizar consultas 
        /// </summary>
        /// <param name="moduloRepository">
        ///     Objeto con rutinas de acceso a la base de datos a través del uso del modelo Modulo
        /// </param>
        /// <param name="tareaRepository">
        ///     Objeto con rutinas de acceso a la base de datos para el modelo Tarea
        /// </param>
        /// <return>
        ///     Fields. 
        ///     Cada uno de los Field definidos se asocia con un "endpoint" por lo cual el Field "usuarios" 
        ///     sirve para interactuar con los registros de usuarios y sus relaciones las cuales están definidas
        ///     en UsuarioType
        /// </return>
        public ProyectoQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Name = "Query";
            // obtener un módulo dado su id
            Field<ModuloType>(
                "modulo",
                arguments : new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                resolve : ctx => _unitOfWork.Modulos.Get(ctx.GetArgument<int>("id"))
            );

            // listar todos los módulos
            Field<ListGraphType<ModuloType>>(
                "modulos",
                resolve : ctx => _unitOfWork.Modulos.GetAll()
            );

        }

    }

}
