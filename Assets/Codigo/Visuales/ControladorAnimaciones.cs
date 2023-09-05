using System.Collections;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static Constantes;

public class ControladorAnimaciones : MonoBehaviour
{
    [Header("Personajes")]
    [SerializeField] private Transform usuario;
    [SerializeField] private Transform objetivoUsuario;

    [Header("Ojo Operador")]
    [SerializeField] private Transform ojoOperador;
    [SerializeField] private Transform objetivoOjoOperador;

    [Header("Animadores")]
    [SerializeField] private Animator animadorOperador;
    [SerializeField] private Animator animadorUsuario;
    [SerializeField] private Animator animadorSilla;
    [SerializeField] private Animator animadorPuerta;

    [Header("Efectos")]
    [SerializeField] private Volume efectos;
    private FilmGrain granosC�mara;
    private ChromaticAberration aberraci�nCrom�tica;

    private ControladorCamara controladorCamara;
    private AnimadorLuzFondo animadorLuzFondo;
    private Vector3 ajusteMirada;
    private float rotaci�nInicialXOjo;
    private float granosBase;
    private float aberraci�nBas;

    private void Start()
    {
        controladorCamara = FindObjectOfType<ControladorCamara>();
        animadorLuzFondo = FindObjectOfType<AnimadorLuzFondo>();
        ojoOperador.gameObject.SetActive(false);
        ajusteMirada = new Vector3(-0.05f, 0.1f, 0);

        // Post procesado
        efectos.profile.TryGet(out granosC�mara);
        efectos.profile.TryGet(out aberraci�nCrom�tica);
        granosBase = 0.2f;
        aberraci�nBas = 0.5f;

        aa = usuario.position;
        bb = usuario.rotation;
    }
    
    // Pruebas
    Vector3 aa;
    Quaternion bb;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            MostrarAnimaci�n(Animaciones.Sentarse);

        if (Input.GetKeyDown(KeyCode.U))
            MostrarAnimaci�n(Animaciones.Escribir);

        if (Input.GetKeyDown(KeyCode.I))
            MostrarAnimaci�n(Animaciones.MiraManos);

        if (Input.GetKeyDown(KeyCode.O))
            MostrarAnimaci�n(Animaciones.LlegaUsuario);

        if (Input.GetKeyDown(KeyCode.P))
            MostrarAnimaci�n(Animaciones.FinalAutor);

        if (Input.GetKeyDown(KeyCode.K))
            MostrarAnimaci�n(Animaciones.CierreAutor);

        if (Input.GetKeyDown(KeyCode.L))
        {
            StopAllCoroutines();
            animadorUsuario.Rebind();
            animadorPuerta.Rebind();
            animadorOperador.Rebind();
            animadorSilla.Rebind();

            animadorOperador.SetTrigger("Sentarse");
            controladorCamara.CambiarPosici�n(C�marasCine.juego);
            controladorCamara.CambiarDistanciaM�nima(0.1f, 0.33f);
            StartCoroutine(AnimarRotaci�nOjo(objetivoOjoOperador.position));

            granosC�mara.intensity.value = 0.2f;
            aberraci�nCrom�tica.intensity.value = 0;

            usuario.position = aa;
            usuario.rotation = bb;
        }
    }

    // Sistema animaci�n
    public void MostrarAnimaci�n(Animaciones animaci�n)
    {
        switch (animaci�n)
        {
            case Animaciones.Nada:
                StartCoroutine(AnimarEfectos(false));
                break;
            case Animaciones.Escribir:
                AnimarEscribir();
                break;
            case Animaciones.SoloEfectos:
                StartCoroutine(AnimarEfectos(true));
                break;
            case Animaciones.Sentarse:
                StartCoroutine(AnimarSentarse());
                break;
            case Animaciones.MiraManos:
                StartCoroutine(AnimarMirarManos());
                break;
            case Animaciones.LlegaUsuario:
                StartCoroutine(AnimarLlegadaUsuario());
                break;
            case Animaciones.FinalAutor:
                StartCoroutine(AnimarFinalAutor());
                break;
            case Animaciones.CierreAutor:
                StartCoroutine(AnimarCierreAutor());
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
        StartCoroutine(AnimarEfectosEscribir());
    }

    private IEnumerator AnimarSentarse()
    {
        animadorOperador.SetTrigger("Sentarse");
        animadorSilla.SetTrigger("Entrar");

        yield return new WaitForSeconds(0.4f);
        SistemaSonidos.ReproducirAnimaci�n(Sonidos.SillaEntrar);
    }

    private IEnumerator AnimarMirarManos()
    {
        SistemaAnimacion.MarcarAnimaci�n(true);
        StartCoroutine(AnimarEfectos(true));
        animadorOperador.SetTrigger("MirarManos");
        yield return new WaitForSeconds(2f);
        SistemaAnimacion.MarcarAnimaci�n(false);
    }

    private IEnumerator AnimarFinalAutor()
    {
        controladorCamara.CambiarPosici�n(C�marasCine.autor);
        controladorCamara.CambiarDistanciaM�nima(0.5f, 0.1f);
        animadorLuzFondo.AnimarOperador();

        SistemaSonidos.ActivarM�sica(false);
        StartCoroutine(AnimarEfectos(true));

        // Mirada
        StartCoroutine(AnimarRotaci�nOjo(objetivoOjoOperador.position));
        yield return new WaitForSeconds(1f);
        animadorOperador.SetTrigger("Mirar");

        yield return new WaitForSeconds(0.2f);
        StartCoroutine(AnimarRotaci�nOjo(objetivoOjoOperador.position));
    }

    private IEnumerator AnimarCierreAutor()
    {
        StartCoroutine(AnimarRotaci�nOjo(controladorCamara.posicionadorC�mara.position));
        yield return new WaitForSeconds(0.4f);

        // Salida forzosa
        Application.Quit();
    }

    private IEnumerator AnimarLlegadaUsuario()
    {
        SistemaAnimacion.MarcarAnimaci�n(true);
        animadorLuzFondo.AnimarEncuentro();
        CancelarAnimaci�n();

        // Movimiento Usuario
        usuario.gameObject.SetActive(true);
        animadorUsuario.SetTrigger("Entrar");
        animadorPuerta.SetTrigger("Abrir");
        StartCoroutine(AnimarEntrarPosici�n(usuario.position));

        // Sonido
        yield return new WaitForSeconds(0.4f);
        SistemaSonidos.ReproducirAnimaci�n(Sonidos.PuertaEntrar);
        SistemaSonidos.ActivarM�sica(false);
        StartCoroutine(AnimarEfectos(true));

        // C�mara
        yield return new WaitForSeconds(0.2f);
        controladorCamara.CambiarPosici�n(C�marasCine.usuario);

        // Operador
        yield return new WaitForSeconds(0.4f);
        animadorOperador.SetTrigger("Pararse");
        animadorSilla.SetTrigger("Salir");

        controladorCamara.CambiarDistanciaM�nima(0.5f, 0.1f);
        SistemaSonidos.ReproducirAnimaci�n(Sonidos.SillaSalir);
        StartCoroutine(AnimarEntrarRotaci�n(usuario.rotation));

        // Final con di�logos
        yield return new WaitForSeconds(1f);
        SistemaAnimacion.MarcarAnimaci�n(false);
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

    private IEnumerator AnimarRotaci�nOjo(Vector3 objetivo)
    {
        // Prende ojo y guarda su rotaci�n base
        if (!ojoOperador.gameObject.activeSelf)
        {
            rotaci�nInicialXOjo = ojoOperador.rotation.eulerAngles.x;
            ojoOperador.gameObject.SetActive(true);
        }

        float tiempoLerp = 0;
        float tiempo = 0;
        float duraci�nLerp = 0.1f;

        var rotaci�nInicial = ojoOperador.rotation;
        var posici�nRelativa = (objetivo + ajusteMirada) - ojoOperador.position;
        var rotaci�nRelativa = Quaternion.LookRotation(posici�nRelativa, Vector3.up).eulerAngles + new Vector3(rotaci�nInicialXOjo, 0, 0);
        var rotaci�nObjetivo = Quaternion.Euler(rotaci�nRelativa);

        while (tiempoLerp < duraci�nLerp)
        {
            tiempo = tiempoLerp / duraci�nLerp;

            ojoOperador.rotation = Quaternion.Lerp(rotaci�nInicial, rotaci�nObjetivo, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        ojoOperador.rotation = rotaci�nObjetivo;
    }

    private IEnumerator AnimarEfectosEscribir()
    {
        float tiempoLerp = 0;
        float tiempo = 0;
        float duraci�nLerpInicio = 0.1f;

        while (tiempoLerp < duraci�nLerpInicio)
        {
            tiempo = tiempoLerp / duraci�nLerpInicio;

            granosC�mara.intensity.value = Mathf.Lerp(granosBase, 1f, tiempo);
            aberraci�nCrom�tica.intensity.value = Mathf.Lerp(0, 1, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        granosC�mara.intensity.value = 1;
        aberraci�nCrom�tica.intensity.value = 1;
        float duraci�nLerpFin = 2f;

        while (tiempoLerp < duraci�nLerpFin)
        {
            tiempo = tiempoLerp / duraci�nLerpFin;

            granosC�mara.intensity.value = Mathf.Lerp(1f, granosBase, tiempo);
            aberraci�nCrom�tica.intensity.value = Mathf.Lerp(1, 0, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        granosC�mara.intensity.value = granosBase;
        aberraci�nCrom�tica.intensity.value = 0;
    }

    private IEnumerator AnimarEfectos(bool mostrar)
    {
        float tiempoLerp = 0;
        float tiempo = 0;
        float duraci�nLerp = 4f;

        while (tiempoLerp < duraci�nLerp)
        {
            tiempo = tiempoLerp / duraci�nLerp;

            if (mostrar)
            {
                granosC�mara.intensity.value = Mathf.Lerp(granosBase, 1f, tiempo);
                aberraci�nCrom�tica.intensity.value = Mathf.Lerp(0, aberraci�nBas, tiempo);
            }
            else
            {
                granosC�mara.intensity.value = Mathf.Lerp(1, granosBase, tiempo);
                aberraci�nCrom�tica.intensity.value = Mathf.Lerp(aberraci�nBas, 0, tiempo);
            }

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        if (mostrar)
        {
            granosC�mara.intensity.value = 1;
            aberraci�nCrom�tica.intensity.value = aberraci�nBas;
        }
        else
        {
            granosC�mara.intensity.value = granosBase;
            aberraci�nCrom�tica.intensity.value = 0;
        }
    }
}
