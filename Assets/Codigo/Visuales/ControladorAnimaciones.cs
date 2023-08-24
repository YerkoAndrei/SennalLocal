using System.Collections;
using UnityEngine;
using static Constantes;

public class ControladorAnimaciones : MonoBehaviour
{
    [Header("Personajes")]
    [SerializeField] private Transform usuario;
    [SerializeField] private Transform objetivoUsuario;

    [Header("Ojo Operador")]
    [SerializeField] private Transform ojoOperador;
    [SerializeField] private Transform objetivoOjo;

    [Header("Animadores")]
    [SerializeField] private Animator animadorOperador;
    [SerializeField] private Animator animadorUsuario;
    [SerializeField] private Animator animadorSilla;
    [SerializeField] private Animator animadorPuerta;

    private ControladorCamara controladorCamara;
    private ControladorDialogos controladorDi�logos;

    private void Start()
    {
        controladorCamara = FindObjectOfType<ControladorCamara>();

        aa = usuario.position;
        bb = usuario.rotation;
    }

    // Pruebas
    Vector3 aa;
    Quaternion bb;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            MostrarAnimaci�n(Animaciones.Escribir);

        if (Input.GetKeyDown(KeyCode.O))
            MostrarAnimaci�n(Animaciones.Sentarse);

        if (Input.GetKeyDown(KeyCode.P))
            MostrarAnimaci�n(Animaciones.LlegaUsuario);

        if (Input.GetKeyDown(KeyCode.U))
            MostrarAnimaci�n(Animaciones.FinalAutor);

        if (Input.GetKeyDown(KeyCode.Y))
            StartCoroutine(AnimarRotaci�nOjo(objetivoOjo));

        if (Input.GetKeyDown(KeyCode.L))
        {
            animadorUsuario.Rebind();
            animadorPuerta.Rebind();
            animadorOperador.Rebind();
            animadorSilla.Rebind();

            animadorOperador.SetTrigger("Sentarse");
            controladorCamara.CambiarPosici�n(C�marasCine.juego);
            controladorCamara.CambiarDistanciaM�nima(0.1f, 0.3f);

            usuario.position = aa;
            usuario.rotation = bb;
        }
    }

    // Sistema animaci�n
    public void MostrarAnimaci�n(Animaciones animaci�n)
    {
        switch (animaci�n)
        {
            case Animaciones.Escribir:
                AnimarEscribir();
                break;
            case Animaciones.Sentarse:
                StartCoroutine(AnimarSentarse());
                break;
            case Animaciones.MiraManos:
                AnimarMirarManos();
                break;
            case Animaciones.LlegaUsuario:
                StartCoroutine(AnimarLlegadaUsuario());
                break;
            case Animaciones.FinalAutor:
                StartCoroutine(AnimarFinalAutor());
                break;
        }
    }

    public void CancelarAnimaci�n()
    {
        animadorOperador.SetTrigger("Cancelar");
    }

    // Animaciones
    private void AnimarEscribir()
    {
        animadorOperador.SetTrigger("Escribir");
    }

    private void AnimarMirarManos()
    {
        animadorOperador.SetTrigger("MirarManos");
    }

    private IEnumerator AnimarFinalAutor()
    {
        controladorCamara.CambiarPosici�n(C�marasCine.final);
        animadorOperador.SetTrigger("Mirar");

        yield return new WaitForSeconds(7f);
        StartCoroutine(AnimarRotaci�nOjo(objetivoOjo));
        yield return new WaitForSeconds(0.3f);

        // Salida forzosa
        Application.Quit();
    }

    private IEnumerator AnimarSentarse()
    {
        animadorOperador.SetTrigger("Sentarse");
        animadorSilla.SetTrigger("Entrar");

        yield return new WaitForSeconds(0.4f);
        SistemaSonidos.ReproducirAnimaci�n(Sonidos.SillaEntrar);
    }

    private IEnumerator AnimarLlegadaUsuario()
    {
        // Usuario
        usuario.gameObject.SetActive(true);
        animadorUsuario.SetTrigger("Entrar");
        animadorPuerta.SetTrigger("Abrir");

        // Movimiento y rotaci�n
        var posici�nInicial = usuario.position;
        var rotaci�nInicial = usuario.rotation;
        StartCoroutine(AnimarEntrarPosici�n(posici�nInicial));

        // Sonido
        //yield return new WaitForSeconds(0.4f);
        //SistemaSonidos.ReproducirAnimaci�n(Sonidos.PuertaEntrar);

        // C�mara
        yield return new WaitForSeconds(0.6f);
        controladorCamara.CambiarPosici�n(C�marasCine.usuario);

        // Operador
        yield return new WaitForSeconds(0.4f);
        animadorOperador.SetTrigger("Pararse");
        animadorSilla.SetTrigger("Salir");

        controladorCamara.CambiarDistanciaM�nima(0.5f, 0.1f);
        SistemaSonidos.ReproducirAnimaci�n(Sonidos.SillaSalir);
        StartCoroutine(AnimarEntrarRotaci�n(rotaci�nInicial));

        // Final con di�logos
        yield return new WaitForSeconds(1f);
        controladorDi�logos.Mostrar�ltimoTextoFinalUsuario();
    }

    private IEnumerator AnimarEntrarPosici�n(Vector3 posici�nInicial)
    {
        float tiempoLerp = 0;
        float tiempo = 0;
        float duraci�nLerp = 1.5f;
        while (tiempoLerp < duraci�nLerp)
        {
            tiempo = tiempoLerp / duraci�nLerp;

            usuario.position = Vector3.Lerp(posici�nInicial, objetivoUsuario.position, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        usuario.position = objetivoUsuario.position;
    }

    private IEnumerator AnimarEntrarRotaci�n(Quaternion rotaci�nInicial)
    {
        float tiempoLerp = 0;
        float tiempo = 0;
        float duraci�nLerp = 0.5f;
        while (tiempoLerp < duraci�nLerp)
        {
            tiempo = tiempoLerp / duraci�nLerp;
            usuario.rotation = Quaternion.Lerp(rotaci�nInicial, objetivoUsuario.rotation, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        usuario.rotation = objetivoUsuario.rotation;
    }

    private IEnumerator AnimarRotaci�nOjo(Transform objetivo)
    {
        float tiempoLerp = 0;
        float tiempo = 0;
        float duraci�nLerp = 0.2f;

        var posici�nInicial = ojoOperador.position;
        var rotaci�nInicial = ojoOperador.rotation;

        while (tiempoLerp < duraci�nLerp)
        {
            tiempo = tiempoLerp / duraci�nLerp;

            ojoOperador.position = Vector3.Lerp(posici�nInicial, objetivo.position, tiempo);
            ojoOperador.rotation = Quaternion.Lerp(rotaci�nInicial, objetivo.rotation, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        ojoOperador.position = objetivo.position;
        ojoOperador.rotation = objetivo.rotation;
    }
}
