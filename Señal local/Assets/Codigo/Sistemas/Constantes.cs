using System.Collections.Generic;

public class Constantes
{
    public enum Escenas
    {
        Menu,
        Juego
    }

    public enum Estados
    {
        enPausa,
        esperandoClic,
        mostrandoDiálogo,
        mostrandoOpciones,
        mostrandoPregunta,
        mostrandoAnimación,
        esperandoFinal
    }

    public enum Personajes
    {
        usuario,        // Usuario de turno
        operador,       // Jugador
        monstruo,       // Usuario anterior
        sobreviviente,  // Futuro usuario
        computador      // Fuente de conocimiento
    }

    public enum TipoDiálogo
    {
        diálogo,        // Diálogo normal
        opciones,       // Opciones múltiples
        pregunta,       // Escribir mensaje
        final           // Final de ruta
    }

    public enum TipoFinal
    {
        huida,          // 1
        muerte,         // 10
        captura         // 10  
    }

    public static ElementoDialogo[] AsignarContinuidadDiálogos(List<ElementoDialogo> lista)
    {
        lista.Reverse();

        for (int i = 1; i < lista.Count; i++)
        {
            lista[i].AsignarSiguienteDiálogo(lista[i - 1]);
        }

        lista.Reverse();
        return lista.ToArray();
    }
}
