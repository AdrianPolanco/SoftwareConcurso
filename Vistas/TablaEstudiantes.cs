using Controladores;
using SelectorAleatorioDefinitivo.Modelos;
using ConsoleTables;

namespace Vistas;

public partial class OperacionesParticipantes{

    ControladorCRUD main = new ControladorCRUD();


        private List<DatosParticipante> datos = new List<DatosParticipante>();
        private List<DatosParticipante> activos = new List<DatosParticipante>();
        private List<DatosParticipante> inactivos = new List<DatosParticipante>();
        private List<Seleccionado> elegidos = new List<Seleccionado>();
        private List<Resultado> resultados = new List<Resultado>();
        
        
    public void LeerParticipantes(){
        datos = main.ObtenerDatos();
        elegidos = main.LeerHistorialSeleccionados();
        resultados = resultados = main.LeerDesarrolladoresSeleccionados();
        foreach(DatosParticipante participante in datos){
            if((bool)participante.Participa){
                activos.Add(participante);
            }else{
                inactivos.Add(participante);
            }
        }
        Console.WriteLine(@"

   _____   ______   _        ______    _____   _______    ____    _____                 _        ______              _______    ____    _____    _____    ____  
  / ____| |  ____| | |      |  ____|  / ____| |__   __|  / __ \  |  __ \        /\     | |      |  ____|     /\     |__   __|  / __ \  |  __ \  |_   _|  / __ \ 
 | (___   | |__    | |      | |__    | |         | |    | |  | | | |__) |      /  \    | |      | |__       /  \       | |    | |  | | | |__) |   | |   | |  | |
  \___ \  |  __|   | |      |  __|   | |         | |    | |  | | |  _  /      / /\ \   | |      |  __|     / /\ \      | |    | |  | | |  _  /    | |   | |  | |
  ____) | | |____  | |____  | |____  | |____     | |    | |__| | | | \ \     / ____ \  | |____  | |____   / ____ \     | |    | |__| | | | \ \   _| |_  | |__| |
 |_____/  |______| |______| |______|  \_____|    |_|     \____/  |_|  \_\   /_/    \_\ |______| |______| /_/    \_\    |_|     \____/  |_|  \_\ |_____|  \____/ 
                                                                                                                                                                
                                                                                                                                                                                                                                                                                                                                                                         

");
        ConsoleTable tablaParticipantes = new ConsoleTable("Id","Nombre", "Apellido", "Participa", "Matrícula");
        ConsoleTable tablaInactiva = new ConsoleTable("Id","Nombre", "Apellido", "Participa", "Matrícula");
        ConsoleTable tablaDesarrolladores = new ConsoleTable("Id","Nombre", "Apellido",  "Matrícula", "Fecha", "Exito");

        foreach(DatosParticipante participante in activos){
            tablaParticipantes.AddRow(participante.IdDatosParticipante, participante.Nombre, participante.Apellido, "Sí", participante.Matricula);
        }

        foreach(DatosParticipante participante in inactivos){
            tablaInactiva.AddRow(participante.IdDatosParticipante, participante.Nombre, participante.Apellido, "No", participante.Matricula);
        }

        foreach(Seleccionado seleccionado in elegidos){
            if(seleccionado.Rol == "Desarrollador en vivo"){
               foreach(Resultado resultado in resultados){
                if(resultado.IdSeleccionado == seleccionado.Id){
                    tablaDesarrolladores.AddRow(seleccionado.Id, seleccionado.Nombre, seleccionado.Apellido, seleccionado.Matricula, seleccionado.Fecha, ((bool)resultado.Exito? "Sí" : "No"));
                }
               } 
            }   
        }

        string tablaMostradaActivos = tablaParticipantes.ToStringAlternative();
        string tablaMostradaInactivos = tablaInactiva.ToStringAlternative();
        string tablaMostradaDesarrolladores = tablaDesarrolladores.ToStringAlternative();

        Console.WriteLine("Presione 'ENTER' para mostrar los participantes activos:");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"

 ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄               ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄ 
▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌             ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀  ▀▀▀▀█░█▀▀▀▀  ▀▀▀▀█░█▀▀▀▀  ▐░▌           ▐░▌ ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ 
▐░▌       ▐░▌▐░▌               ▐░▌          ▐░▌       ▐░▌         ▐░▌  ▐░▌       ▐░▌▐░▌          
▐░█▄▄▄▄▄▄▄█░▌▐░▌               ▐░▌          ▐░▌        ▐░▌       ▐░▌   ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄ 
▐░░░░░░░░░░░▌▐░▌               ▐░▌          ▐░▌         ▐░▌     ▐░▌    ▐░▌       ▐░▌▐░░░░░░░░░░░▌
▐░█▀▀▀▀▀▀▀█░▌▐░▌               ▐░▌          ▐░▌          ▐░▌   ▐░▌     ▐░▌       ▐░▌ ▀▀▀▀▀▀▀▀▀█░▌
▐░▌       ▐░▌▐░▌               ▐░▌          ▐░▌           ▐░▌ ▐░▌      ▐░▌       ▐░▌          ▐░▌
▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄      ▐░▌      ▄▄▄▄█░█▄▄▄▄        ▐░▐░▌       ▐░█▄▄▄▄▄▄▄█░▌ ▄▄▄▄▄▄▄▄▄█░▌
▐░▌       ▐░▌▐░░░░░░░░░░░▌     ▐░▌     ▐░░░░░░░░░░░▌        ▐░▌        ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
 ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀       ▀▀▀▀▀▀▀▀▀▀▀          ▀          ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀ 
                                                                                                 

        ");        
        Console.WriteLine(tablaMostradaActivos);
        Console.WriteLine(" ");
        Console.WriteLine("Presione 'ENTER' para mostrar los participantes inactivos:");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(@"

 ___      ________       ________      ________      _________    ___      ___      ___  ________      ________      
|\  \    |\   ___  \    |\   __  \    |\   ____\    |\___   ___\ |\  \    |\  \    /  /||\   __  \    |\   ____\     
\ \  \   \ \  \\ \  \   \ \  \|\  \   \ \  \___|    \|___ \  \_| \ \  \   \ \  \  /  / /\ \  \|\  \   \ \  \___|_    
 \ \  \   \ \  \\ \  \   \ \   __  \   \ \  \            \ \  \   \ \  \   \ \  \/  / /  \ \  \\\  \   \ \_____  \   
  \ \  \   \ \  \\ \  \   \ \  \ \  \   \ \  \____        \ \  \   \ \  \   \ \    / /    \ \  \\\  \   \|____|\  \  
   \ \__\   \ \__\\ \__\   \ \__\ \__\   \ \_______\       \ \__\   \ \__\   \ \__/ /      \ \_______\    ____\_\  \ 
    \|__|    \|__| \|__|    \|__|\|__|    \|_______|        \|__|    \|__|    \|__|/        \|_______|   |\_________\
                                                                                                         \|_________|
                                                                                                                     
                                                                                                                     
        
        ");
        Console.WriteLine(tablaMostradaInactivos);
        Console.WriteLine(" ");
        Console.WriteLine("Presione 'ENTER' para mostrar los desarrolladores en vivo seleccionados anteriormente:");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
    _                                              _   _               _                             
     | |                                            | | | |             | |                            
   __| |   ___   ___    __ _   _ __   _ __    ___   | | | |   __ _    __| |   ___    _ __    ___   ___ 
  / _` |  / _ \ / __|  / _` | | '__| | '__|  / _ \  | | | |  / _` |  / _` |  / _ \  | '__|  / _ \ / __|
 | (_| | |  __/ \__ \ | (_| | | |    | |    | (_) | | | | | | (_| | | (_| | | (_) | | |    |  __/ \__ \
  \__,_|  \___| |___/  \__,_| |_|    |_|     \___/  |_| |_|  \__,_|  \__,_|  \___/  |_|     \___| |___/
                                                                                                       
                                                                                                      
   ___   _ __                                                                                          
  / _ \ | '_ \                                                                                         
 |  __/ | | | |                                                                                        
  \___| |_| |_|                                                                                        
                                                                                                                                                                                                          
          _                                                                                            
         (_)                                                                                           
 __   __  _  __   __   ___                                                                             
 \ \ / / | | \ \ / /  / _ \                                                                            
  \ V /  | |  \ V /  | (_) |                                                                           
   \_/   |_|   \_/    \___/                                                                            
                                                                                                       
                                                                                                                       
        ");
        Console.WriteLine(tablaMostradaDesarrolladores);
        Console.ForegroundColor = ConsoleColor.White;

    }

    public void LeerSeleccionadosGeneral(){
        ConsoleTable tablaElegidos = new ConsoleTable("Id","Nombre", "Apellido",  "Matrícula", "Rol", "Fecha");
        elegidos = main.LeerHistorialSeleccionados();
        
        foreach(Seleccionado elegido in elegidos){
            tablaElegidos.AddRow(elegido.Id, elegido.Nombre, elegido.Apellido, elegido.Matricula, elegido.Rol, elegido.Fecha);
        }      
        string tablaMostradaElegidos = tablaElegidos.ToStringAlternative();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"

    ______           __                __    _                    __                                        __                        _                               __               
   / ____/   _____  / /_  __  __  ____/ /   (_)  ____ _   ____   / /_  ___    _____          _____  ___    / /  ___   _____  _____   (_)  ____    ____   ____ _  ____/ /  ____    _____
  / __/     / ___/ / __/ / / / / / __  /   / /  / __ `/  / __ \ / __/ / _ \  / ___/         / ___/ / _ \  / /  / _ \ / ___/ / ___/  / /  / __ \  / __ \ / __ `/ / __  /  / __ \  / ___/
 / /___    (__  ) / /_  / /_/ / / /_/ /   / /  / /_/ /  / / / // /_  /  __/ (__  )         (__  ) /  __/ / /  /  __// /__  / /__   / /  / /_/ / / / / // /_/ / / /_/ /  / /_/ / (__  ) 
/_____/   /____/  \__/  \__,_/  \__,_/   /_/   \__,_/  /_/ /_/ \__/  \___/ /____/         /____/  \___/ /_/   \___/ \___/  \___/  /_/   \____/ /_/ /_/ \__,_/  \__,_/   \____/ /____/  
                                                                                                                                                                                       

        ");
        Console.WriteLine(tablaMostradaElegidos);
        Console.ForegroundColor = ConsoleColor.White;
    }
}

