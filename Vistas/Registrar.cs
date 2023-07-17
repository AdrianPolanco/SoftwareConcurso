using ConsoleTables;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;

namespace Vistas;

class Registrar
{
    Comandos comandos = new Comandos();
    Verificar verificar = new Verificar();
    ControladorCRUD controladorCreate = new ControladorCRUD();
    public void Ejecutar()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"

    ____     ______   ______    ____   _____  ______    ____     ___     ____ 
   / __ \   / ____/  / ____/   /  _/  / ___/ /_  __/   / __ \   /   |   / __ \
  / /_/ /  / __/    / / __     / /    \__ \   / /     / /_/ /  / /| |  / /_/ /
 / _, _/  / /___   / /_/ /   _/ /    ___/ /  / /     / _, _/  / ___ | / _, _/ 
/_/ |_|  /_____/   \____/   /___/   /____/  /_/     /_/ |_|  /_/  |_|/_/ |_|  
                                                                              

       
       ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Matrícula(Formato admitido: Numero de 9 digitos numericos con guión), ej: 2022-5874: ");
        string matricula = Console.ReadLine();
        bool esValida = verificar.VerificarMatricula(matricula);
        while(!esValida){
            Console.WriteLine(@"ERROR: Formato incorrecto, no se admiten cadenas que no tengan 9 caracteres, el formato de este campo es, ejemplo: 2023-5487");
            Console.Write("Inserte nuevamente la matrícula: ");
            matricula = Console.ReadLine();
            esValida = verificar.VerificarMatricula(matricula);
        }
        Console.Write("Participa(Formato admitido: 1 si participa, cualquier otro numero si no participa):");
        string participaInicial = Console.ReadLine(); 
        Console.Clear();
        bool participa = verificar.VerificarParticipacion(participaInicial);

        DatosParticipante participante = new DatosParticipante()
        {
            Nombre = nombre,
            Apellido = apellido,
            Matricula = matricula,
            Participa = participa
        };

        try{
            ConsoleTable tablaRegistro = new ConsoleTable("Nombre", "Apellido", "Matricula", "Participa");
            controladorCreate.CrearDatos(participante);
            tablaRegistro.AddRow(participante.Nombre, participante.Apellido, participante.Matricula, (bool) participante.Participa? "Sí": "No"); 
            string tablaRegistroVisible = tablaRegistro.ToStringAlternative();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
            ¡Estudiante creado con exito!
            
            DATOS REGISTRADOS:

            ");
            Console.WriteLine(tablaRegistroVisible);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Presione 'ENTER' para volver a la línea de comandos: ");
        }catch(Exception err){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Algo ha ido mal en el registro.");
            Console.ForegroundColor = ConsoleColor.White;
        } 
    }

}
