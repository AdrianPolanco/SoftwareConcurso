using System;
using System.Collections.Generic;

namespace SelectorAleatorioDefinitivo.Modelos;

public partial class Participante
{
    public int IdParticipante { get; set; }

    public int? IdDatosParticipante { get; set; }

    public virtual DatosParticipante? IdDatosParticipanteNavigation { get; set; }
}
