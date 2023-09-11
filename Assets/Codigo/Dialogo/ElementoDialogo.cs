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

    // Visuales
    public Rutas ruta;
    public NivelEstrés nivelEstrés;

    // Especiales
    public Animaciones animación;
    public TipoFinal tipoFinal;
    public ElementoOpcion[] opciones;
    public ElementoDialogo siguienteDiálogoNegativo;

    public void AsignarSiguienteDiálogo(ElementoDialogo elementoDialogo)
    {
        siguienteDiálogo = elementoDialogo;
    }

    // Crear diálogos según tipo

    // Diálogo normal
    public static ElementoDialogo CrearDiálogo(Personajes personaje, string texto, Rutas ruta, NivelEstrés nivelEstrés = NivelEstrés.normal, Animaciones animación = Animaciones.nada)
    {
        var nuevoElemento = new ElementoDialogo();
        nuevoElemento.tipoDiálogo = TipoDiálogo.diálogo;
        nuevoElemento.personaje = personaje;
        nuevoElemento.texto = texto;
        nuevoElemento.visto = SistemaMemoria.VerificarDiálogo(texto);
        nuevoElemento.ruta = ruta;
        nuevoElemento.nivelEstrés = nivelEstrés;
        nuevoElemento.animación = animación;

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
    public static ElementoDialogo CrearPregunta(ElementoDialogo diálogoPositivo, ElementoDialogo diálogoNegativo, TipoDiálogo tipoPregunta)
    {
        var nuevoElemento = new ElementoDialogo();
        nuevoElemento.tipoDiálogo = tipoPregunta;
        nuevoElemento.siguienteDiálogo = diálogoPositivo;
        nuevoElemento.siguienteDiálogoNegativo = diálogoNegativo;

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
