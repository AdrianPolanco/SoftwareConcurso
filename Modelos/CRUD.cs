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

    public DatosParticipante UpdateById(int id, string nombre, string apellido, string matricula){
        DatosParticipante registro;
        using(ConcursoDbContext context = new ConcursoDbContext()){
            registro = context.DatosParticipantes.Single(dp => dp.IdDatosParticipante == id);
            if(nombre != ""){
                registro.Nombre = nombre;
            }

            if(apellido != ""){
                registro.Apellido = apellido;
            }

            if(matricula != ""){
                registro.Matricula = matricula;
            }

            context.SaveChanges();
            
        }

        return registro;
    }

    public DatosParticipante UpdateByTuition(string idMatricula, string nombre, string apellido, string matricula){
        DatosParticipante registro;
        using(ConcursoDbContext context = new ConcursoDbContext()){
            registro = context.DatosParticipantes.Single(dp => dp.Matricula == idMatricula);
            if(nombre != ""){
                registro.Nombre = nombre;
            }

            if(apellido != ""){
                registro.Apellido = apellido;
            }

            if(matricula != ""){
                registro.Matricula = matricula;
            }

            context.SaveChanges();
            
        }

        return registro;
    }

    public bool CheckId(int id){

        try
        {
            DatosParticipante registro;
            using (ConcursoDbContext context = new ConcursoDbContext())
            {
                registro = context.DatosParticipantes.Single(dp => dp.IdDatosParticipante == id);
                return true;
            }
        }
        catch
        { 
            return false; 
        }

    }
}
