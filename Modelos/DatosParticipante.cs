using System;
using System.Collections.Generic;

namespace SelectorAleatorioDefinitivo.Modelos;

public partial class DatosParticipante
{
    public int IdDatosParticipante { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public bool? Participa { get; set; }

    public string? Matricula { get; set; }

    public virtual ICollection<Participante> Participantes { get; set; } = new List<Participante>();
}
