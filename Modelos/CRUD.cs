using SelectorAleatorioDefinitivo.Modelos;

class CRUD
{
    List<DatosParticipante> participantes = new List<DatosParticipante>();
    public List<DatosParticipante> Read()
    {
        using (ConcursoDbContext context = new ConcursoDbContext())
        {

            foreach (var post in context.DatosParticipantes.ToList())
            {
                participantes.Add(post);
            }

            return participantes;
        }
    }

    public DatosParticipante Create(DatosParticipante participante){
        using(ConcursoDbContext context = new ConcursoDbContext()){
            context.DatosParticipantes.Add(participante);
            context.SaveChanges();
        }

        return participante;
    }
}
