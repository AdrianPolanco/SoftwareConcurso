using Controladores;
using SelectorAleatorioDefinitivo.Modelos;
using Vistas;

Principal main = new Principal();
Buscar buscar = new Buscar();
buscar.Ejecutar();
//main.Ejecutar();

//Elegir participantes sin que se repitan

/*  Random random = new Random();

 int contador = 2;
 while(contador>0){
    int elegido = random.Next(participantes.Count);
    elegidos.Add(participantes[elegido]);

     if(elegidos.Count == 2){
         if(elegidos[0] != elegidos[1]){
             Console.WriteLine("Diferentes");
             contador -= 1;  
             //continue;
         } else{
             Console.WriteLine("Iguales");
             elegidos.Remove(elegidos[1]);
             contador += 1;
         }

     }


     contador -= 1;  


 }
 Console.WriteLine(elegidos.Count);
 Console.WriteLine("Bucle acabado");

*/
/*   Console.WriteLine($@"
        Nombre: {participantes[elegido].Nombre} 
        Apellido:{participantes[elegido].Apellido}
        Participa: {((bool)participantes[elegido].Participa? "Sí" : "No")}
        Facilitador:{((bool)participantes[elegido].EsFacilitador? "Sí" : "No")}
        Matrícula: {participantes[elegido].Matricula}");  */


