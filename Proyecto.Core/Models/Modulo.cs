using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Core.Models
{
    [Table("Modulos")]
    public class Modulo
    {
		public Modulo()
		{
			Tareas = new HashSet<Tarea>();
		}
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string Icono { get; set; }
        public string Etiqueta { get; set; }
        public string Fondo { get; set; }
        public string Url { get; set; }
        public string Ventana { get; set; }
        public bool Visible { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
