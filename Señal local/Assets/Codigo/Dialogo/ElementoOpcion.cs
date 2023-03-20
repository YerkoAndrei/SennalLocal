public class ElementoOpcion
{
    public string texto;
    public ElementoDialogo siguienteDiálogo;

    public ElementoOpcion (string texto, ElementoDialogo siguienteDiálogo)
    {
        this.texto = texto;
        this.siguienteDiálogo = siguienteDiálogo;
    }
}
