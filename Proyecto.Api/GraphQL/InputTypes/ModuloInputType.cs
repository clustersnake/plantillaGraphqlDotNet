using System;
using GraphQL.Types;

namespace Proyecto.Api.GraphQL.InputTypes
{
    public class ModuloInputType : InputObjectGraphType
    {
        public ModuloInputType()
        {
            Name = "ModuloInput";
            Field<NonNullGraphType<StringGraphType>>("nombre");
            Field<StringGraphType>("descripcion");

        }

    }
}
