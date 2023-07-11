namespace Vistas;

class Principal{
    public void Ejecutar(){
        OperacionesParticipantes operacion = new OperacionesParticipantes();
        Comandos comandos = new Comandos();
        //Console.BackgroundColor = ConsoleColor.White;
        //Console.ForegroundColor = ConsoleColor.Black;
        operacion.LeerParticipantes();
        comandos.Ejecutar();
    }
}