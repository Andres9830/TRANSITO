using System;
using System.Collections.Generic;

namespace TRANSITO.Entities
{
    public partial class Matricula
    {
        public Matricula()
        {
            Conductors = new HashSet<Conductor>();
        }

        public int Id { get; set; }
        public string? Numero { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Conductor> Conductors { get; set; }
    }
}
