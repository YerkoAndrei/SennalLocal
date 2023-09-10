using static Constantes;

public class ElementoOpcion
{
    public string texto;
    public bool yaElegido;
    public ElementoDialogo siguienteDiálogo;
    public RespuestasClave respuestaClave;

    public ElementoOpcion (string texto, ElementoDialogo siguienteDiálogo, RespuestasClave respuestaClave = RespuestasClave.nada)
    {
        this.texto = texto;
        this.yaElegido = SistemaMemoria.VerificarOpción(texto);
        this.siguienteDiálogo = siguienteDiálogo;
        this.respuestaClave = respuestaClave;
    }
}
