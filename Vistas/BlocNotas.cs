using Controladores;
class BlocNotas{
    ArchivoTXT archivoTXT = new ArchivoTXT();
    public void Ejecutar(){
        //archivoTXT.AbrirArchivo();
        archivoTXT.MonitorearArchivo();
    }
}