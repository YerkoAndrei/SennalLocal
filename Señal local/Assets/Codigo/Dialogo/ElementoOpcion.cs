public class ElementoOpcion
{
    public string texto;
    public ElementoDialogo siguienteDiálogo;
    public bool yaElegido;

    public ElementoOpcion (string texto, ElementoDialogo siguienteDiálogo)
    {
        this.texto = texto;
        this.siguienteDiálogo = siguienteDiálogo;

        // Pruebas sin sistema
        if (SistemaMemoria.instancia != null)
            yaElegido = SistemaMemoria.instancia.VerificarOpción(texto);
    }
}
