using System;
using GraphQL.Types;
using Proyecto.Api.GraphQL.InputTypes;
using Proyecto.Api.GraphQL.Types;
using Proyecto.Core;
using Proyecto.Core.Models;

namespace Proyecto.Api.GraphQL.Mutations
{
    /// <summary>
    /// Clase para manipular los datos mediante GraphQL
    /// </summary>
    public class ProyectoMutation : ObjectGraphType
    {
        /// <summary>
        /// Constructor de clase donde se crean los endpoints
        /// cada endpoint se maneja como un Field que recibe 
        /// argumentos y ejecuta acciones a través del resolve
        /// </summary>
        protected readonly IUnitOfWork _unitOfWork;

        public ProyectoMutation(IUnitOfWork unitOfWork)
        {
            /// <summary>
            /// Crear un módulo nuevo
            /// </summary>
            /// <param name="modulo">modulo con los datos</param>
            /// <return>modulo recién creado</return>
            /// 
            _unitOfWork = unitOfWork;

            Field<ModuloType>(
                "crearModulo",
                arguments : new QueryArguments(
                    new QueryArgument<NonNullGraphType<ModuloInputType>> { Name = "modulo" }
                ),
                resolve : ctx =>
                {
                    var modulo = ctx.GetArgument<Modulo>("modulo");

                    modulo.FechaCreacion = DateTime.Now;
                    _unitOfWork.Modulos.Add(modulo);
                    _unitOfWork.Complete();

                    return modulo;

                });

            /// <summary>
            /// modificar módulo
            /// </summary>
            /// <param name="id">id del módulo a modificar</param>
            /// <param name="modulo">modulo con los datos</param>
            /// <return>modulo modificado</return>
            Field<ModuloType>(
                "modificarModulo",
                arguments : new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<ModuloInputType>> { Name = "modulo" }
                ),
                resolve : ctx =>
                {
                    var modulo = ctx.GetArgument<Modulo>("modulo");
                    var id = ctx.GetArgument<int>("id");

                    Modulo m = null;
                    m = _unitOfWork.Modulos.Get(id);
                    m.FechaCreacion = DateTime.Now;
                    m.Nombre = modulo.Nombre;
                    m.Descripcion = modulo.Descripcion;

                    _unitOfWork.Complete();

                    return m;

                });

        }

    }
}
