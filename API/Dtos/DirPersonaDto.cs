using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DirPersonaDto
    {
        public int Id { get; set; }

        public string Direccion { get; set; }
        public int IdPerso { get; set; }

        public int IdTdireccion { get; set; }
    }
}