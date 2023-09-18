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
    public DiálogoEspecial especial;
    public ElementoOpcion[] opciones;
    public ElementoDialogo siguienteDiálogoNegativo;

    public void AsignarSiguienteDiálogo(ElementoDialogo elementoDialogo)
    {
        siguienteDiálogo = elementoDialogo;
    }

    // Crear diálogos según tipo

    // Diálogo normal
    public static ElementoDialogo CrearDiálogo(Personajes personaje, string texto, Rutas ruta, NivelEstrés nivelEstrés = NivelEstrés.normal, Animaciones animación = Animaciones.nada, DiálogoEspecial especial = DiálogoEspecial.nada)
    {
        var nuevoElemento = new ElementoDialogo
        {
            tipoDiálogo = TipoDiálogo.diálogo,
            personaje = personaje,
            texto = texto,
            visto = SistemaMemoria.VerificarDiálogo(texto),
            ruta = ruta,
            nivelEstrés = nivelEstrés,
            animación = animación,
            especial = especial
        };
        return nuevoElemento;
    }

    // Opciones múltiples
    public static ElementoDialogo CrearOpciones(ElementoOpcion[] opciones)
    {
        var nuevoElemento = new ElementoDialogo
        {
            tipoDiálogo = TipoDiálogo.opciones,
            opciones = opciones
        };
        return nuevoElemento;
    }

    // Escribir mensaje
    public static ElementoDialogo CrearPregunta(ElementoDialogo diálogoPositivo, ElementoDialogo diálogoNegativo, TipoDiálogo tipoPregunta)
    {
        var nuevoElemento = new ElementoDialogo
        {
            tipoDiálogo = tipoPregunta,
            siguienteDiálogo = diálogoPositivo,
            siguienteDiálogoNegativo = diálogoNegativo,
        };
        return nuevoElemento;
    }

    // Final de ruta
    public static ElementoDialogo CrearFinal(string texto, TipoFinal tipoFinal, Rutas ruta)
    {
        var nuevoElemento = new ElementoDialogo
        {
            tipoDiálogo = TipoDiálogo.final,
            texto = texto,
            tipoFinal = tipoFinal,
            ruta = ruta
        };
        return nuevoElemento;
    }
}
