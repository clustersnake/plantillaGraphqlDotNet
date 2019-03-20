using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto.Core.Models;
using Proyecto.Core.Repositories;

namespace Proyecto.Persistence.Repositories
{
     public class ModuloRepository : Repository<Modulo>, IModuloRepository
    {

        public ModuloRepository(ProyectoContext context) : base(context)
        {}
        public ProyectoContext ProyectoContext
        {
            get { return Context as ProyectoContext; }
        }

        public async Task<IEnumerable<Tarea>> GetTareasAsync(int modulo)
        {
            IEnumerable<Tarea> tareas;
            try
            {
                // Context.Database.SqlQuery<Modulo>("select m.Id, m.Nombre, m.Descripcion, m.FechaCreacion, m.Icono, m.Etiqueta, m.Fondo, m.Url, m.Ventana, m.Visible from UsuariosRoles ur join PermisosRoles pr on ur.RolId = pr.RolId join Permisos p on pr.PermisoId = p.Id join TareasAreas tga on p.TareaGrupoAreaId = tga.Id join Tareas t on tga.TareaId = t.Id join ModulosTareas mt on t.Id = mt.TareaId join Modulos m on mt.ModuloId = m.Id where ur.UsuarioId = 1 and m.Visible = 1 and tga.Id not in ( select tga.Id from PermisosUsuarios pu join Permisos p on pu.PermisoId = p.Id join TareasAreas tga on p.TareaGrupoAreaId = tga.Id join Tareas t on tga.TareaId = t.Id join ModulosTareas mt on t.Id = mt.TareaId join Modulos m on mt.ModuloId = m.Id where pu.UsuarioId = 1 and p.Signo = '-' )").ToList();
                // ProyectoContext.Modulos.FromSql("select m.* from UsuariosRoles ur join PermisosRoles pr on ur.RolId = pr.RolId join Permisos p on pr.PermisoId = p.Id join TareasAreas tga on p.TareaAreaId = tga.Id join Tareas t on tga.TareaId = t.Id join ModulosTareas mt on t.Id = mt.TareaId join Modulos m on mt.ModuloId = m.Id where ur.UsuarioId = @usuarioId and m.Visible = 1 and tga.Id not in ( select tga.Id from PermisosUsuarios pu join Permisos p on pu.PermisoId = p.Id join TareasAreas tga on p.TareaAreaId = tga.Id join Tareas t on tga.TareaId = t.Id join ModulosTareas mt on t.Id = mt.TareaId join Modulos m on mt.ModuloId = m.Id where pu.UsuarioId = @usuarioId and p.Signo = '-' )", new SqlParameter("usuarioId", usuario)).ToListAsync();
                tareas = await ProyectoContext
                    .Tareas
                    .Where(x => x.ModuloId == modulo)
                    .ToListAsync();
            }
            catch (Exception)
            {
                // pendiente
                return null;
            }
            return (tareas);
        }
        
    }

 
 }
