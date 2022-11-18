using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiFreWork01.DTOs
{
    public class MatriculaDTOs
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public bool Activo { get; set; }
    }
}
