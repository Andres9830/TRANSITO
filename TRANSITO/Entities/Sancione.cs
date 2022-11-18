using System;
using System.Collections.Generic;

namespace TRANSITO.Entities
{
    public partial class Sancione
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int ConductorId { get; set; }

        public virtual Conductor Conductor { get; set; } = null!;
    }
}
