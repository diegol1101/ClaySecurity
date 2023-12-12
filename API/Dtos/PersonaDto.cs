using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }

        public string IdPersona { get; set; }

        public string Nombre { get; set; }

        public DateOnly DateReg { get; set; }
        public int IdTipoPer { get; set; }

        public int IdCatego { get; set; }

        public int IdCiudad { get; set; }
    }
}