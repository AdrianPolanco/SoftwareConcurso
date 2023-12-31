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

    public bool ChequearMatricula(string matricula){
        return controlador.CheckTuition(matricula);
    }

    public DatosParticipante CambiarStatusPorId(string id){
        int idDef;
        bool convertir = int.TryParse(id, out idDef);
        return controlador.ChangeStatusById(idDef);
    }

    public void CambiarMuchosStatus(string[] participantes){
        foreach(string id in participantes){
            CambiarStatusPorId(id);
        }
    }

    public DatosParticipante CambiarStatusPorMatricula(string matricula){
        return controlador.ChangeStatusByTuition(matricula);
    }

    public DatosParticipante EliminarEstudiantePorId(string id){
        int idDef;
        bool convertir = int.TryParse(id, out idDef);
        return controlador.DeleteById(idDef);
    }

    public void EliminarMuchosEstudiantes(string[] participantes){
        foreach(string id in participantes){
            EliminarEstudiantePorId(id);
        }
    }

    public DatosParticipante EliminarEstudiantePorMatricula(string matricula){
        return controlador.DeleteByTuition(matricula);
    }

    public DatosParticipante ActualizarGanadores(int id){
        return controlador.ChangeStatusById(id);
    }

    public List<Seleccionado> InsertarHistoria(List<DatosParticipante> ganadores){
        return controlador.InsertHistory(ganadores);
    }

    public List<Seleccionado> LeerHistorialSeleccionados(){
        return controlador.ReadSelectedHistory();
    }

    public List<Resultado> LeerDesarrolladoresSeleccionados(){
        return controlador.ReadSelectedDevelopers();
    }

    /*TODO: Hacer metodo que permita insertar en la tabla RESULTADOS si el estudiante elegido tuvo exito o no, 
    y modificar los reportes y las tablas para que reflejen esos cambios

    Puedo simplemente hacer un metodo que haga el insert, y basado en el ID del segundo seleccionado hacer un insert en la tabla RESULTADOS
    */

    public Resultado InsertarEstado(Resultado estado){
        return controlador.InsertStatus(estado);
    }

    
}