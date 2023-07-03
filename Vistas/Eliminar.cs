using ConsoleTables;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;

class Eliminar
{
    Verificar verificar = new Verificar();
    ControladorCRUD controlador = new ControladorCRUD();
    ConsoleTable tablaTitulo = new ConsoleTable("ELIMINAR");

    public void Ejecutar()
    {

        Console.WriteLine(tablaTitulo.ToStringAlternative());

        Console.Write("Si deseas actualizar Id escribe 'ID', si deses actualizar por Matrícula escribe 'MATR': ");
        string valor = Console.ReadLine();

        switch (valor)
        {
            case "ID":
                EliminarEstudiantePorId();
                break;
            case "MATR":
                EliminarEstudiantePorMatricula();
                break;
            default:
                Console.WriteLine("Parametro inválido");
                Ejecutar();
                break;
        }
    }

    public void EliminarEstudiantePorId()
    {
        ConsoleTable tablaResultado = new ConsoleTable("Id", "Nombre", "Apellido", "Matrícula");

        DatosParticipante resultados = new DatosParticipante();

        Console.Write("Inserta el ID del estudiante que deseas eliminar: ");
        string idParametro = Console.ReadLine();
        bool idCorrecto = controlador.ChequearId(idParametro);
        if (idCorrecto)
        {
            DatosParticipante datosEstudiante = controlador.BuscarPorId(idParametro);
            tablaResultado.AddRow(datosEstudiante.IdDatosParticipante, datosEstudiante.Nombre, datosEstudiante.Apellido,datosEstudiante.Matricula);
            Console.WriteLine(tablaResultado.ToStringAlternative());
            Console.Write(@"
Estos son los datos del estudiante que deseas eliminar, ¿estas seguro que deseas eliminarlo? Escribe 'SI', de lo contrario, escribe cualquier otra cosa para cancelar la operación: ");
            string respuesta = Console.ReadLine();
            respuesta = respuesta.ToUpper();
            if (respuesta == "SI")
            {
                    resultados = controlador.EliminarEstudiantePorId(idParametro);
                    Console.WriteLine(@"
                DATOS ELIMINADOS CON EXITO
                ");
                ConsoleTable tablaActualizada = new ConsoleTable("ID", "Nombre", "Apellido", "Matricula");
                tablaActualizada.AddRow(resultados.IdDatosParticipante, resultados.Nombre, resultados.Apellido, resultados.Matricula);
                Console.WriteLine(tablaActualizada.ToStringAlternative());
            }else { 
                Console.WriteLine("Operacion cancelada..."); 
                }
            }else{
            Console.WriteLine($"No se encontraron resultados,el usuario con el ID {idParametro} no pertenece a ningún estudiante.");
                Ejecutar();
        }
    }

    public void EliminarEstudiantePorMatricula()
    {
        ConsoleTable tablaResultado = new ConsoleTable("Id", "Nombre", "Apellido", "Matrícula");

        DatosParticipante resultados = new DatosParticipante();

        Console.Write("Inserta la matricula del estudiante que deseas eliminar: ");
        string matriculaParametro = Console.ReadLine();
        bool matriculaCorrecta = verificar.VerificarMatricula(matriculaParametro);
        if (matriculaCorrecta)
        {
            DatosParticipante datosEstudiante = controlador.BuscarPorMatricula(matriculaParametro);
            bool estudianteEncontrado = controlador.ChequearMatricula(matriculaParametro);
            if (estudianteEncontrado)
            {
                tablaResultado.AddRow(datosEstudiante.IdDatosParticipante, datosEstudiante.Nombre, datosEstudiante.Apellido, datosEstudiante.Matricula);
                Console.WriteLine(tablaResultado.ToStringAlternative());
                Console.Write(@"
Estos son los datos del estudiante que deseas eliminar, ¿estas seguro que deseas eliminarlo? Escribe 'SI', de lo contrario, escribe cualquier otra cosa para cancelar la operación: ");
                string respuesta = Console.ReadLine();
                respuesta = respuesta.ToUpper();
                if (respuesta == "SI")
                {
                    resultados = controlador.EliminarEstudiantePorMatricula(matriculaParametro);
                    Console.WriteLine(@"
                DATOS ELIMINADOS CON EXITO
                ");
                    ConsoleTable tablaActualizada = new ConsoleTable("ID", "Nombre", "Apellido", "Matricula");
                    tablaActualizada.AddRow(resultados.IdDatosParticipante, resultados.Nombre, resultados.Apellido, resultados.Matricula);
                    Console.WriteLine(tablaActualizada.ToStringAlternative());
                }
                else { Console.WriteLine("Operacion cancelada..."); }
            }
            else
            {
                Console.WriteLine($"No se encontraron resultados, la matricula {matriculaParametro} no pertenece a ningún estudiante registrado.");
                Ejecutar();
            }
        }else{
            Console.WriteLine(@"ERROR: Formato incorrecto, no se admiten cadenas que no tengan 9 caracteres, el formato de este campo es, ejemplo: 2023-5487");
            Ejecutar();
        }
    }
}