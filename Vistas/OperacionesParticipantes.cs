using Controladores;
using SelectorAleatorioDefinitivo.Modelos;
using ConsoleTables;

namespace Vistas;

class OperacionesParticipantes{
   List<DatosParticipante> elegidos = new List<DatosParticipante>();

    ControladorCRUD main = new ControladorCRUD();


        private List<DatosParticipante> datos = new List<DatosParticipante>();
        private List<DatosParticipante> activos = new List<DatosParticipante>();
        private List<DatosParticipante> inactivos = new List<DatosParticipante>();
        
        
    public void LeerParticipantes(){
        datos = main.ObtenerDatos();

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
        ConsoleTable tablaParticipantes = new ConsoleTable("Id","Nombre", "Apellido", "Participa", "Facilitador", "Matrícula");
        ConsoleTable tablaInactiva = new ConsoleTable("Id","Nombre", "Apellido", "Participa", "Facilitador", "Matrícula");

        foreach(DatosParticipante participante in activos){
            tablaParticipantes.AddRow(participante.IdDatosParticipante, participante.Nombre, participante.Apellido, "Sí", (bool)participante.EsFacilitador? "Sí" : "No", participante.Matricula);
        }

        foreach(DatosParticipante participante in inactivos){
            tablaInactiva.AddRow(participante.IdDatosParticipante, participante.Nombre, participante.Apellido, "No", (bool)participante.EsFacilitador? "Sí" : "No", participante.Matricula);
        }

        string tablaMostradaActivos = tablaParticipantes.ToStringAlternative();
        string tablaMostradaInactivos = tablaInactiva.ToStringAlternative();

        Console.WriteLine(tablaMostradaActivos);
        Console.WriteLine(@"
            PARTICIPANTES INACTIVOS
        ");
        Console.WriteLine(tablaMostradaInactivos);
    }

}

