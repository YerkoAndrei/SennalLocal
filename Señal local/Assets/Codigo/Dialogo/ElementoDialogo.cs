using static Constantes;

public class ElementoDialogo
{
    // Diálogo
    public Personajes personaje;
    public string texto;

    // Estructura
    public TipoDiálogo tipoDiálogo;
    public ElementoDialogo siguienteDiálogo;

    // Especiales
    public TipoFinal tipoFinal;
    public ElementoOpcion[] opciones;

    public void AsignarSiguienteDiálogo(ElementoDialogo elementoDialogo)
    {
        siguienteDiálogo = elementoDialogo;
    }

    // Crear diálogos según tipo

    // Diálogo normal
    public static ElementoDialogo CrearDiálogo(Personajes personaje, string texto)
    {
        var nuevoElemento = new ElementoDialogo();
        nuevoElemento.tipoDiálogo = TipoDiálogo.diálogo;
        nuevoElemento.personaje = personaje;
        nuevoElemento.texto = texto;

        return nuevoElemento;
    }

    // Opciones múltiples
    public static ElementoDialogo CrearOpciones(Personajes personaje, string texto, ElementoOpcion[] opciones)
    {
        var nuevoElemento = new ElementoDialogo();
        nuevoElemento.tipoDiálogo = TipoDiálogo.opciones;
        nuevoElemento.personaje = personaje;
        nuevoElemento.texto = texto;
        nuevoElemento.opciones = opciones;

        return nuevoElemento;
    }

    // Escribir mensaje
    public static ElementoDialogo CrearPregunta(Personajes personaje, string texto)
    {
        var nuevoElemento = new ElementoDialogo();
        nuevoElemento.tipoDiálogo = TipoDiálogo.pregunta;
        nuevoElemento.personaje = personaje;
        nuevoElemento.texto = texto;

        return nuevoElemento;
    }

    // Final de ruta
    public static ElementoDialogo CrearFinal(Personajes personaje, string texto, TipoFinal tipoFinal)
    {
        var nuevoElemento = new ElementoDialogo();
        nuevoElemento.tipoDiálogo = TipoDiálogo.final;
        nuevoElemento.personaje = personaje;
        nuevoElemento.texto = texto;
        nuevoElemento.tipoFinal = tipoFinal;

        return nuevoElemento;
    }
}
