using ConsoleTables;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;

class Eliminar
{
    Verificar verificar = new Verificar();
    ControladorCRUD controlador = new ControladorCRUD();

    public void Ejecutar()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(@"
        
 _____  _      _____ ___  ___ _____  _   _   ___  ______ 
|  ___|| |    |_   _||  \/  ||_   _|| \ | | / _ \ | ___ \
| |__  | |      | |  | .  . |  | |  |  \| |/ /_\ \| |_/ /
|  __| | |      | |  | |\/| |  | |  | . ` ||  _  ||    / 
| |___ | |____ _| |_ | |  | | _| |_ | |\  || | | || |\ \ 
\____/ \_____/ \___/ \_|  |_/ \___/ \_| \_/\_| |_/\_| \_|
                                                         
                                                         
        ");
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Si deseas eliminar Id escribe 'ID', si deseas eliminar por Matrícula escribe 'MATR', si deseas eliminar varios estudiantes escribe 'MANY': ");
        string valor = Console.ReadLine();

        switch (valor)
        {
            case "ID":
                EliminarEstudiantePorId();
                break;
            case "MATR":
                EliminarEstudiantePorMatricula();
                break;
            case "MANY":
                EliminarMuchosEstudiantesPorId();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Parametro inválido");
                Console.ForegroundColor = ConsoleColor.White;
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
            Console.ForegroundColor = ConsoleColor.Red;
            tablaResultado.AddRow(datosEstudiante.IdDatosParticipante, datosEstudiante.Nombre, datosEstudiante.Apellido,datosEstudiante.Matricula);
            Console.WriteLine(tablaResultado.ToStringAlternative());
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"
Estos son los datos del estudiante que deseas eliminar, ¿estas seguro que deseas eliminarlo? Escribe 'SI', de lo contrario, escribe cualquier otra cosa para cancelar la operación: ");
            string respuesta = Console.ReadLine();
            respuesta = respuesta.ToUpper();
            if (respuesta == "SI")
            {
                    resultados = controlador.EliminarEstudiantePorId(idParametro);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"
                DATOS ELIMINADOS CON EXITO
                ");
                ConsoleTable tablaActualizada = new ConsoleTable("ID", "Nombre", "Apellido", "Matricula");
                tablaActualizada.AddRow(resultados.IdDatosParticipante, resultados.Nombre, resultados.Apellido, resultados.Matricula);
                Console.WriteLine(tablaActualizada.ToStringAlternative());
                Console.ForegroundColor = ConsoleColor.White;
            }else { 
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Operacion cancelada..."); 
                }
            }else{
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"No se encontraron resultados,el usuario con el ID {idParametro} no pertenece a ningún estudiante.");
                Console.ForegroundColor = ConsoleColor.White;
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
                Console.ForegroundColor = ConsoleColor.Red;
                tablaResultado.AddRow(datosEstudiante.IdDatosParticipante, datosEstudiante.Nombre, datosEstudiante.Apellido, datosEstudiante.Matricula);
                Console.WriteLine(tablaResultado.ToStringAlternative());
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(@"
Estos son los datos del estudiante que deseas eliminar, ¿estas seguro que deseas eliminarlo? Escribe 'SI', de lo contrario, escribe cualquier otra cosa para cancelar la operación: ");
                string respuesta = Console.ReadLine();
                respuesta = respuesta.ToUpper();
                if (respuesta == "SI")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    resultados = controlador.EliminarEstudiantePorMatricula(matriculaParametro);
                    Console.WriteLine(@"
                DATOS ELIMINADOS CON EXITO
                ");

                    ConsoleTable tablaEliminada = new ConsoleTable("ID", "Nombre", "Apellido", "Matricula");
                    tablaEliminada.AddRow(resultados.IdDatosParticipante, resultados.Nombre, resultados.Apellido, resultados.Matricula);
                    Console.WriteLine(tablaEliminada.ToStringAlternative());                
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.White;
                     Console.WriteLine("Operacion cancelada...");
                    }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"No se encontraron resultados, la matricula {matriculaParametro} no pertenece a ningún estudiante registrado.");
                Console.ForegroundColor = ConsoleColor.White;
                Ejecutar();
            }
        }else{
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"ERROR: Formato incorrecto, no se admiten cadenas que no tengan 9 caracteres, el formato de este campo es, ejemplo: 2023-5487");
            Console.ForegroundColor = ConsoleColor.White;
            Ejecutar();
        }
    }

    public void EliminarMuchosEstudiantesPorId(){
         Console.Write("Introduce los ID de LOS ESTUDIANTES a los que quieres eliminar: ");
        string[] estudiantes = Console.ReadLine().Split(" ");
        int contador = 0;
        foreach(string estudiante in estudiantes){
            int num;
            bool convertido = int.TryParse(estudiante, out num);

            if(convertido){
                contador += 1;
            }
        }
        if(contador == estudiantes.Length){
            controlador.EliminarMuchosEstudiantes(estudiantes);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Todos los estudiantes han sido eliminados.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
        }else{
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("ERROR: Uno de los ID que introduciste NO es válido, solo se admiten números.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a intentarlo: ");
        }
    }
}