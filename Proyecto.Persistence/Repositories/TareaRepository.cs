using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto.Core.Models;
using Proyecto.Core.Repositories;

namespace Proyecto.Persistence.Repositories
{
        public class TareaRepository : Repository<Tarea>, ITareaRepository
    {
        public TareaRepository(DbContext context) : base(context) {}

        public ProyectoContext ProyectoContext
        {
            get { return Context as ProyectoContext; }
        }
        /// <summary>
        /// Obtener las tareas asociadas con un módulo
        /// </summary>
        /// <param name="usuario">id del usuario</param>
        /// <param name="modulo">id del módulo, si no se pasa, se asume 2 que está asociado bandejas</param>
        /// <returns>Una lista de tareas </returns>
        public async Task<IEnumerable<Tarea>> TareasPorModuloAsync(int modulo)
        {
            IEnumerable<Tarea> tareas;
            try
            {
                // Context.Database.SqlQuery<Modulo>("select m.Id, m.Nombre, m.Descripcion, m.FechaCreacion, m.Icono, m.Etiqueta, m.Fondo, m.Url, m.Ventana, m.Visible from UsuariosRoles ur join PermisosRoles pr on ur.RolId = pr.RolId join Permisos p on pr.PermisoId = p.Id join TareasGruposAreas tga on p.TareaGrupoAreaId = tga.Id join Tareas t on tga.TareaId = t.Id join ModulosTareas mt on t.Id = mt.TareaId join Modulos m on mt.ModuloId = m.Id where ur.UsuarioId = 1 and m.Visible = 1 and tga.Id not in ( select tga.Id from PermisosUsuarios pu join Permisos p on pu.PermisoId = p.Id join TareasGruposAreas tga on p.TareaGrupoAreaId = tga.Id join Tareas t on tga.TareaId = t.Id join ModulosTareas mt on t.Id = mt.TareaId join Modulos m on mt.ModuloId = m.Id where pu.UsuarioId = 1 and p.Signo = '-' )").ToList();
                tareas = await ProyectoContext.Tareas.FromSql("select t.* from Tareas t join ModulosTareas mt on t.Id = mt.TareaId where mt.ModuloId = @moduloId", new SqlParameter("moduloId", modulo)).ToListAsync();
            }
            catch (Exception)
            {
                // pendiente
                return null;
            }
            return tareas;

        }

    }

}
