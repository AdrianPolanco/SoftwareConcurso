using ConsoleTables;
namespace Vistas;


class Tabla{

    Comandos comandos = new Comandos();
    public void EjecutarTabla(){
        ConsoleTable tablaComandos = new ConsoleTable("COMANDO", "FUNCIONALIDAD");

        Console.WriteLine(@"
Simbología: || = O
Parametro: []

        ");
        tablaComandos.AddRow("CHANGE STATUS", "Excluye o incluye en la selección a un participante, dependiendo de su estado actual de participacion");
        tablaComandos.AddRow("DEL", "Elimina a un estudiante, sea o no inactivo.");
        tablaComandos.AddRow("UPD", "Actualiza el Nombre, Apellido o la Matrícula del estudiante.");
        tablaComandos.AddRow("REG", "Registra a un estudiante.");
        tablaComandos.AddRow("GO", "Ejecuta la selección aleatoria.");
        tablaComandos.AddRow("SEARCH [NAME Nombre][LAST Apellido][ID Matricula]", "Busca a un estudiante por el criterio especificado.");
        tablaComandos.AddRow("EXIT", "Finaliza del programa.");
        tablaComandos.AddRow("REPORT", "Genera reportes PDF.");

        string tablaComandosMostrada = tablaComandos.ToStringAlternative();

        Console.WriteLine(@$"
        {tablaComandosMostrada}");

        comandos.Ejecutar();
    }
}