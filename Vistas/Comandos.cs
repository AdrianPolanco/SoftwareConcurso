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
                operacion.LeerParticipantes();
                Ejecutar();
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
            default:
                Console.WriteLine("ERROR: Comando no reconocido. Reiniciando programa...");
                operacion.LeerParticipantes();
                principal.Ejecutar();
                break;
        }
    }
}