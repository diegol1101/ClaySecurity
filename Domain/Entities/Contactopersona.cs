using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contactopersona
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public int IdPers { get; set; }

    public int IdTcontacto { get; set; }

    public virtual Persona IdPersNavigation { get; set; }

    public virtual Tipocontacto IdTcontactoNavigation { get; set; }
}
