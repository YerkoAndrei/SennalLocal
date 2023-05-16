using System.Collections.Generic;
using System.Text;

public class Constantes
{
    public static System.Random aleatorio;
    protected static int llave = 08021996;

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

    public enum NivelEstrés
    {
        esperando,
        bajo,
        normal,
        alto,
        gritando,
        muerto
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

    // XOR
    public static string DesEncriptar(string texto)
    {
        var input = new StringBuilder(texto);
        var output = new StringBuilder(texto.Length);
        char c;
        for (int i = 0; i < texto.Length; i++)
        {
            c = input[i];
            c = (char)(c ^ llave);
            output.Append(c);
        }
        return output.ToString();
    }
}
