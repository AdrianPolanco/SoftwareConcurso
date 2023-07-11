using ConsoleTables;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;

class Actualizar{
    Verificar verificar = new Verificar();
    ControladorCRUD controlador = new ControladorCRUD();

    public void Ejecutar(){

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(@"
  ___   _____  _____  _   _   ___   _      _____  ______  ___  ______ 
 / _ \ /  __ \|_   _|| | | | / _ \ | |    |_   _||___  / / _ \ | ___ \
/ /_\ \| /  \/  | |  | | | |/ /_\ \| |      | |     / / / /_\ \| |_/ /
|  _  || |      | |  | | | ||  _  || |      | |    / /  |  _  ||    / 
| | | || \__/\  | |  | |_| || | | || |____ _| |_ ./ /___| | | || |\ \ 
\_| |_/ \____/  \_/   \___/ \_| |_/\_____/ \___/ \_____/\_| |_/\_| \_|
                                                                      
                                                                      
");
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("Si deseas actualizar Id escribe 'ID', si deses actualizar por Matrícula escribe 'MATR': ");
        string valor = Console.ReadLine().ToUpper();

        switch (valor)
        {
            case "ID":
                ActualizarParticipante("ID");
                break;
            case "MATR":
                ActualizarParticipante("MATR");
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

    public void ActualizarParticipante(string config){

        ConsoleTable tablaResultado = new ConsoleTable("Id", "Nombre", "Apellido", "Matrícula");

        DatosParticipante resultados = new DatosParticipante();
        
        if(config == "ID"){
            Console.Write("Inserta el ID del estudiante que deseas actualizar: ");
            string id = Console.ReadLine();
            bool existe = controlador.ChequearId(id);
            if(existe){
                DatosParticipante datosEstudiante = controlador.BuscarPorId(id);
                tablaResultado.AddRow(datosEstudiante.IdDatosParticipante, datosEstudiante.Nombre, datosEstudiante.Apellido, datosEstudiante.Matricula);
                Console.WriteLine(tablaResultado.ToStringAlternative());
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Apellido: ");
                string apellido = Console.ReadLine();
                Console.Write("Matrícula: ");
                string matricula = Console.ReadLine();
                resultados = controlador.ActualizarPorId(id, nombre, apellido, matricula);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
                DATOS ACTUALIZADOS CON EXITO
                ");
                ConsoleTable tablaActualizada = new ConsoleTable("ID", "Nombre", "Apellido", "Matricula");
                tablaActualizada.AddRow(resultados.IdDatosParticipante, resultados.Nombre, resultados.Apellido, resultados.Matricula);
                Console.WriteLine(tablaActualizada.ToStringAlternative());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ");
                Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
                Console.ReadKey();
            }else{
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No se encontro el estudiante solicitado.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ");
                Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
                Console.ReadKey();
            }
            
        }else if(config == "MATR"){
            Console.Write("Inserta la matricula del estudiante que deseas actualizar: ");
            string matriculaParametro = Console.ReadLine();
            bool matriculaCorrecta = verificar.VerificarMatricula(matriculaParametro);
            if(matriculaCorrecta){
                DatosParticipante datosEstudiante = controlador.BuscarPorMatricula(matriculaParametro);
                bool estudianteEncontrado = controlador.ChequearMatricula(matriculaParametro);
                if(estudianteEncontrado){
                tablaResultado.AddRow(datosEstudiante.IdDatosParticipante, datosEstudiante.Nombre, datosEstudiante.Apellido, datosEstudiante.Matricula);
                Console.WriteLine(tablaResultado.ToStringAlternative());
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Apellido: ");
                string apellido = Console.ReadLine();
                Console.Write("Matrícula: ");
                string matricula = Console.ReadLine();
                resultados = controlador.ActualizarPorMatricula(matriculaParametro, nombre, apellido, matricula);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
                DATOS ACTUALIZADOS CON EXITO
                ");
                ConsoleTable tablaActualizada = new ConsoleTable("ID", "Nombre", "Apellido", "Matricula");
                tablaActualizada.AddRow(resultados.IdDatosParticipante, resultados.Nombre, resultados.Apellido, resultados.Matricula);
                Console.WriteLine(tablaActualizada.ToStringAlternative());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ");
                Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
                Console.ReadKey();
                }else{
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"No se encontraron resultados, la matricula {matriculaParametro} no pertenece a ningún estudiante registrado.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ");
                    Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
                    Console.ReadKey();
                }
                
            }else{
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"ERROR: Formato incorrecto, no se admiten cadenas que no tengan 9 caracteres, el formato de este campo es, ejemplo: 2023-5487");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }
    }
}