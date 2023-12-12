using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Turno
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public DateOnly HoraIni { get; set; }

    public DateOnly HoraFin { get; set; }

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
