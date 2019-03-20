using System;
using Proyecto.Core;
using Proyecto.Core.Repositories;
using Proyecto.Persistence.Repositories;

namespace Proyecto.Persistence
{
    /// <summary>
    /// Clase para persistir los cambios 
    /// de la data en la BD
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        // Contexto de base de datos
        private readonly ProyectoContext _context;

        // Colecciones 
        public IModuloRepository Modulos { get; private set; }
        public ITareaRepository Tareas { get; private set; }

        /// <summary>
        /// Constructor que recibe el contexto de base 
        /// de datos e inicializa los repositorios
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public UnitOfWork(ProyectoContext context)
        {
            _context = context;
            Modulos = new ModuloRepository(_context);
            Tareas = new TareaRepository(_context);
        }

        /// <summary>
        /// Método para persistir los cambios de
        /// las colecciones en la base de datos
        /// </summary>
        /// <returns>Valor entero resultado de la operación</returns>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
