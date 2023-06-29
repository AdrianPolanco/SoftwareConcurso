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
}