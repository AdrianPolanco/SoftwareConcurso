using Controladores;
using SelectorAleatorioDefinitivo.Modelos;
using Vistas;

Principal main = new Principal();
//main.Ejecutar();

int contadorMinutos = 0;
int contadorSegundos = 15;

for(int m = contadorMinutos; m >= 0; m--){
    for(int s = (m == contadorMinutos ? contadorSegundos : 59); s >= 0; s--){
        Console.Clear();
        Console.WriteLine($"Ejecutando cronometro {(m >= 10? m.ToString() : "0" + m)}:{(s >= 10? s.ToString() : "0" + s)}");
        Thread.Sleep(1000);
    }
}

Console.WriteLine("Tiempo agotado!");

    






