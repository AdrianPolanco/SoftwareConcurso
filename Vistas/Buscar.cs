using ConsoleTables;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;
namespace Vistas;

class Buscar
{
    Verificar verificar = new Verificar();
    ControladorCRUD controlador = new ControladorCRUD();
    public void Ejecutar()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"
______  _   _  _____  _____   ___  ______ 
| ___ \| | | |/  ___|/  __ \ / _ \ | ___ \
| |_/ /| | | |\ `--. | /  \// /_\ \| |_/ /
| ___ \| | | | `--. \| |    |  _  ||    / 
| |_/ /| |_| |/\__/ /| \__/\| | | || |\ \ 
\____/  \___/ \____/  \____/\_| |_/\_| \_|
                                          
                                    
        ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Si deseas buscar por Id escribe 'ID', si deses buscar por Matrícula escribe 'MATR': ");
        string valor = Console.ReadLine().ToUpper();

        switch (valor)
        {
            case "ID":
                BuscarEstudiante("ID");
                break;
            case "MATR":
                BuscarEstudiante("MATR");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Parametro inválido");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ");
                Console.Write("Presione 'ENTER' para volver a intentarlo: ");
                Console.ReadKey();
                Ejecutar();
                break;
        }

    }

    public void BuscarEstudiante(string config)
    {
        ConsoleTable tablaResultado = new ConsoleTable("Id", "Nombre", "Apellido", "Matrícula", "Participa");

        DatosParticipante resultados = new DatosParticipante();
        if (config == "ID")
        {
            Console.Write("Inserta el ID del estudiante que deseas buscar: ");
            string id = Console.ReadLine();
            resultados = controlador.BuscarPorId(id);
        }
        else if (config == "MATR")
        {
            Console.Write("Inserta la matrícula del estudiante que deseas buscar: ");
            string matricula = Console.ReadLine();
            bool esValida = verificar.VerificarMatricula(matricula);
            while (!esValida)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"ERROR: Formato incorrecto, no se admiten cadenas que no tengan 9 caracteres, el formato de este campo es, ejemplo: 2023-5487");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Inserte nuevamente la matrícula: ");
                matricula = Console.ReadLine();
                esValida = verificar.VerificarMatricula(matricula);
            }
            resultados = controlador.BuscarPorMatricula(matricula);
        }


        if (resultados != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            tablaResultado.AddRow(resultados.IdDatosParticipante, resultados.Nombre, resultados.Apellido, resultados.Matricula, (bool)resultados.Participa ? "Sí" : "No");
            Console.WriteLine(tablaResultado.ToStringAlternative());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
            Console.ReadKey();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
            Resultados no encontrados.
            ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
            Console.ReadKey();
        }
    }
}