//Interfaz del Mensaje
public interface IMensaje
{
    string getMensaje();
}
//Mensaje original
public class MensajeOriginal : IMensaje
{
    public string getMensaje()
    {
        return "Mensaje";
    }
}
//Patrón decorator -- Mensaje
public abstract class mensajeDecorador : IMensaje
{
    protected IMensaje mensaje;
    public mensajeDecorador( IMensaje mensaje)
    {
        this.mensaje = mensaje;
    }
    public abstract string getMensaje();
}
//Encriptador del mensaje
public class EncriptarMensaje : mensajeDecorador
{
    public EncriptarMensaje(IMensaje baseMensaje) : base(baseMensaje){ }
    public override string getMensaje()
    {
        return base.mensaje.getMensaje() + ", Encriptando";
    }
}
//Compresor del mensaje
public class ComprimirMensaje : mensajeDecorador
{
    public ComprimirMensaje(IMensaje baseMensaje) : base(baseMensaje) { }
    public override string getMensaje()
    {
        return base.mensaje.getMensaje() + ", Comprimiendo";
    }
}
//Firma del mensaje
public class FirmaMensaje : mensajeDecorador
{
    public FirmaMensaje(IMensaje baseMensaje) : base(baseMensaje) { }
    public override string getMensaje()
    {
        return base.mensaje.getMensaje() + ", Firmando";
    }
}
//Main
public class Programa
{
    public static void Main(string[] args)
    {
        IMensaje mensaje = new MensajeOriginal();
        Console.WriteLine(mensaje.getMensaje());

        mensaje = new FirmaMensaje(mensaje);
        Console.WriteLine(mensaje.getMensaje());

        mensaje = new EncriptarMensaje(mensaje);
        Console.WriteLine(mensaje.getMensaje());

        mensaje = new ComprimirMensaje(mensaje);
        Console.WriteLine(mensaje.getMensaje());

    }
}