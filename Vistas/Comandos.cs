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
        Console.WriteLine(tablaAyuda.ToStringAlternative());



        Console.WriteLine(@"
Introduzca un comando:");
        string comando = Console.ReadLine();

        switch(comando){
            case "EXIT":
                Console.WriteLine("Saliendo del programa...");
                Environment.Exit(0);
                break;
            case "REG":
                registro.Ejecutar();
                Ejecutar();
                break;
            case "HELP":
                tabla.EjecutarTabla();
                Ejecutar();
                break;
            case "SEARCH":
                buscar.Ejecutar();
                Ejecutar();
                break;
            default:
                Console.WriteLine("ERROR: Comando no reconocido. Reiniciando programa...");
                principal.Ejecutar();
                break;
        }
    }
}