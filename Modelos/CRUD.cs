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

    public DatosParticipante SearchById(int dato){
        DatosParticipante estudiante;
        using(ConcursoDbContext context = new ConcursoDbContext()){
            estudiante = context.DatosParticipantes.FirstOrDefault( dt => dt.IdDatosParticipante == dato);
        }

        return estudiante;
    }

    public DatosParticipante SearchByTuition(string dato){
        DatosParticipante estudiante;
        using(ConcursoDbContext context = new ConcursoDbContext()){
            estudiante = context.DatosParticipantes.FirstOrDefault( dt => dt.Matricula == dato);
        }

        return estudiante;
    }
}
