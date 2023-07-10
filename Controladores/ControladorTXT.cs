using System.Diagnostics;
using Controladores;
using Vistas;
using SelectorAleatorioDefinitivo.Modelos;

class ArchivoTXT {
    Verificar verificar = new Verificar();
    Principal main = new Principal();
    ControladorCRUD controlador = new ControladorCRUD(); 
    string RutaCompleta = Path.Combine(Directory.GetCurrentDirectory(), "ArchivoTXT", "archivo.txt");
    public DatosParticipante LeerLinea(string linea){

        DatosParticipante defaultPersona = new DatosParticipante();
        string[] datosLinea = linea.Split("|");

        string nombreUnido = "";
        string apellidoUnido = "";
        string matricula = "";
        bool participa = false;

        foreach(string palabra in datosLinea){
            //Console.WriteLine(Nombre.EsNombre(palabra));
            //Console.WriteLine(palabra);
            if(verificar.EsNombre(palabra)){
                if(Array.IndexOf(datosLinea, palabra) == 0){
                    nombreUnido = palabra;
                    nombreUnido.TrimStart().TrimEnd();  
                }
                if(Array.IndexOf(datosLinea, palabra) == 1){
                    apellidoUnido = palabra;
                    apellidoUnido.TrimStart().TrimEnd();
                }     
            }
        //Console.WriteLine(Matricula.EsMatricula(palabra));
        if(verificar.VerificarMatricula(palabra)){
            matricula = palabra;
        }

        if(Array.IndexOf(datosLinea, palabra) == 3){
            if(palabra == "1"){
                participa = true;
            }else if(palabra == "0"){
                participa = false;
            }else{
                Console.WriteLine("Formato de participacion invalido");
            }
        }

        if(nombreUnido != "" && apellidoUnido != "" && matricula != ""){
            DatosParticipante persona = new DatosParticipante(){
                Nombre = nombreUnido,
                Apellido = apellidoUnido,
                Matricula = matricula,
                Participa = participa
            };
            defaultPersona = persona;
        }
    } 
           return defaultPersona;
}

    public List<DatosParticipante> LeerArchivo(){
        List<DatosParticipante> estudiantes = new List<DatosParticipante>();
        
        
        using(StreamReader reader = new StreamReader(Path.GetFullPath(RutaCompleta))){
            string linea;

            while((linea = reader.ReadLine()) != null){
                DatosParticipante persona = LeerLinea(linea);
                estudiantes.Add(persona);
            }
        }

        return estudiantes;
    }

    public bool InsertarEstudiantes(){
        List<DatosParticipante> archivo = new List<DatosParticipante>();
        archivo = LeerArchivo();
        try{
            File.WriteAllText(RutaCompleta, string.Empty);
            foreach(DatosParticipante estudiante in archivo){
                controlador.CrearDatos(estudiante);
            }  
            return true;
        }catch(Exception ex){
            Console.WriteLine($"Error al intentar introducir los datos: {ex.Message}");
            return false;
        }
    }

    public void AbrirArchivo(){

        string BlocExe = "notepad.exe";
        ProcessStartInfo startInfo = new ProcessStartInfo{FileName = BlocExe, Arguments = RutaCompleta, UseShellExecute = true};
        Process procesoBlocNotas = Process.Start(startInfo);
        procesoBlocNotas.EnableRaisingEvents = true;
        procesoBlocNotas.Exited += (sender, e) =>
        {
            if(InsertarEstudiantes()){
                Console.WriteLine("Insercion de datos exitosa");
            }
            main.Ejecutar();
        };
    }

    public void MonitorearArchivo(){

        string RutaAbsoluta = Path.Combine(Directory.GetCurrentDirectory(), "ArchivoTXT", "archivo.txt");
        string DirectorioArchivo = Path.GetDirectoryName(RutaAbsoluta);
        string NombreArchivo = Path.GetFileName(RutaAbsoluta);

        FileSystemWatcher watcher = new FileSystemWatcher(DirectorioArchivo, NombreArchivo);

        watcher.Changed += (sender, e) =>
        {
            if(e.ChangeType == WatcherChangeTypes.Changed){
                Console.WriteLine("El Archivo se ha modificado");
            }
        };

        watcher.EnableRaisingEvents = true;


    }
}