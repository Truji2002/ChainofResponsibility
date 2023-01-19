abstract class Encargado
{
    protected Encargado _sucesor;

    public void EstablecerSucesor(Encargado sucesor)
    {
        _sucesor = sucesor;
    }

    public abstract void ProcesarPeticion(Solicitud solicitud);
}

class Gerente : Encargado
{
    public override void ProcesarPeticion(Solicitud solicitud)
    {
        if (solicitud.Monto < 5000.0)
        {
            Console.WriteLine("Solicitud aprobada por el gerente.");
        }
        else if (_sucesor != null)
        {
            _sucesor.ProcesarPeticion(solicitud);
        }
    }
}

class Director : Encargado
{
    public override void ProcesarPeticion(Solicitud solicitud)
    {
        if (solicitud.Monto < 10000.0)
        {
            Console.WriteLine("Solicitud aprobada por el director.");
        }
        else if (_sucesor != null)
        {
            _sucesor.ProcesarPeticion(solicitud);
        }
    }
}

class VicePresidente : Encargado
{
    public override void ProcesarPeticion(Solicitud solicitud)
    {
        if (solicitud.Monto < 15000.0)
        {
            Console.WriteLine("Solicitud aprobada por el vicepresidente.");
        }
        else
        {
            Console.WriteLine("La solicitud necesita ser aprobada por el Presidente.");
        }
    }
}

class Solicitud
{
    public double Monto { get; set; }
    public string Propósito { get; set; }
}

class Programa
{
    static void Main(string[] args)
    {
        Encargado gerente = new Gerente();
        Encargado director = new Director();
        Encargado vicePresidente = new VicePresidente();

        gerente.EstablecerSucesor(director);
        director.EstablecerSucesor(vicePresidente);

        Solicitud solicitud = new Solicitud { Monto = 12000.0, Propósito = "Nuevo Servidor" };
        gerente.ProcesarPeticion(solicitud);

       
    }
}