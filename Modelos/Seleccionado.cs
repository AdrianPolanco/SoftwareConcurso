using System;
using System.Collections.Generic;

namespace SelectorAleatorioDefinitivo.Modelos;

public partial class Seleccionado
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Matricula { get; set; }

    public string? Rol { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Resultado? Resultado { get; set; }
}
