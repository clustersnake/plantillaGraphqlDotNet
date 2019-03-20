using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Core.Models;

namespace Proyecto.Core.Repositories
{
    /// <summary>
    ///  Interfaz para el manejo de módulos
    /// </summary>
    public interface IModuloRepository : IRepository<Modulo>
    {
        //void Dispose();
        Task<IEnumerable<Tarea>> GetTareasAsync(int modulo);
        //Task<Modulo> GetModuloByUsuarioAsync(int usuario, int id);
    }

}
