namespace Vistas;
using ConsoleTables;

class Comandos
{
    public void Ejecutar()
    {
        ConsoleTable tablaAyuda = new ConsoleTable("COMANDO", "FUNCIONALIDAD");
        tablaAyuda.AddRow("HELP", "Muestra la tabla de comandos.");
        Tabla tabla = new Tabla();
        Principal principal = new Principal();
        Registrar registro = new Registrar();
        Buscar buscar = new Buscar();
        Actualizar actualizar = new Actualizar();
        Eliminar eliminar = new Eliminar();
        OperacionesParticipantes operacion = new OperacionesParticipantes();
        GenerarReporte reporte = new GenerarReporte();    
        Status status = new Status();
        Seleccionar seleccionar = new Seleccionar();
        BlocNotas bloc = new BlocNotas();

 
        Console.WriteLine(tablaAyuda.ToStringAlternative());




        Console.WriteLine(@"
Introduzca un comando:");
        string comando = Console.ReadLine().ToUpper();

        switch(comando){            
            case "GO":
                seleccionar.SeleccionarGanadores();
                Console.ReadKey();
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break; 
            case "REG":
                registro.Ejecutar();
                Console.ReadKey();
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;
            case "TXT":
                bloc.Ejecutar();
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;
            case "SEARCH":
                buscar.Ejecutar();
                Console.ReadKey();         
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;   
            case "CHANGE STATUS":
                Console.Write(@"Introduzca 'ID' si desea cambiar estados por ID, 'MATR' si desea cambiar estados por matricula
                o 'MANY' si desea cambiar varios estados por ID: ");
                string opcion = Console.ReadLine().ToUpper();
                if(opcion == "ID"){         
                    status.CambiarEstadoPorId();
                }else if(opcion == "MATR"){
                    status.CambiarEstadoPorMatricula();
                }else if(opcion == "MANY"){
                    status.CambiarMuchosEstados();
                }else{
                    Console.WriteLine("Opción inválida, reiniciando programa...."); 
                }
                Console.ReadKey();
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;       
            case "UPD":
                actualizar.Ejecutar();
                Console.ReadKey();
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;  
            case "DEL":
                eliminar.Ejecutar();
                Console.ReadKey();
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;                                                     
            case "SELECTED":
                operacion.LeerSeleccionadosGeneral();
                Console.ReadKey();
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;            
            case "REPORT":
                reporte.CrearDocumento();
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;
            case "REPORT SELECTED":
                reporte.CrearDocumentoSeleccionados();
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;
            case "REPORT DEVELOPERS":
                reporte.CrearDocumentoDesarrolladores();
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;   
            case "EXIT":
                Console.WriteLine("Saliendo del programa...");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Environment.Exit(0);
                break;                         
            case "HELP":
                tabla.EjecutarTabla();
                Console.ReadKey();
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("ERROR: Comando no reconocido. Reiniciando programa...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                operacion.LeerParticipantes();
                principal.Ejecutar();
                Console.Clear();
                break;
        }
    }
}