using ConsoleTables;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;

class Status{
    ControladorCRUD controlador = new ControladorCRUD();
    ConsoleTable tabla = new ConsoleTable("ID", "Nombre", "Apellido", "Matrícula", "Participa");
    Verificar verificador = new Verificar();
    public void CambiarEstadoPorId(){
        Console.Write("Introduzca el ID a la que desea cambiar el estado: ");
        string comandoId = Console.ReadLine();

        bool existe = controlador.ChequearId(comandoId);
        if(existe){
            DatosParticipante participante = controlador.CambiarStatusPorId(comandoId);
            tabla.AddRow(participante.IdDatosParticipante, participante.Nombre, participante.Apellido, participante.Matricula,
             (bool) participante.Participa? "Sí": "No");
            string tablaMostrar = tabla.ToStringAlternative();
            Console.WriteLine("Estado del participante cambiado con exito: ");
            Console.WriteLine(tablaMostrar);
        }else{
            Console.WriteLine("Parametro no existente");
        }
    }

     public void CambiarEstadoPorMatricula(){
        Console.Write("Introduzca la matrícula a la que desea cambiar el estado: ");
        string comandoMatricula = Console.ReadLine();
        

        bool existe = controlador.ChequearMatricula(comandoMatricula);
        bool esMatricula = verificador.VerificarMatricula(comandoMatricula);
        if(existe && esMatricula){
            DatosParticipante participante = controlador.CambiarStatusPorMatricula(comandoMatricula);
            tabla.AddRow(participante.IdDatosParticipante, participante.Nombre, participante.Apellido, participante.Matricula,
             (bool) participante.Participa? "Sí": "No");
            string tablaMostrar = tabla.ToStringAlternative();
            Console.WriteLine("Estado del participante cambiado con exito: ");
            Console.WriteLine(tablaMostrar);
        }else{
            Console.WriteLine("ERROR: Parametro no existente en la base de datos. Verifica el formato de la matrícula o si esta matrícula esta registrada.");
        }
    }
}