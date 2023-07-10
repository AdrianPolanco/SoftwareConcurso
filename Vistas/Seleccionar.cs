using ConsoleTables;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;
namespace Vistas;

class Seleccionar{
    ControladorCRUD controlador = new ControladorCRUD();
    Status status = new Status();
    public void SeleccionarGanadores(){
        ConsoleTable tabla = new ConsoleTable("ID", "Nombre", "Apellido", "Matricula", "Rol", "Fecha");
        List<DatosParticipante> listaGeneral = controlador.ObtenerDatos();
        List<DatosParticipante> participantesActivos = new List<DatosParticipante>();
        List<DatosParticipante> elegidos = new List<DatosParticipante>();

        
        foreach(DatosParticipante participante in listaGeneral){
            if((bool)participante.Participa){
                participantesActivos.Add(participante);
            }
        }

        if(participantesActivos.Count > 1){
            Random random = new Random();

        int contador = 2;
        while(contador>0){
            int elegido = random.Next(participantesActivos.Count);
            elegidos.Add(participantesActivos[elegido]);

            if(elegidos.Count == 2){
                if(elegidos[0] != elegidos[1]){
                    //Console.WriteLine("Diferentes");
                    contador -= 1;  
                    //continue;
                } else{
                    //Console.WriteLine("Iguales");
                    elegidos.Remove(elegidos[1]);
                    contador += 1;
                }

            }
            contador -= 1;  
        }
        RetirarGanadores(elegidos);
        List<Seleccionado> seleccionados = controlador.InsertarHistoria(elegidos);

        foreach(Seleccionado seleccionado in seleccionados){
            tabla.AddRow(seleccionado.Id, seleccionado.Nombre, seleccionado.Apellido, seleccionado.Matricula, seleccionado.Rol, seleccionado.Fecha);
        }

        string tablaMostrada = tabla.ToStringAlternative();

        Console.WriteLine(@"Estos son los ganadores del sorteo y ya han sido agregados al historial de ganadores:
         ");
        Console.WriteLine(tablaMostrada);
        Console.ReadKey();
        
        }else{
            Console.WriteLine("ERROR: No hay suficientes participantes para hacer la selección, pruebe agregando más vía registro o inclusión");;
        }
        
     }

    public List<DatosParticipante> RetirarGanadores(List<DatosParticipante> ganadores){
        foreach(DatosParticipante ganador in ganadores){
            controlador.ActualizarGanadores(ganador.IdDatosParticipante);
        }
        return ganadores;
    }
}