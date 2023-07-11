using ConsoleTables;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;
namespace Vistas;

class Seleccionar{
    ControladorCRUD controlador = new ControladorCRUD();
    Cronometro cronometro = new Cronometro();
    Status status = new Status();
    public void SeleccionarGanadores(){
        ConsoleTable tabla = new ConsoleTable("ID", "Nombre", "Apellido", "Matricula", "Rol", "Fecha");
        ConsoleTable tablaFinal = new ConsoleTable("ID", "Nombre", "Apellido", "Matricula", "Rol", "Fecha", "Exito");
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

        while(true){
            int elegido1 = random.Next(participantesActivos.Count);
            int elegido2 = random.Next(participantesActivos.Count);

            if(elegido1 != elegido2){
                elegidos.Add(participantesActivos[elegido1]);
                elegidos.Add(participantesActivos[elegido2]);
                break;
            }
        }
        RetirarGanadores(elegidos);
        List<Seleccionado> seleccionados = controlador.InsertarHistoria(elegidos);

        foreach(Seleccionado seleccionado in seleccionados){
            tabla.AddRow(seleccionado.Id, seleccionado.Nombre, seleccionado.Apellido, seleccionado.Matricula, seleccionado.Rol, seleccionado.Fecha);
        }

        string tablaMostrada = tabla.ToStringAlternative();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(@"Estos son los seleccionados por la ruleta y ya han sido agregados al historial de seleccionados:
         ");
        Console.WriteLine(tablaMostrada);
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();

        bool tiempoPuesto = false;
        Resultado resultado = new Resultado(){IdSeleccionado = seleccionados[1].Id};
        int m = 0;
        int s = 0;
        string MinutosInput, SegundosInput;
        while(!tiempoPuesto){
            Console.Write("Introduce los minutos de los que dispone el participante: ");
            MinutosInput = Console.ReadLine();
            bool MinutosConvertidos = int.TryParse(MinutosInput, out m);
            if(!MinutosConvertidos){
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("ERROR: Debes introducir un formato de minutos valido, es decir, un número.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                continue;
            }
            Console.Write("Introduce los segundos de los que dispone el participante: ");
            SegundosInput = Console.ReadLine();
            bool SegundosConvertidos = int.TryParse(SegundosInput, out s);
            if(!SegundosConvertidos){
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("ERROR: Debes introducir un formato de segundos valido, es decir, un número.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                continue;
            }
            tiempoPuesto = true;
        }

        cronometro.Iniciar(m, s);
        Console.WriteLine("¡Tiempo agotado!");
        Console.ReadKey();

        Console.Write(@$"¿Fue capaz {seleccionados[1].Nombre} {seleccionados[1].Apellido} de matrícula {seleccionados[1].Matricula}
        capaz de hacer el programa que se le ha solicitado? Escriba SI si lo fue o cualquier otro valor si no lo fue: ");
        string respuesta = Console.ReadLine().ToUpper();

        if (respuesta == "SÍ" || respuesta == "SI"){
            resultado.Exito = true;
        }else{
            resultado.Exito = false;
        }

        try{
            controlador.InsertarEstado(resultado);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("¡Datos insertados con exito!");
            tablaFinal.AddRow(seleccionados[1].Id, seleccionados[1].Nombre, seleccionados[1].Apellido,
            seleccionados[1].Matricula, seleccionados[1].Rol, seleccionados[1].Fecha, ((bool)resultado.Exito ? "Sí" : "No"));
            string tablaFinalMostrada = tablaFinal.ToStringAlternative();
            Console.WriteLine(@"
            DATOS FINALES DEL ESTUDIANTE SELECCIONADO:
            ");
            Console.WriteLine(tablaFinalMostrada);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");

        }catch(Exception ex){
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"ERROR AL INSERTAR LOS DATOS: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
        }
     
        }else{
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("ERROR: No hay suficientes participantes para hacer la selección, pruebe agregando más vía registro, bloc de notas o inclusión");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
        }
        
     }

    public List<DatosParticipante> RetirarGanadores(List<DatosParticipante> ganadores){
        foreach(DatosParticipante ganador in ganadores){
            controlador.ActualizarGanadores(ganador.IdDatosParticipante);
        }
        return ganadores;
    }
}