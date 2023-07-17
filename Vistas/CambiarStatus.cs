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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Estado del participante cambiado con exito: ");
            Console.WriteLine(tablaMostrar);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
        }else{
            Console.WriteLine("Parametro no existente");
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Estado del participante cambiado con exito: ");
            Console.WriteLine(tablaMostrar);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
        }else{
            Console.WriteLine("ERROR: Parametro no existente en la base de datos. Verifica el formato de la matrícula o si esta matrícula esta registrada.");
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
        }
    }

    public void CambiarMuchosEstados(){
        Console.Write("Introduce los ID de LOS ESTUDIANTES a los que quieres cambiar el estado: ");
        string[] estudiantes = Console.ReadLine().Split(" ");
        int contador = 0;
        foreach(string estudiante in estudiantes){
            int num;
            bool convertido = int.TryParse(estudiante, out num);

            if(convertido){
                contador += 1;
            }
        }
        try{
            if(contador == estudiantes.Length){
            controlador.CambiarMuchosStatus(estudiantes); 
            Console.WriteLine("Todos los estudiantes han sido cambiados de estado.");
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
        }else{
            Console.WriteLine("ERROR: Uno de los ID que introduciste NO es válido, solo se admiten números.");
            Console.WriteLine(" ");
            Console.Write("Presione 'ENTER' para volver a intentarlo: ");

        }}catch{
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("ERROR: UNO DE LOS ID QUE INSERTASTE NO EXISTE EN LA BASE DE DATOS");
            Console.ForegroundColor = ConsoleColor.White;
            }

    }
}