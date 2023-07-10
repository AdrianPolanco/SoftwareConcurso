using Controladores;
using SelectorAleatorioDefinitivo.Modelos;
using ConsoleTables;

namespace Vistas;

public partial class OperacionesParticipantes{

    ControladorCRUD main = new ControladorCRUD();


        private List<DatosParticipante> datos = new List<DatosParticipante>();
        private List<DatosParticipante> activos = new List<DatosParticipante>();
        private List<DatosParticipante> inactivos = new List<DatosParticipante>();
        private List<Seleccionado> elegidos = new List<Seleccionado>();
        
        
    public void LeerParticipantes(){
        datos = main.ObtenerDatos();
        elegidos = main.LeerHistorialSeleccionados();
        foreach(DatosParticipante participante in datos){
            if((bool)participante.Participa){
                activos.Add(participante);
            }else{
                inactivos.Add(participante);
            }
        }
        Console.WriteLine(@"
        SELECTOR ALEATORIO DE PARTICIPANTES
        
        PARTICIPANTES ACTIVOS
        ");
        ConsoleTable tablaParticipantes = new ConsoleTable("Id","Nombre", "Apellido", "Participa", "Matrícula");
        ConsoleTable tablaInactiva = new ConsoleTable("Id","Nombre", "Apellido", "Participa", "Matrícula");
        ConsoleTable tablaElegidos = new ConsoleTable("Id","Nombre", "Apellido",  "Matrícula", "Rol", "Fecha");

        foreach(DatosParticipante participante in activos){
            tablaParticipantes.AddRow(participante.IdDatosParticipante, participante.Nombre, participante.Apellido, "Sí", participante.Matricula);
        }

        foreach(DatosParticipante participante in inactivos){
            tablaInactiva.AddRow(participante.IdDatosParticipante, participante.Nombre, participante.Apellido, "No", participante.Matricula);
        }

        foreach(Seleccionado elegido in elegidos){
            tablaElegidos.AddRow(elegido.Id, elegido.Nombre, elegido.Apellido, elegido.Matricula, elegido.Rol, elegido.Fecha);
        }

        string tablaMostradaActivos = tablaParticipantes.ToStringAlternative();
        string tablaMostradaInactivos = tablaInactiva.ToStringAlternative();
        string tablaMostradaElegidos = tablaElegidos.ToStringAlternative();

        Console.WriteLine(tablaMostradaActivos);
        Console.WriteLine(@"
            PARTICIPANTES INACTIVOS
        ");
        Console.WriteLine(tablaMostradaInactivos);

        Console.WriteLine(@"
            HISTORIAL DE PARTICIPANTES SELECCIONADOS
        ");
        Console.WriteLine(tablaMostradaElegidos);

    }

}

