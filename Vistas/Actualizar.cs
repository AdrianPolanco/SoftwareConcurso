using ConsoleTables;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;

class Actualizar{
    Verificar verificar = new Verificar();
    ControladorCRUD controlador = new ControladorCRUD();
    ConsoleTable tablaTitulo = new ConsoleTable("ACTUALIZAR");
    public void Ejecutar(){

        Console.WriteLine(tablaTitulo.ToStringAlternative());

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
                Console.WriteLine("Parametro inválido");
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

                Console.WriteLine(@"
                DATOS ACTUALIZADOS CON EXITO
                ");
                ConsoleTable tablaActualizada = new ConsoleTable("ID", "Nombre", "Apellido", "Matricula");
                tablaActualizada.AddRow(resultados.IdDatosParticipante, resultados.Nombre, resultados.Apellido, resultados.Matricula);
                Console.WriteLine(tablaActualizada.ToStringAlternative());
            }else{
                Console.WriteLine("No se encontro el estudiante solicitado.");
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

                Console.WriteLine(@"
                DATOS ACTUALIZADOS CON EXITO
                ");
                ConsoleTable tablaActualizada = new ConsoleTable("ID", "Nombre", "Apellido", "Matricula");
                tablaActualizada.AddRow(resultados.IdDatosParticipante, resultados.Nombre, resultados.Apellido, resultados.Matricula);
                Console.WriteLine(tablaActualizada.ToStringAlternative());
                }else{
                    Console.WriteLine($"No se encontraron resultados, la matricula {matriculaParametro} no pertenece a ningún estudiante registrado.");
                }
                
            }else{
                Console.WriteLine(@"ERROR: Formato incorrecto, no se admiten cadenas que no tengan 9 caracteres, el formato de este campo es, ejemplo: 2023-5487");
            }
            
        }
    }
}