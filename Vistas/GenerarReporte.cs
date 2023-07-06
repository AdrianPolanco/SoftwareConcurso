namespace Vistas;

using System.Diagnostics;
using Controladores;
using SelectorAleatorioDefinitivo.Modelos;
using SelectPdf;

class GenerarReporte{
    ControladorCRUD controlador = new ControladorCRUD();

    Plantilla htmlPlantilla = new Plantilla();
    public string CrearTemplate(){
        List<DatosParticipante> listaGeneral = controlador.ObtenerDatos();
        List<DatosParticipante> activos = new List<DatosParticipante>();
        List<DatosParticipante> inactivos = new List<DatosParticipante>();

        foreach(DatosParticipante estudiante in listaGeneral){
            if((bool)estudiante.Participa){
                activos.Add(estudiante);
            }else{
                inactivos.Add(estudiante);
            }
        }

        string html = htmlPlantilla.Crear(activos, inactivos);

        return html;
    }

    public void CrearDocumento(){
        string html = CrearTemplate();
        string carpeta = @$"C:\Users\adfer\OneDrive\Escritorio\SoftwareConcurso\SoftwareConcurso\Vistas\static\Reportes\ReportesGeneralReport-{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf";
        
        HtmlToPdf converter = new HtmlToPdf();

        PdfDocument pdf = converter.ConvertHtmlString(html,@"C:\Users\adfer\OneDrive\Escritorio\SoftwareConcurso\SoftwareConcurso\Vistas\static\output.css");
        pdf.Save(carpeta);
         ProcessStartInfo psi = new ProcessStartInfo
    {
        FileName = "cmd",
        RedirectStandardInput = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    Process process = new Process();
    process.StartInfo = psi;
    process.Start();

    using (StreamWriter sw = process.StandardInput)
    {
        if (sw.BaseStream.CanWrite)
        {
            sw.WriteLine(@"start " + carpeta);
        }
    }

    process.WaitForExit();
    }
}