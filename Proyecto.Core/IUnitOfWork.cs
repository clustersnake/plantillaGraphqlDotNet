using System;
using Proyecto.Core.Repositories;

namespace Proyecto.Core
{    /// <summary>
    /// Interfaz para el manejo de las operaciones
    /// relacionadas con la base de datos
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        // Colecciones de datos para pruebas
        IModuloRepository Modulos { get; }
        ITareaRepository Tareas { get; }

        /// <summary>
        /// Método Complete para aplicar las 
        /// operaciones y persistir los datos en la BD
        /// </summary>
        /// <returns>Un valor entero para indicar éxito / error</returns>
        int Complete();
    }

}
