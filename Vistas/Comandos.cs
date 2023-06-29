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

         Console.WriteLine(@"
Introduzca un comando:");
        string comando = Console.ReadLine();

        switch(comando){
            case "EXIT":
                Console.WriteLine("Saliendo del programa...");
                break;
            case "HELP":
                tabla.EjecutarTabla();
                break;
            default:
                Console.WriteLine("ERROR: Comando no reconocido. Reiniciando programa...");
                principal.Ejecutar();
                break;
        }
    }
}