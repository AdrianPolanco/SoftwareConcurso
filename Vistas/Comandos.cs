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
            case "EXIT":
                Console.WriteLine("Saliendo del programa...");
                Environment.Exit(0);
                break;
            case "REG":
                registro.Ejecutar();
                Console.ReadKey();
                operacion.LeerParticipantes();
                Ejecutar();
                break;
            case "CHANGE STATUS":
                Console.Write("Introduzca 'ID' si desea buscar por ID o 'MATR' si desea buscar por matricula: ");
                string opcion = Console.ReadLine().ToUpper();
                if(opcion == "ID"){         
                    status.CambiarEstadoPorId();
                }else if(opcion == "MATR"){
                    status.CambiarEstadoPorMatricula();
                }else{
                    Console.WriteLine("Opción inválida, reiniciando programa...."); 
                }
                Esperar.Pausa();
                operacion.LeerParticipantes();
                Ejecutar();
                break;
            case "REPORT":
                reporte.CrearDocumento();
                operacion.LeerParticipantes();
                Ejecutar();
                break;
            case "REPORT SELECTED":
                reporte.CrearDocumentoSeleccionados();
                operacion.LeerParticipantes();
                Ejecutar();
                break;
            case "HELP":
                tabla.EjecutarTabla();
                operacion.LeerParticipantes();
                Ejecutar();
                break;
            case "SEARCH":
                buscar.Ejecutar();
                Console.ReadKey();         
                operacion.LeerParticipantes();
                Ejecutar();
                Console.Clear();
                break;
            case "UPD":
                actualizar.Ejecutar();
                operacion.LeerParticipantes();
                Ejecutar();
                break;
            case "DEL":
                eliminar.Ejecutar();
                operacion.LeerParticipantes();
                Ejecutar();
                break;
            case "GO":
                seleccionar.SeleccionarGanadores();
                operacion.LeerParticipantes();
                Ejecutar();
                break;
            case "TXT":
                bloc.Ejecutar();
                operacion.LeerParticipantes();
                Ejecutar();
                break;
            default:
                Console.WriteLine("ERROR: Comando no reconocido. Reiniciando programa...");
                operacion.LeerParticipantes();
                principal.Ejecutar();
                break;
        }
    }
}