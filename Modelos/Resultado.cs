using System;
using System.Collections.Generic;

namespace SelectorAleatorioDefinitivo.Modelos;

public partial class Resultado
{
    public int IdSeleccionado { get; set; }

    public bool? Exito { get; set; }

    public virtual Seleccionado IdSeleccionadoNavigation { get; set; } = null!;
}
