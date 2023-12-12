using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TurnoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateOnly HoraIni { get; set; }

        public DateOnly HoraFin { get; set; }
    }
}