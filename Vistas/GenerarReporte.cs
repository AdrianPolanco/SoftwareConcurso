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

    public string CrearTemplateSeleccionados(){
        List<Seleccionado> seleccionados = controlador.LeerHistorialSeleccionados();

        string html = htmlPlantilla.CrearSeleccionados(seleccionados);

        return html;
    }

    public string CrearTemplateDesarrolladores(){
        List<Seleccionado> seleccionados = controlador.LeerHistorialSeleccionados();
        List<Resultado> resultados = controlador.LeerDesarrolladoresSeleccionados();

        string html = htmlPlantilla.CrearDesarrolladores(seleccionados, resultados);

        return html;
    }

    public void CrearDocumento(){
        string html = CrearTemplate();
        string carpeta = @$"C:\Users\adfer\OneDrive\Escritorio\SoftwareConcurso\SoftwareConcurso\Vistas\static\Reportes\Generales\ReportesGeneralReport-{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf";
        PdfDocument document = new PdfDocument();
        HtmlToPdf converter = new HtmlToPdf();

        PdfDocument pdf = converter.ConvertHtmlString(html,@"C:\Users\adfer\OneDrive\Escritorio\SoftwareConcurso\SoftwareConcurso\Vistas\static\output.css");
        pdf.Save(carpeta);
        pdf.Close();
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

    public void CrearDocumentoSeleccionados(){
        string html = CrearTemplateSeleccionados();
        string carpeta = @$"C:\Users\adfer\OneDrive\Escritorio\SoftwareConcurso\SoftwareConcurso\Vistas\static\Reportes\Seleccionados\SelectedReport-{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf";
        PdfDocument document = new PdfDocument();
        HtmlToPdf converter = new HtmlToPdf();

        PdfDocument pdf = converter.ConvertHtmlString(html,@"C:\Users\adfer\OneDrive\Escritorio\SoftwareConcurso\SoftwareConcurso\Vistas\static\styles.css");
        pdf.Save(carpeta);
        pdf.Close();
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

    public void CrearDocumentoDesarrolladores(){
        string html = CrearTemplateDesarrolladores();
        string carpeta = @$"C:\Users\adfer\OneDrive\Escritorio\SoftwareConcurso\SoftwareConcurso\Vistas\static\Reportes\Desarrolladores\DeveloperReport-{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf";
        PdfDocument document = new PdfDocument();
        HtmlToPdf converter = new HtmlToPdf();

        PdfDocument pdf = converter.ConvertHtmlString(html,@"C:\Users\adfer\OneDrive\Escritorio\SoftwareConcurso\SoftwareConcurso\Vistas\static\styles.css");
        pdf.Save(carpeta);
        pdf.Close();
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
