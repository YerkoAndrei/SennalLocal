// YerkoAndrei
using System;
using System.Text;
using System.Collections.Generic;

public class Constantes
{
    public static Random aleatorio;
    protected static int llave = 08021996;

    public static UnityEngine.Color colorTransparente = new UnityEngine.Color(1, 1, 1, 0);

    // Diálogos
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
        nombre,         // Escribir nombre
        pregunta,       // Escribir mensaje
        final           // Final de ruta
    }

    public enum TipoFinal
    {
        muerte,         // 10
        captura,        // 10  
        escape          // 1
    }

    public enum RespuestasClave
    {
        encendedorEncontrado,
        peligroExterior,
        llaveComputador,
        monstruoObservado,
        nombreDado
    }

    // Configuración
    public enum Idiomas
    {
        español,
        inglés
    }

    public enum Gráficos
    {
        bajos,
        medios,
        altos
    }

    // Visuales
    public enum Direcciones
    {
        arriba,
        abajo,
        izquierda,
        derecha
    }

    public enum NivelEstrés
    {
        pausa,
        bajo,
        normal,
        alto,
        gritando,
        capturado,
        muerto
    }

    public enum Rutas
    {
        menú,
        intro,
        operador,
        usuario,
        monstruo,
        caza,
        sótano,
        autor
    }

    public enum Animaciones
    {
        nada,
        soloEfectos,
        escribir,
        sentarse,
        miraManos,
        llegaUsuario,
        finalAutor,
        cierreAutor
    }

    public enum CámarasCine
    {
        menú,
        juego,
        inicio,
        final,
        usuario,
        autor
    }

    public enum ModoLuz
    {
        palpitar,
        intercambiar
    }

    // Sonidos
    public enum TipoSonido
    {
        General,
        Música,
        Efectos
    }

    public enum Sonidos
    {
        sillaEntrar,
        sillaSalir,
        puertaAbrir,
        matarUsuario,
        estática
    }

    public static ElementoDialogo AsignarDiálogosYObtenerPrimero(List<ElementoDialogo> lista)
    {
        lista.Reverse();
        // Asigna siguiente diálogo
        for (int i = 1; i < lista.Count; i++)
        {
            lista[i].AsignarSiguienteDiálogo(lista[i - 1]);
        }
        lista.Reverse();

        // Devuelve primero de la lista
        return lista.ToArray()[0];
    }

    // XOR
    public static string DesEncriptar(string texto)
    {
        var entrada = new StringBuilder(texto);
        var salida = new StringBuilder(texto.Length);
        char c;

        for (int i = 0; i < texto.Length; i++)
        {
            c = entrada[i];
            c = (char)(c ^ llave);
            salida.Append(c);
        }
        return salida.ToString();
    }
}
