// YerkoAndrei
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

    [Header("Sonidos")]
    [SerializeField] private AudioClip sonidoSillaEntrar;
    [SerializeField] private AudioClip sonidoSillaSalir;
    [SerializeField] private AudioClip sonidoPuertaEntrar;

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

        ActivarMúsica(true);
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
    public static void ActivarMúsica(bool activar)
    {
        instancia.StartCoroutine(instancia.CambiarVolumenMúsica(activar));
    }

    private IEnumerator CambiarVolumenMúsica(bool activar)
    {
        // Intercalación lineal con curva
        tiempoLerp = 0;

        if (activar)
        {
            fuenteMúsica.volume = 0;
            fuenteMúsica.Play();
        }
        else
            fuenteMúsica.volume = ObtenerVolumenMúsica();

        while (tiempoLerp < tiempoCambioMúsica)
        {
            if (activar)
            {
                tiempoCambio = SistemaAnimacion.EvaluarCurva(tiempoLerp / tiempoCambioMúsica);
                fuenteMúsica.volume = Mathf.Lerp(0, ObtenerVolumenMúsica(), tiempoCambio);
            }
            else
            {
                tiempoCambio = SistemaAnimacion.EvaluarCurva(tiempoLerp / tiempoCambioMúsica);
                fuenteMúsica.volume = Mathf.Lerp(ObtenerVolumenMúsica(), 0, tiempoCambio);
            }

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin primer Lerp
        tiempoLerp = 0;

        if (activar)
            fuenteMúsica.volume = ObtenerVolumenMúsica();
        else
        {
            fuenteMúsica.volume = 0;
            fuenteMúsica.Stop();
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

    // Animaciones
    public static void ReproducirAnimación(Animaciones animación)
    {
        switch (animación)
        {
            case Animaciones.Escribir:
                break;
            case Animaciones.Sentarse:
                instancia.fuenteEfectos.PlayOneShot(instancia.sonidoSillaEntrar);
                break;
            case Animaciones.Pararse:
                instancia.fuenteEfectos.PlayOneShot(instancia.sonidoSillaSalir);
                break;
            case Animaciones.Entrar:
                instancia.fuenteEfectos.PlayOneShot(instancia.sonidoPuertaEntrar);
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
