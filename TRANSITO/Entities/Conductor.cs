using System;
using System.Collections.Generic;

namespace TRANSITO.Entities
{
    public partial class Conductor
    {
        public Conductor()
        {
            Sanciones = new HashSet<Sancione>();
        }

        public int Id { get; set; }
        public string Identificacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string? Telefono { get; set; }
        public int MatriculaId { get; set; }

        public virtual Matricula Matricula { get; set; } = null!;
        public virtual ICollection<Sancione> Sanciones { get; set; }
    }
}
