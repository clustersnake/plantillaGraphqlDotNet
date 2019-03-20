using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Proyecto.Core.Repositories
{
    /// <summary>
    /// Interfaz que proporciona la funcionalidad básica 
    /// para realizar operaciones sobre las colecciones de datos
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Agregar un nuevo elemento a la colección
        /// </summary>
        /// <param name="entity">Elemento a guardar</param>
        void Add(TEntity entity);

        /// <summary>
        /// Agregar una colección de objetos a la colección
        /// </summary>
        /// <param name="entities">Lista de objetos a guardar</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Obtener un elemento dado su identificador
        /// </summary>
        /// <param name="id">id del elemento</param>
        /// <returns>Objeto de la clase definida</returns>
        TEntity Get(int id);

        /// <summary>
        /// Obtener todos los objetos de la colección
        /// </summary>
        /// <returns>Lista de objetos de la clase dada</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Buscar un elemento dentro de la colección
        /// </summary>
        /// <param name="predicate">lambda que define el objeto a buscar</param>
        /// <returns>Objeto de la clase dada</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Eliminar un elemento de la base de la colección
        /// </summary>
        /// <param name="entity">Elemento a eliminar</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Eliminar una colección de objetos de la colección
        /// </summary>
        /// <param name="entities">Lista de elementos a eliminar</param>
        void RemoveRange(IEnumerable<TEntity> entities);

    }

}
