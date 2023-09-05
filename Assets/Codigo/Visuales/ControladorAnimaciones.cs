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
    private FilmGrain granosCámara;
    private ChromaticAberration aberraciónCromática;

    private ControladorCamara controladorCamara;
    private AnimadorLuzFondo animadorLuzFondo;
    private Vector3 ajusteMirada;
    private float rotaciónInicialXOjo;
    private float granosBase;
    private float aberraciónBas;

    private void Start()
    {
        controladorCamara = FindObjectOfType<ControladorCamara>();
        animadorLuzFondo = FindObjectOfType<AnimadorLuzFondo>();
        ojoOperador.gameObject.SetActive(false);
        ajusteMirada = new Vector3(-0.05f, 0.1f, 0);

        // Post procesado
        efectos.profile.TryGet(out granosCámara);
        efectos.profile.TryGet(out aberraciónCromática);
        granosBase = 0.2f;
        aberraciónBas = 0.5f;

        aa = usuario.position;
        bb = usuario.rotation;
    }
    
    // Pruebas
    Vector3 aa;
    Quaternion bb;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            MostrarAnimación(Animaciones.Sentarse);

        if (Input.GetKeyDown(KeyCode.U))
            MostrarAnimación(Animaciones.Escribir);

        if (Input.GetKeyDown(KeyCode.I))
            MostrarAnimación(Animaciones.MiraManos);

        if (Input.GetKeyDown(KeyCode.O))
            MostrarAnimación(Animaciones.LlegaUsuario);

        if (Input.GetKeyDown(KeyCode.P))
            MostrarAnimación(Animaciones.FinalAutor);

        if (Input.GetKeyDown(KeyCode.K))
            MostrarAnimación(Animaciones.CierreAutor);

        if (Input.GetKeyDown(KeyCode.L))
        {
            StopAllCoroutines();
            animadorUsuario.Rebind();
            animadorPuerta.Rebind();
            animadorOperador.Rebind();
            animadorSilla.Rebind();

            animadorOperador.SetTrigger("Sentarse");
            controladorCamara.CambiarPosición(CámarasCine.juego);
            controladorCamara.CambiarDistanciaMínima(0.1f, 0.33f);
            StartCoroutine(AnimarRotaciónOjo(objetivoOjoOperador.position));

            granosCámara.intensity.value = 0.2f;
            aberraciónCromática.intensity.value = 0;

            usuario.position = aa;
            usuario.rotation = bb;
        }
    }

    // Sistema animación
    public void MostrarAnimación(Animaciones animación)
    {
        switch (animación)
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

    public void CancelarAnimación()
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
        SistemaSonidos.ReproducirAnimación(Sonidos.SillaEntrar);
    }

    private IEnumerator AnimarMirarManos()
    {
        SistemaAnimacion.MarcarAnimación(true);
        StartCoroutine(AnimarEfectos(true));
        animadorOperador.SetTrigger("MirarManos");
        yield return new WaitForSeconds(2f);
        SistemaAnimacion.MarcarAnimación(false);
    }

    private IEnumerator AnimarFinalAutor()
    {
        controladorCamara.CambiarPosición(CámarasCine.autor);
        controladorCamara.CambiarDistanciaMínima(0.5f, 0.1f);
        animadorLuzFondo.AnimarOperador();

        SistemaSonidos.ActivarMúsica(false);
        StartCoroutine(AnimarEfectos(true));

        // Mirada
        StartCoroutine(AnimarRotaciónOjo(objetivoOjoOperador.position));
        yield return new WaitForSeconds(1f);
        animadorOperador.SetTrigger("Mirar");

        yield return new WaitForSeconds(0.2f);
        StartCoroutine(AnimarRotaciónOjo(objetivoOjoOperador.position));
    }

    private IEnumerator AnimarCierreAutor()
    {
        StartCoroutine(AnimarRotaciónOjo(controladorCamara.posicionadorCámara.position));
        yield return new WaitForSeconds(0.4f);

        // Salida forzosa
        Application.Quit();
    }

    private IEnumerator AnimarLlegadaUsuario()
    {
        SistemaAnimacion.MarcarAnimación(true);
        animadorLuzFondo.AnimarEncuentro();
        CancelarAnimación();

        // Movimiento Usuario
        usuario.gameObject.SetActive(true);
        animadorUsuario.SetTrigger("Entrar");
        animadorPuerta.SetTrigger("Abrir");
        StartCoroutine(AnimarEntrarPosición(usuario.position));

        // Sonido
        yield return new WaitForSeconds(0.4f);
        SistemaSonidos.ReproducirAnimación(Sonidos.PuertaEntrar);
        SistemaSonidos.ActivarMúsica(false);
        StartCoroutine(AnimarEfectos(true));

        // Cámara
        yield return new WaitForSeconds(0.2f);
        controladorCamara.CambiarPosición(CámarasCine.usuario);

        // Operador
        yield return new WaitForSeconds(0.4f);
        animadorOperador.SetTrigger("Pararse");
        animadorSilla.SetTrigger("Salir");

        controladorCamara.CambiarDistanciaMínima(0.5f, 0.1f);
        SistemaSonidos.ReproducirAnimación(Sonidos.SillaSalir);
        StartCoroutine(AnimarEntrarRotación(usuario.rotation));

        // Final con diálogos
        yield return new WaitForSeconds(1f);
        SistemaAnimacion.MarcarAnimación(false);
    }

    private IEnumerator AnimarEntrarPosición(Vector3 posiciónInicial)
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

    private IEnumerator AnimarEntrarRotación(Quaternion rotaciónInicial)
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

    private IEnumerator AnimarRotaciónOjo(Vector3 objetivo)
    {
        // Prende ojo y guarda su rotación base
        if (!ojoOperador.gameObject.activeSelf)
        {
            rotaciónInicialXOjo = ojoOperador.rotation.eulerAngles.x;
            ojoOperador.gameObject.SetActive(true);
        }

        float tiempoLerp = 0;
        float tiempo = 0;
        float duraciónLerp = 0.1f;

        var rotaciónInicial = ojoOperador.rotation;
        var posiciónRelativa = (objetivo + ajusteMirada) - ojoOperador.position;
        var rotaciónRelativa = Quaternion.LookRotation(posiciónRelativa, Vector3.up).eulerAngles + new Vector3(rotaciónInicialXOjo, 0, 0);
        var rotaciónObjetivo = Quaternion.Euler(rotaciónRelativa);

        while (tiempoLerp < duraciónLerp)
        {
            tiempo = tiempoLerp / duraciónLerp;

            ojoOperador.rotation = Quaternion.Lerp(rotaciónInicial, rotaciónObjetivo, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        ojoOperador.rotation = rotaciónObjetivo;
    }

    private IEnumerator AnimarEfectosEscribir()
    {
        float tiempoLerp = 0;
        float tiempo = 0;
        float duraciónLerpInicio = 0.1f;

        while (tiempoLerp < duraciónLerpInicio)
        {
            tiempo = tiempoLerp / duraciónLerpInicio;

            granosCámara.intensity.value = Mathf.Lerp(granosBase, 1f, tiempo);
            aberraciónCromática.intensity.value = Mathf.Lerp(0, 1, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        granosCámara.intensity.value = 1;
        aberraciónCromática.intensity.value = 1;
        float duraciónLerpFin = 2f;

        while (tiempoLerp < duraciónLerpFin)
        {
            tiempo = tiempoLerp / duraciónLerpFin;

            granosCámara.intensity.value = Mathf.Lerp(1f, granosBase, tiempo);
            aberraciónCromática.intensity.value = Mathf.Lerp(1, 0, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        granosCámara.intensity.value = granosBase;
        aberraciónCromática.intensity.value = 0;
    }

    private IEnumerator AnimarEfectos(bool mostrar)
    {
        float tiempoLerp = 0;
        float tiempo = 0;
        float duraciónLerp = 4f;

        while (tiempoLerp < duraciónLerp)
        {
            tiempo = tiempoLerp / duraciónLerp;

            if (mostrar)
            {
                granosCámara.intensity.value = Mathf.Lerp(granosBase, 1f, tiempo);
                aberraciónCromática.intensity.value = Mathf.Lerp(0, aberraciónBas, tiempo);
            }
            else
            {
                granosCámara.intensity.value = Mathf.Lerp(1, granosBase, tiempo);
                aberraciónCromática.intensity.value = Mathf.Lerp(aberraciónBas, 0, tiempo);
            }

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        if (mostrar)
        {
            granosCámara.intensity.value = 1;
            aberraciónCromática.intensity.value = aberraciónBas;
        }
        else
        {
            granosCámara.intensity.value = granosBase;
            aberraciónCromática.intensity.value = 0;
        }
    }
}
