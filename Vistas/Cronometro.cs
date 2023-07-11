namespace Vistas;

class Cronometro{
    public void Iniciar(int minutos, int segundos){
        int contadorMinutos = minutos;
        int contadorSegundos = segundos;

        for(int m = contadorMinutos; m >= 0; m--){
            for(int s = (m == contadorMinutos ? contadorSegundos : 59); s >= 0; s--){
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ejecutando cronometro: ");
                if(m == 0 && s <= 5){
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine($"{(m >= 10? m.ToString() : "0" + m)}:{(s >= 10? s.ToString() : "0" + s)}");
                Thread.Sleep(1000);
                
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
}