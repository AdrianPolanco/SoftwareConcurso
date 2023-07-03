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
        tablaComandos.AddRow("EXC [MATRÍCULA]||[ID]", "Excluye de la selección a un participante, pasandolo a estado de inactivo.");
        tablaComandos.AddRow("DEL", "Elimina a un estudiante, sea o no inactivo.");
        tablaComandos.AddRow("INC [MATRICULA]||[ID]", "Incluye en la selección a un participante, pasandolo a estado de activo.");
        tablaComandos.AddRow("UPD", "Actualiza el Nombre, Apellido o la Matrícula del estudiante.");
        tablaComandos.AddRow("REG", "Registra a un estudiante.");
        tablaComandos.AddRow("GO", "Ejecuta la selección aleatoria.");
        tablaComandos.AddRow("SEARCH [NAME Nombre][LAST Apellido][ID Matricula]", "Busca a un estudiante por el criterio especificado.");
        tablaComandos.AddRow("EXIT", "Finaliza del programa.");
        tablaComandos.AddRow("MAIN MENU", "Regresa al menú principal.");

        string tablaComandosMostrada = tablaComandos.ToStringAlternative();

        Console.WriteLine(@$"
        {tablaComandosMostrada}");

        comandos.Ejecutar();
    }
}