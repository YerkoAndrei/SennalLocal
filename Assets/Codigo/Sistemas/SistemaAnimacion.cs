// YerkoAndrei
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Constantes;

public class SistemaAnimacion : MonoBehaviour
{
    private static SistemaAnimacion instancia;
    public static Gráficos gráficos;
    public static bool mostrandoAnimación;

    [Header("Curvas")]
    public AnimationCurve curvaAnimaciónEstandar;

    private ControladorAnimaciones controladorAnimaciones;

    private void Start()
    {
        if (instancia != null)
            Destroy(gameObject);
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            Iniciar();
        }
    }

    private void Iniciar()
    {
        Application.targetFrameRate = 60;
        controladorAnimaciones = FindObjectOfType<ControladorAnimaciones>();

        // Recuerda anterior o usa predeterminado
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("gráficos")))
        {
            // Movil bajo / PC alto
            if(SistemaPublicidad.modoMóvil)
                CambiarGráficos(Gráficos.bajos);
            else
                CambiarGráficos(Gráficos.altos);
        }
        else
            CambiarGráficos((Gráficos)Enum.Parse(typeof(Gráficos), PlayerPrefs.GetString("gráficos")));
    }

    public static void CambiarGráficos(Gráficos nuevosGráficos)
    {
        gráficos = nuevosGráficos;
        PlayerPrefs.SetString("gráficos", gráficos.ToString());

        QualitySettings.SetQualityLevel((int)gráficos, true);
    }

    // Animaciones juego
    public static void MostrarAnimación(Animaciones animación)
    {
        if (instancia.controladorAnimaciones == null)
            instancia.controladorAnimaciones = FindObjectOfType<ControladorAnimaciones>();

        instancia.controladorAnimaciones.MostrarAnimación(animación);
    }

    public static void CancelarAnimación()
    {
        if (instancia.controladorAnimaciones == null)
            instancia.controladorAnimaciones = FindObjectOfType<ControladorAnimaciones>();

        instancia.controladorAnimaciones.CancelarAnimación();
    }

    public static void MarcarAnimación(bool animando)
    {
        mostrandoAnimación = animando;
    }

    // Animaciones interfaz
    public static void CancelarCorrutina(Coroutine corrutina)
    {
        instancia.StopCoroutine(corrutina);
    }

    public static AnimationCurve ObtenerCurva()
    {
        return instancia.curvaAnimaciónEstandar;
    }

    public static float EvaluarCurva(float tiempo)
    {
        return instancia.curvaAnimaciónEstandar.Evaluate(tiempo);
    }

    public static void AnimarPanel(RectTransform elemento, float duraciónLerp, bool entrando, bool conCurva, Direcciones dirección, Action alFinal)
    {
        instancia.StartCoroutine(AnimaciónMovimiento(elemento, duraciónLerp, entrando, conCurva, dirección, alFinal));
    }

    public static Coroutine AnimarColor(Image elemento, float duraciónLerp, bool conCurva, Color colorInicio, Color colorFinal, Action alFinal)
    {
        return instancia.StartCoroutine(AnimaciónColor(elemento, duraciónLerp, conCurva, colorInicio, colorFinal, alFinal));
    }

    // Intercalación lineal sin curva
    private static IEnumerator AnimaciónMovimiento(RectTransform elemento, float duraciónLerp, bool entrando, bool conCurva, Direcciones dirección, Action alFinal)
    {
        var posiciónFuera = Vector2.zero;

        switch(dirección)
        {
            case Direcciones.arriba:
                posiciónFuera = new Vector2(0, 1000);
                break;
            case Direcciones.abajo:
                posiciónFuera = new Vector2(0, -1000);
                break;
            case Direcciones.izquierda:
                posiciónFuera = new Vector2(-2000, 0);
                break;
            case Direcciones.derecha:
                posiciónFuera = new Vector2(2000, 0);
                break;
        }

        if (entrando)
            elemento.anchoredPosition = posiciónFuera;
        else
            elemento.anchoredPosition = Vector2.zero;

        float tiempoLerp = 0;
        float tiempo = 0;
        while (tiempoLerp < duraciónLerp)
        {
            if (conCurva)
                tiempo = EvaluarCurva(tiempoLerp / duraciónLerp);
            else
                tiempo = tiempoLerp / duraciónLerp;

            if (entrando)
                elemento.anchoredPosition = Vector2.Lerp(posiciónFuera, Vector2.zero, tiempo);
            else
                elemento.anchoredPosition = Vector2.Lerp(Vector2.zero, posiciónFuera, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        if (entrando)
            elemento.anchoredPosition = Vector2.zero;
        else
            elemento.anchoredPosition = posiciónFuera;

        if (alFinal != null)
            alFinal.Invoke();
    }

    private static IEnumerator AnimaciónColor(Image elemento, float duraciónLerp, bool conCurva, Color colorInicio, Color colorFinal, Action alFinal)
    {
        elemento.color = colorInicio;

        float tiempoLerp = 0;
        float tiempo = 0;
        while (tiempoLerp < duraciónLerp)
        {
            if (conCurva)
                tiempo = EvaluarCurva(tiempoLerp / duraciónLerp);
            else
                tiempo = tiempoLerp / duraciónLerp;

            elemento.color = Color.Lerp(colorInicio, colorFinal, tiempo);
            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        elemento.color = colorFinal;

        if (alFinal != null)
            alFinal.Invoke();
    }
}
