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

    [Header("Personajes")]
    [SerializeField] private Transform usuario;
    [SerializeField] private Transform objetivoUsuario;

    [Header("Animadores")]
    [SerializeField] private Animator animadorOperador;
    [SerializeField] private Animator animadorUsuario;
    [SerializeField] private Animator animadorSilla;
    [SerializeField] private Animator animadorPuerta;

    [Header("Curvas")]
    [SerializeField] private AnimationCurve curvaAnimaciónEstandar;

    private ControladorCamara controladorCamara;

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

    Vector3 aa;
    Quaternion bb;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            MostrarAnimación(Animaciones.Escribir);

        if (Input.GetKeyDown(KeyCode.O))
            MostrarAnimación(Animaciones.Sentarse);

        if (Input.GetKeyDown(KeyCode.P))
            MostrarAnimación(Animaciones.LlegaUsuario);

        if (Input.GetKeyDown(KeyCode.L))
        {
            animadorUsuario.Rebind();
            animadorPuerta.Rebind();
            animadorOperador.Rebind();
            animadorSilla.Rebind();

            animadorOperador.SetTrigger("Sentarse");
            controladorCamara.CambiarPosición(CámarasCine.juego);
            controladorCamara.CambiarDistanciaMínima(0.1f, 0.3f);

            usuario.position = aa;
            usuario.rotation = bb;
        }
    }
    
    private void Iniciar()
    {
        aa = usuario.position;
        bb = usuario.rotation;

        controladorCamara = FindObjectOfType<ControladorCamara>();

        // Recuerda anterior o usa predeterminado
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("gráficos")))
            CambiarGráficos(Gráficos.altos);
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
        switch(animación)
        {
            case Animaciones.Escribir:
                instancia.AnimarEscribir();
                break;
            case Animaciones.Sentarse:
                instancia.StartCoroutine(instancia.AnimarSentarse());
                break;
            case Animaciones.LlegaUsuario:
                instancia.StartCoroutine(instancia.AnimarLlegadaUsuario());
                break;
            case Animaciones.FinalAutor:

                break;
        }
    }

    public static void CancelarAnimación()
    {
        instancia.CancelarEscribir();
    }

    public void AnimarEscribir()
    {
        animadorOperador.SetTrigger("Escribir");
    }

    public void CancelarEscribir()
    {
        animadorOperador.SetTrigger("Cancelar");
    }

    public IEnumerator AnimarSentarse()
    {
        animadorOperador.SetTrigger("Sentarse");
        animadorSilla.SetTrigger("Entrar");

        yield return new WaitForSeconds(0.4f);
        SistemaSonidos.ReproducirAnimación(Sonidos.SillaEntrar);
    }

    public IEnumerator AnimarLlegadaUsuario()
    {
        // Usuario
        usuario.gameObject.SetActive(true);
        animadorUsuario.SetTrigger("Entrar");
        animadorPuerta.SetTrigger("Abrir");

        // Movimiento y rotación
        var posiciónInicial = usuario.position;
        var rotaciónInicial = usuario.rotation;
        StartCoroutine(AnimarEntrarPosición(posiciónInicial));

        // Sonido
        //yield return new WaitForSeconds(0.4f);
        //SistemaSonidos.ReproducirAnimación(Sonidos.PuertaEntrar);

        // Cámara
        yield return new WaitForSeconds(0.6f);
        controladorCamara.CambiarPosición(CámarasCine.usuario);

        yield return new WaitForSeconds(0.2f);
        controladorCamara.CambiarDistanciaMínima(0.2f, 0.1f);

        // Operador
        yield return new WaitForSeconds(0.2f);
        animadorOperador.SetTrigger("Pararse");
        animadorSilla.SetTrigger("Salir");

        SistemaSonidos.ReproducirAnimación(Sonidos.SillaSalir);
        StartCoroutine(AnimarEntrarRotación(rotaciónInicial));

    }

    public IEnumerator AnimarEntrarPosición(Vector3 posiciónInicial)
    {
        float tiempoLerp = 0;
        float tiempo = 0;
        float duraciónLerp = 1.5f;
        while (tiempoLerp < duraciónLerp)
        {
            tiempo = tiempoLerp / duraciónLerp;

            usuario.position = Vector3.Lerp(posiciónInicial, objetivoUsuario.position, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        usuario.position = objetivoUsuario.position;
    }

    public IEnumerator AnimarEntrarRotación(Quaternion rotaciónInicial)
    {
        float tiempoLerp = 0;
        float tiempo = 0;
        float duraciónLerp = 0.5f;
        while (tiempoLerp < duraciónLerp)
        {
            tiempo = tiempoLerp / duraciónLerp;
            usuario.rotation = Quaternion.Lerp(rotaciónInicial, objetivoUsuario.rotation, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        usuario.rotation = objetivoUsuario.rotation;
    }

    // Animaciones interfaz
    public static void CancelarCorrutina(Coroutine corrutina)
    {
        instancia.StopCoroutine(corrutina);
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
