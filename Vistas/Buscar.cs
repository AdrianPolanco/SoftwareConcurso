using ConsoleTables;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;

class Buscar {

    ControladorCRUD controlador = new ControladorCRUD();
    public void Ejecutar(){
        ConsoleTable tablaTitulo = new ConsoleTable("BUSCAR");
        
        Console.WriteLine(tablaTitulo.ToStringAlternative());

        Console.Write("Si deseas buscar por Id escribe 'ID', si deses buscar por Matrícula escribe 'MATR'");
        string valor = Console.ReadLine();

        switch(valor){
            case "ID":
                BuscarEstudiante("ID");
                break;
            case "MATR":
                break;
            default:
                Console.WriteLine("Parametro inválido");
                Ejecutar();
                break;

        }
    }

    public void BuscarEstudiante(string config){
        ConsoleTable tablaResultado = new ConsoleTable("Id", "Nombre", "Apellido", "Matrícula", "Participa");

        DatosParticipante resultados = new DatosParticipante();
        if(config == "ID"){
            Console.Write("Inserta el ID del estudiante que deseas buscar: ");
            string id = Console.ReadLine();
            resultados = controlador.BuscarPorId(id); 
        }else if(config == "MATR"){

        }
        

        if(resultados != null){
            tablaResultado.AddRow(resultados.IdDatosParticipante, resultados.Nombre, resultados.Apellido, resultados.Matricula, (bool) resultados.Participa ? "Sí" : "No");
            Console.WriteLine(tablaResultado.ToStringAlternative());
        }else{
            Console.WriteLine(@"
            Resultados no encontrados.
            ");
        }
    }
}