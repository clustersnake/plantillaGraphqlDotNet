using System;
using GraphQL;
using GraphQL.Types;
using Proyecto.Api.GraphQL.Mutations;
using Proyecto.Api.GraphQL.Queries;

namespace Proyecto.Api.GraphQL.Schemas
{
    public class ProyectoSchema : Schema
    {
        public ProyectoSchema(IDependencyResolver resolver) : base(resolver)
        {
            // Query = query;
            Query = resolver.Resolve<ProyectoQuery>();
            DependencyResolver = resolver;
            Mutation = resolver.Resolve<ProyectoMutation>();
        }

    }
}
