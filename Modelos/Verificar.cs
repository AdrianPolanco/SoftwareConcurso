namespace Controladores;

class Verificar
{

    public bool VerificarMatricula(string matricula)
    {
        if (matricula.Length != 9)
        {
            return false;
        }

        int numero1;
        int numero2;
        if (int.TryParse(matricula.Substring(0, 4), out numero1) && int.TryParse(matricula.Substring(5, 4), out numero2) && matricula.Substring(4, 1) == "-" && matricula.Length == 9)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool VerificarParticipacion(string opcion)
    {
        int numero;
        bool opcionNumero = int.TryParse(opcion, out numero);
        bool participaFinal;
        if (numero == 1)
        {
            participaFinal = true;
            return participaFinal;
        }
        else
        {
            participaFinal = false;
            return participaFinal;
        }
    }
}