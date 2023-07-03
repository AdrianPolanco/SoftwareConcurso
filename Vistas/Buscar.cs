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
        ConsoleTable tablaTitulo = new ConsoleTable("BUSCAR");

        Console.WriteLine(tablaTitulo.ToStringAlternative());

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
                Console.WriteLine("Parametro inválido");
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
                Console.WriteLine(@"ERROR: Formato incorrecto, no se admiten cadenas que no tengan 9 caracteres, el formato de este campo es, ejemplo: 2023-5487");
                Console.Write("Inserte nuevamente la matrícula: ");
                matricula = Console.ReadLine();
                esValida = verificar.VerificarMatricula(matricula);
            }
            resultados = controlador.BuscarPorMatricula(matricula);
        }


        if (resultados != null)
        {
            tablaResultado.AddRow(resultados.IdDatosParticipante, resultados.Nombre, resultados.Apellido, resultados.Matricula, (bool)resultados.Participa ? "Sí" : "No");
            Console.WriteLine(tablaResultado.ToStringAlternative());
        }
        else
        {
            Console.WriteLine(@"
            Resultados no encontrados.
            ");
        }
    }
}