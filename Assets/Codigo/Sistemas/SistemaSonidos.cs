﻿// YerkoAndrei
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using static Constantes;

public class SistemaSonidos : MonoBehaviour
{
    private static SistemaSonidos instancia;

    [Header("Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Variables")]
    [SerializeField] private float tiempoCambioMúsica;

    [Header("Referencias audios")]
    [SerializeField] private AudioSource fuenteMúsica;
    [SerializeField] private AudioSource fuenteDiálogo;
    [SerializeField] private AudioSource fuenteEfectos;

    [Header("Botones")]
    [SerializeField] private AudioClip presionarBotónFuerte;
    [SerializeField] private AudioClip soltarBotónFuerte;
    [SerializeField] private AudioClip presionarbotónSuave;
    [SerializeField] private AudioClip soltarBotónSuave;

    [Header("Diálogos")]
    [SerializeField] private AudioClip audioUsuario;
    [SerializeField] private AudioClip audioOperador;
    [SerializeField] private AudioClip audioMonstruo;
    [SerializeField] private AudioClip audioSobreviviente;
    [SerializeField] private AudioClip audioComputador;

    [Header("Músicas")]
    [SerializeField] private AudioClip músicaIntro;
    [SerializeField] private AudioClip músicaOperador;
    [SerializeField] private AudioClip músicaUsuario;
    [SerializeField] private AudioClip músicaMonstruo;
    [SerializeField] private AudioClip músicaCaza;
    [SerializeField] private AudioClip músicaSótano;
    [SerializeField] private AudioClip músicaAutor;

    private float volumenEstandar = 0.5f;

    // Lerp
    private float tiempoLerp;
    private float tiempoCambio;

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
        // Recuerda anterior o usa predeterminado
        if (ObtenerVolumenGeneral() == 0)
            PlayerPrefs.SetFloat(TipoSonido.General.ToString(), volumenEstandar);

        if (ObtenerVolumenMúsica() == 0)
            PlayerPrefs.SetFloat(TipoSonido.Música.ToString(), volumenEstandar);

        if (ObtenerVolumenEfectos() == 0)
            PlayerPrefs.SetFloat(TipoSonido.Efectos.ToString(), volumenEstandar);

        ActualizarVolumen(TipoSonido.General, ObtenerVolumenGeneral());
        ActualizarVolumen(TipoSonido.Música, ObtenerVolumenMúsica());
        ActualizarVolumen(TipoSonido.Efectos, ObtenerVolumenEfectos());
    }

    public static void ActualizarVolumen(TipoSonido tipoSonido, float volumen)
    {
        volumen = Mathf.Clamp(volumen, 0.0001f, 1f);
        instancia.audioMixer.SetFloat(tipoSonido.ToString(), Mathf.Log10(volumen) * 20);

        PlayerPrefs.SetFloat(tipoSonido.ToString(), volumen);
    }

    public static float ObtenerVolumenGeneral()
    {
        return PlayerPrefs.GetFloat(TipoSonido.General.ToString());
    }

    public static float ObtenerVolumenMúsica()
    {
        return PlayerPrefs.GetFloat(TipoSonido.Música.ToString());
    }

    public static float ObtenerVolumenEfectos()
    {
        return PlayerPrefs.GetFloat(TipoSonido.Efectos.ToString());
    }

    // Música
    public static void ActualizarMúsica(Rutas ruta)
    {
        instancia.CambiarMúsica(ruta);
    }

    private void CambiarMúsica(Rutas ruta)
    {
        switch (ruta)
        {
            case Rutas.menú:
            case Rutas.intro:
                StartCoroutine(CambiarMúsica(músicaIntro));
                break;
            case Rutas.operador:
                StartCoroutine(CambiarMúsica(músicaOperador));
                break;
            case Rutas.usuario:
                StartCoroutine(CambiarMúsica(músicaUsuario));
                break;
            case Rutas.monstruo:
                StartCoroutine(CambiarMúsica(músicaMonstruo));
                break;
            case Rutas.caza:
                StartCoroutine(CambiarMúsica(músicaCaza));
                break;
            case Rutas.sótano:
                StartCoroutine(CambiarMúsica(músicaSótano));
                break;
            case Rutas.autor:
                StartCoroutine(CambiarMúsica(músicaAutor));
                break;
        }
    }

    private IEnumerator CambiarMúsica(AudioClip nuevaMúsica)
    {
        // Intercalación lineal sin curva
        tiempoLerp = 0;

        while (tiempoLerp < tiempoCambioMúsica)
        {
            tiempoCambio = (tiempoLerp / tiempoCambioMúsica);
            fuenteMúsica.volume = Mathf.Lerp(ObtenerVolumenMúsica(), 0, tiempoCambio);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin primer Lerp
        fuenteMúsica.clip = nuevaMúsica;
        tiempoLerp = 0;

        while (tiempoLerp < tiempoCambioMúsica)
        {
            tiempoCambio = (tiempoLerp / tiempoCambioMúsica);
            fuenteMúsica.volume = Mathf.Lerp(0, ObtenerVolumenMúsica(), tiempoCambio);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }
    }

    // Efectos
    public static void ActivarSonidoPersonaje(Personajes personaje)
    {
        instancia.ActivarPersonaje(personaje);
    }

    private void ActivarPersonaje(Personajes personaje)
    {
        switch (personaje)
        {
            case Personajes.usuario:
                fuenteDiálogo.PlayOneShot(audioUsuario);
                break;
            case Personajes.operador:
                fuenteDiálogo.PlayOneShot(audioOperador);
                break;
            case Personajes.monstruo:
                fuenteDiálogo.PlayOneShot(audioMonstruo);
                break;
            case Personajes.sobreviviente:
                fuenteDiálogo.PlayOneShot(audioSobreviviente);
                break;
            case Personajes.computador:
                fuenteDiálogo.PlayOneShot(audioComputador);
                break;
        }
    }

    public static void PresionarBotónFuerte()
    {
        instancia.fuenteEfectos.PlayOneShot(instancia.presionarBotónFuerte);
    }

    public static void SoltarBotónFuerte()
    {
        instancia.fuenteEfectos.PlayOneShot(instancia.soltarBotónFuerte);
    }

    public static void PresionarBotónSuave()
    {
        instancia.fuenteEfectos.PlayOneShot(instancia.presionarbotónSuave);
    }

    public static void SoltarBotónSuave()
    {
        instancia.fuenteEfectos.PlayOneShot(instancia.soltarBotónSuave);
    }
}
