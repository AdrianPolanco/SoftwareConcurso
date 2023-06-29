namespace Vistas;

class Principal{
    public void Ejecutar(){
        OperacionesParticipantes operacion = new OperacionesParticipantes();
        Comandos comandos = new Comandos();
        operacion.LeerParticipantes();
        comandos.Ejecutar();
    }
}