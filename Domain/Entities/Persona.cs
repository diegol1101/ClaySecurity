using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Persona
{
    public int Id { get; set; }

    public string IdPersona { get; set; }

    public string Nombre { get; set; }

    public DateOnly DateReg { get; set; }

    public int IdTipoPer { get; set; }

    public int IdCatego { get; set; }

    public int IdCiudad { get; set; }

    public virtual ICollection<Contactopersona> Contactopersonas { get; set; } = new List<Contactopersona>();

    public virtual ICollection<Contrato> ContratoIdClienteNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<Contrato> ContratoIdEmpleadoNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<Dirpersona> Dirpersonas { get; set; } = new List<Dirpersona>();

    public virtual Categoriapersona IdCategoNavigation { get; set; }

    public virtual Ciudad IdCiudadNavigation { get; set; }

    public virtual Tipopersona IdTipoPerNavigation { get; set; }

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
