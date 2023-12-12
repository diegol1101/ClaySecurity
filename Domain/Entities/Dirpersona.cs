using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Dirpersona
{
    public int Id { get; set; }

    public string Direccion { get; set; }

    public int IdPerso { get; set; }

    public int IdTdireccion { get; set; }

    public virtual Persona IdPersoNavigation { get; set; }

    public virtual Tipodireccion IdTdireccionNavigation { get; set; }
}
