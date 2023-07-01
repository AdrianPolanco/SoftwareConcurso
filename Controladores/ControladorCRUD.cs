using SelectorAleatorioDefinitivo.Modelos;

namespace Controladores;

class ControladorCRUD
{
    private CRUD controlador = new CRUD();
    
    public List<DatosParticipante> ObtenerDatos(){
        return controlador.Read();
    }

    public DatosParticipante CrearDatos(DatosParticipante participante){
        return controlador.Create(participante);
    }

    public DatosParticipante BuscarPorId(string dato){
        int id;
        bool convertir = int.TryParse(dato, out id);

        return controlador.SearchById(id);
    }

    public DatosParticipante BuscarPorMatricula(string dato){
        return controlador.SearchByTuition(dato);
    }

    public DatosParticipante ActualizarPorMatricula(string idMatricula, string? nombre, string? apellido, string? matricula){
        return controlador.UpdateByTuition(idMatricula, nombre, apellido, matricula);
    }
    public DatosParticipante ActualizarPorId(string id, string? nombre, string? apellido, string? matricula){
        int idDef;
        bool convertir = int.TryParse(id, out idDef);
        return controlador.UpdateById(idDef, nombre, apellido, matricula);
    }

    public bool ChequearId(string id){
        int idDef;
        bool convertir = int.TryParse(id, out idDef);
        return controlador.CheckId(idDef);
    }
}