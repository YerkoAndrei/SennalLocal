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
    public Rutas ruta;
    public NivelEstrés nivelEstrés;
    public ElementoOpcion[] opciones;

    public void AsignarSiguienteDiálogo(ElementoDialogo elementoDialogo)
    {
        siguienteDiálogo = elementoDialogo;
    }

    // Crear diálogos según tipo

    // Diálogo normal
    public static ElementoDialogo CrearDiálogo(Personajes personaje, string texto, Rutas ruta, NivelEstrés nivelEstrés)
    {
        var nuevoElemento = new ElementoDialogo();
        nuevoElemento.tipoDiálogo = TipoDiálogo.diálogo;
        nuevoElemento.personaje = personaje;
        nuevoElemento.texto = texto;
        nuevoElemento.visto = SistemaMemoria.instancia.VerificarDiálogo(texto);
        nuevoElemento.ruta = ruta;
        nuevoElemento.nivelEstrés = nivelEstrés;

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
    public static ElementoDialogo CrearFinal(string texto, TipoFinal tipoFinal, Rutas ruta)
    {
        var nuevoElemento = new ElementoDialogo();
        nuevoElemento.tipoDiálogo = TipoDiálogo.final;
        nuevoElemento.texto = texto;
        nuevoElemento.tipoFinal = tipoFinal;
        nuevoElemento.ruta = ruta;

        return nuevoElemento;
    }
}
