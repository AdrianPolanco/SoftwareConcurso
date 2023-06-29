using ConsoleTables;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;

namespace Vistas;

class Registrar
{
    Comandos comandos = new Comandos();
    ControladorCRUD controladorCreate = new ControladorCRUD();
    public void Ejecutar()
    {
        Console.WriteLine(@"
        ________________________________________________________
       |                REGISTRAR PARTICIPANTE                  |
       |________________________________________________________|
       
       ");

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Matrícula(Formato admitido: Numero de 9 digitos numericos con guión), ej: 2022-5874: ");
        string matricula = Console.ReadLine();
        bool esValida = VerificarMatricula(matricula);
        while(!esValida){
            Console.WriteLine(@"ERROR: Formato incorrecto, no se admiten cadenas que no tengan 9 caracteres, el formato de este campo es, ejemplo: 2023-5487");
            Console.Write("Inserte nuevamente la matrícula:");
            matricula = Console.ReadLine();
            esValida = VerificarMatricula(matricula);
        }
        Console.Write("Participa(Formato admitido: 1 si participa o 0 si no participa):");
        string participaInicial = Console.ReadLine();
        bool participa = VerificarParticipacion(participaInicial);

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

            Console.WriteLine(@"
            ¡Estudiante creado con exito!
            
            DATOS REGISTRADOS:

            ");
            Console.WriteLine(tablaRegistroVisible);

        }catch(Exception err){
            Console.WriteLine("Algo ha ido mal en el registro.");
        }finally{
            comandos.Ejecutar();
        }

        
    }

    public bool VerificarMatricula(string matricula)
    {
        if (matricula.Length != 9)
        {
            return false;
        }

        int numero1;
        int numero2;
        if (int.TryParse(matricula.Substring(0, 4), out numero1) && int.TryParse(matricula.Substring(5, 4), out numero2) && matricula.Substring(4,1) == "-" && matricula.Length == 9)
        {
            return true;
        }
        else
        {  
            return false;
        }
    }

    public bool VerificarParticipacion(string opcion){
        int numero;
        bool opcionNumero = int.TryParse(opcion, out numero);
        bool participaFinal;
        if(numero== 1){
            participaFinal = true;
            return participaFinal;
        }else{
            participaFinal = false;
            return participaFinal;
        }
    }
}
