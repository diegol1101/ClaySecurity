﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Departamento
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public int IdPais { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    public virtual Pais IdPaisNavigation { get; set; }
}
