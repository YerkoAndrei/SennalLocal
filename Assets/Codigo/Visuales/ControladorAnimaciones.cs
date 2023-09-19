using System.Collections;
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

    private ControladorDialogos controladorDi�logos;
    private ControladorCamara controladorCamara;
    private ControladorMenu controladorMen�;
    private AnimadorLuzFondo animadorLuzFondo;

    private Vector3 ajusteMirada;
    private float rotaci�nInicialXOjo;
    private float granosBase;
    private float aberraci�nBas;

    private void Start()
    {
        controladorDi�logos = FindObjectOfType<ControladorDialogos>();
        controladorCamara = FindObjectOfType<ControladorCamara>();
        controladorMen� = FindObjectOfType<ControladorMenu>();
        animadorLuzFondo = FindObjectOfType<AnimadorLuzFondo>();
        ojoOperador.gameObject.SetActive(false);
        ajusteMirada = new Vector3(-0.05f, 0.05f, 0);

        // Post procesado
        efectos.profile.TryGet(out granosC�mara);
        efectos.profile.TryGet(out aberraci�nCrom�tica);
        granosBase = 0.2f;
        aberraci�nBas = 0.5f;

        SistemaSonidos.ActivarM�sica(true);
    }
    
    // Sistema animaci�n
    public void MostrarAnimaci�n(Animaciones animaci�n)
    {
        switch (animaci�n)
        {
            case Animaciones.nada:
                StartCoroutine(AnimarEfectos(false));
                break;
            case Animaciones.escribir:
                AnimarEscribir();
                break;
            case Animaciones.soloEfectos:
                StartCoroutine(AnimarEfectos(true));
                break;
            case Animaciones.sentarse:
                StartCoroutine(AnimarSentarse());
                break;
            case Animaciones.miraManos:
                StartCoroutine(AnimarMirarManos());
                break;
            case Animaciones.llegaUsuario:
                StartCoroutine(AnimarLlegadaUsuario());
                break;
            case Animaciones.finalAutor:
                StartCoroutine(AnimarFinalAutor());
                break;
            case Animaciones.cierreAutor:
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
        SistemaSonidos.ReproducirAnimaci�n(Sonidos.sillaEntrar);
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
        SistemaAnimacion.MarcarAnimaci�n(true);
        controladorMen�.MostrarMen�Juego(false);
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

        yield return new WaitForSeconds(8.8f);
        SistemaAnimacion.MarcarAnimaci�n(false);
    }

    private IEnumerator AnimarCierreAutor()
    {
        SistemaAnimacion.MarcarAnimaci�n(true);
        SistemaSonidos.ReproducirAnimaci�n(Sonidos.est�tica);
        StartCoroutine(AnimarRotaci�nOjo(controladorCamara.posicionadorC�mara.position));
        yield return new WaitForSeconds(0.5f);

        // Salida forzosa
        Application.Quit();
    }

    private IEnumerator AnimarLlegadaUsuario()
    {
        SistemaAnimacion.MarcarAnimaci�n(true);
        controladorMen�.MostrarMen�Juego(false);
        controladorDi�logos.OcultarDi�logos();
        animadorLuzFondo.AnimarEncuentro();
        CancelarAnimaci�n();

        // Movimiento Usuario
        usuario.gameObject.SetActive(true);
        animadorUsuario.SetTrigger("Entrar");
        animadorPuerta.SetTrigger("Abrir");
        StartCoroutine(AnimarEntrarPosici�n(usuario.position));

        // Sonido
        SistemaSonidos.ActivarM�sica(false);

        yield return new WaitForSeconds(0.2f);
        SistemaSonidos.ReproducirAnimaci�n(Sonidos.puertaAbrir);

        // C�mara
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(AnimarEfectos(true));
        controladorCamara.CambiarPosici�n(C�marasCine.usuario);

        // Operador
        yield return new WaitForSeconds(0.3f);
        animadorOperador.SetTrigger("Pararse");
        animadorSilla.SetTrigger("Salir");

        controladorCamara.CambiarDistanciaM�nima(0.5f, 0.1f);
        StartCoroutine(AnimarEntrarRotaci�n(usuario.rotation));

        yield return new WaitForSeconds(0.6f);
        SistemaSonidos.ReproducirAnimaci�n(Sonidos.sillaSalir);

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
