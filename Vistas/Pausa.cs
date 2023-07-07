class Esperar{
    public static void Pausa(){
        DateTime currentTime = DateTime.Now;

        TimeSpan waiting = TimeSpan.FromSeconds(2);
        Console.Clear();
        while(DateTime.Now - currentTime < waiting){

        }
        
    }
}