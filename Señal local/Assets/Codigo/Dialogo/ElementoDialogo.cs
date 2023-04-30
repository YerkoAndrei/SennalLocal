using System;
using static Constantes;

[Serializable]
public class ElementoDialogo
{
    // Diálogo
    public Personajes personaje;
    public string texto;
    public bool visto;

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

        // Pruebas
        if(SistemaMemoria.instancia != null)
            nuevoElemento.visto = SistemaMemoria.instancia.VerificarDiálogoVisto(texto);

        return nuevoElemento;
    }

    // Opciones múltiples
    public static ElementoDialogo CrearOpciones(ElementoOpcion[] opciones)
    {
        var nuevoElemento = new ElementoDialogo();
        nuevoElemento.tipoDiálogo = TipoDiálogo.opciones;
        nuevoElemento.opciones = opciones;

        return nuevoElemento;
    }

    // Escribir mensaje
    public static ElementoDialogo CrearPregunta()
    {
        var nuevoElemento = new ElementoDialogo();
        nuevoElemento.tipoDiálogo = TipoDiálogo.pregunta;

        return nuevoElemento;
    }

    // Final de ruta
    public static ElementoDialogo CrearFinal(TipoFinal tipoFinal)
    {
        var nuevoElemento = new ElementoDialogo();
        nuevoElemento.tipoDiálogo = TipoDiálogo.final;
        nuevoElemento.tipoFinal = tipoFinal;

        return nuevoElemento;
    }
}
