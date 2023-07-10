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

    public bool CheckTuition(string matricula){

        try
        {
            DatosParticipante registro;
            using (ConcursoDbContext context = new ConcursoDbContext())
            {
                registro = context.DatosParticipantes.Single(dp => dp.Matricula == matricula);
                return true;
            }
        }
        catch
        { 
            return false; 
        }

    }

    public DatosParticipante DeleteById(int id){
        DatosParticipante registro;
        using(ConcursoDbContext context = new ConcursoDbContext()){
            registro = context.DatosParticipantes.Single(dp => dp.IdDatosParticipante == id);
            context.DatosParticipantes.Remove(registro);
            context.SaveChanges();
        }

        return registro;
    }

    public DatosParticipante DeleteByTuition(string tuition){
        DatosParticipante registro;
        using(ConcursoDbContext context = new ConcursoDbContext()){
            registro = context.DatosParticipantes.Single(dp => dp.Matricula == tuition);
            context.DatosParticipantes.Remove(registro);
            context.SaveChanges();
        }

        return registro;
    } 
       public DatosParticipante ChangeStatusById(int id){
        DatosParticipante participante;
        using(ConcursoDbContext context = new ConcursoDbContext()){
            participante = context.DatosParticipantes.Single(dp => dp.IdDatosParticipante == id);
            if((bool)participante.Participa){
                participante.Participa = false;
            }else{
                participante.Participa = true;
            }
            context.SaveChanges();
        }

        return participante;
    }

    public DatosParticipante ChangeStatusByTuition(string tuition){
        DatosParticipante participante;
        using(ConcursoDbContext context = new ConcursoDbContext()){
            participante = context.DatosParticipantes.Single(dp => dp.Matricula == tuition);
            if((bool)participante.Participa){
                participante.Participa = false;
            }else{
                participante.Participa = true;
            }
            context.SaveChanges();
        }

        return participante;
    }

    public List<Seleccionado> InsertHistory(List<DatosParticipante> ganadores){
        List<Seleccionado> ganadoresRegistrados = new List<Seleccionado>();
        foreach(DatosParticipante ganador in ganadores){
            ganadoresRegistrados.Add(
                new Seleccionado(){
                    Nombre = ganador.Nombre,
                    Apellido = ganador.Apellido,
                    Matricula = ganador.Matricula,
                    Rol = ganadores.IndexOf(ganador) == 0? "Instructor": "Desarrollador en vivo",
                    Fecha = DateTime.Now
                });
        };

        using(ConcursoDbContext context = new ConcursoDbContext()){
            foreach(Seleccionado seleccionado in ganadoresRegistrados){
                context.Seleccionados.Add(seleccionado);
            }
            
            context.SaveChanges();
        }

        return ganadoresRegistrados;
    }

    public List<Seleccionado> ReadSelectedHistory(){
        List<Seleccionado> seleccionados = new List<Seleccionado>();
        using(ConcursoDbContext context = new ConcursoDbContext()){
            foreach(Seleccionado seleccionado in context.Seleccionados.ToList()){
                seleccionados.Add(seleccionado);
            }
        }

        return seleccionados;
    }

    public Resultado InsertStatus(Resultado estado){
        using(ConcursoDbContext context = new ConcursoDbContext()){
            context.Resultados.Add(estado);
            context.SaveChanges();
        }

        return estado;
    }
}
