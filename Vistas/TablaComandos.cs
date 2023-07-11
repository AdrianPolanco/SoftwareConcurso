using ConsoleTables;
namespace Vistas;


class Tabla{

    Comandos comandos = new Comandos();
    public void EjecutarTabla(){
        ConsoleTable tablaComandos = new ConsoleTable("COMANDO", "FUNCIONALIDAD");


        tablaComandos.AddRow("GO", "Ejecuta la selección aleatoria.");
        tablaComandos.AddRow("REG", "Registra a un estudiante.");
        tablaComandos.AddRow("TXT", "Abre el archivo TXT para poder registrar varios estudiantes.");
        tablaComandos.AddRow("SEARCH", "Busca a un estudiante por el criterio especificado.");
        tablaComandos.AddRow("CHANGE STATUS", "Cambia el status del estudiante especificado, pasandolo a 'Activo' si esta en estado 'Inactivo' y viceversa");
        tablaComandos.AddRow("UPD", "Actualiza el Nombre, Apellido o la Matrícula del estudiante.");
        tablaComandos.AddRow("DEL", "Elimina a un estudiante, sea o no inactivo.");
        tablaComandos.AddRow("SELECTED", "Imprime en pantalla todos los estudiantes seleccionados, independientemente de su rol.");
        tablaComandos.AddRow("REPORT", "Genera reportes de todos los estudiantes en formato PDF.");
        tablaComandos.AddRow("REPORT SELECTED", "Genera reportes de todos los estudiantes seleccionados en formato PDF.");
        tablaComandos.AddRow("REPORT DEVELOPERS", "Genera reportes de todos los estudiantes seleccionados en el rol de 'Desarrollador en vivo' en formato PDF, en el que consta si tuvieron exito o no.");       
        tablaComandos.AddRow("EXIT", "Finaliza del programa.");
        string tablaComandosMostrada = tablaComandos.ToStringAlternative();        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"

 .----------------.  .----------------.  .----------------.  .----------------.  .-----------------. .----------------.  .----------------.  .----------------. 
| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
| |     ______   | || |     ____     | || | ____    ____ | || |      __      | || | ____  _____  | || |  ________    | || |     ____     | || |    _______   | |
| |   .' ___  |  | || |   .'    `.   | || ||_   \  /   _|| || |     /  \     | || ||_   \|_   _| | || | |_   ___ `.  | || |   .'    `.   | || |   /  ___  |  | |
| |  / .'   \_|  | || |  /  .--.  \  | || |  |   \/   |  | || |    / /\ \    | || |  |   \ | |   | || |   | |   `. \ | || |  /  .--.  \  | || |  |  (__ \_|  | |
| |  | |         | || |  | |    | |  | || |  | |\  /| |  | || |   / ____ \   | || |  | |\ \| |   | || |   | |    | | | || |  | |    | |  | || |   '.___`-.   | |
| |  \ `.___.'\  | || |  \  `--'  /  | || | _| |_\/_| |_ | || | _/ /    \ \_ | || | _| |_\   |_  | || |  _| |___.' / | || |  \  `--'  /  | || |  |`\____) |  | |
| |   `._____.'  | || |   `.____.'   | || ||_____||_____|| || ||____|  |____|| || ||_____|\____| | || | |________.'  | || |   `.____.'   | || |  |_______.'  | |
| |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | |
| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
 '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' 

        ");


        Console.WriteLine(tablaComandosMostrada);
        Console.WriteLine("Presione 'ENTER' para volver a la línea de comandos: ");
        Console.ForegroundColor = ConsoleColor.White;
        comandos.Ejecutar();
    }
}