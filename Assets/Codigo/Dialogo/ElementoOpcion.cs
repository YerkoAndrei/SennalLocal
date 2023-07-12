public class ElementoOpcion
{
    public string texto;
    public ElementoDialogo siguienteDiálogo;
    public bool yaElegido;

    public ElementoOpcion (string texto, ElementoDialogo siguienteDiálogo)
    {
        this.texto = texto;
        this.siguienteDiálogo = siguienteDiálogo;
        this.yaElegido = SistemaMemoria.VerificarOpción(texto);
    }
}
