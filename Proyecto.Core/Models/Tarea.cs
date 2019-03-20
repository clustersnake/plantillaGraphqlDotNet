using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Core.Models
{
    [Table("tareas")]
    public class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Implementacion { get; set; }
        public string Clasificacion { get; set; }
        public int Prioridad { get; set; }
        public bool EsInicial { get; set; }
        public bool EnBandeja { get; set; }
        public int Duracion { get; set; } // segundos
        public double Costo { get; set; }
        public string Documentacion { get; set; }
        public string Estado { get; set; }
        public string Url { get; set; }
        public string Icono { get; set; }

        // claves foráneas
        public int ModuloId { get; set; }

        //propiedades navigacionales
        public virtual Modulo Modulo { get; set; }

    }

}
