using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Core.Models;

namespace Proyecto.Core.Repositories
{
    public interface ITareaRepository : IRepository<Tarea>
    {
        Task<IEnumerable<Tarea>> TareasPorModuloAsync(int modulo);
    }

}
