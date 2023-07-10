using Controladores;
using SelectorAleatorioDefinitivo.Modelos;
using Vistas;

Principal main = new Principal();
//main.Ejecutar();

ArchivoTXT archivoTXT = new ArchivoTXT();
archivoTXT.AbrirArchivo();
archivoTXT.MonitorearArchivo();

while(true){
    Thread.Sleep(1000);
}




