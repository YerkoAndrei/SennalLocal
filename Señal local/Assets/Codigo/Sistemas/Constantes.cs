using System.Collections.Generic;

public class Constantes 
{
    public enum Estados
    {
        pausa,
        esperandoClic,
        mostrandoDiálogo,
        mostrandoOpciones,
        animación
    }

    public enum Personajes
    {
        usuario,
        operador,
        monstruo,
        sobreviviente,
        computador
    }

    public enum TipoDiálogo
    {
        diálogo,
        opciones,
        pregunta,
        final
    }

    public enum TipoFinal
    {
        nada,
        muerte,
        captura
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
