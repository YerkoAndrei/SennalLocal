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
    [SerializeField] private AudioClip sonidoMatarUsuario;
    [SerializeField] private AudioClip sonidoEstática;

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
            PlayerPrefs.SetFloat(TipoSonido.general.ToString(), volumenEstandar);

        if (ObtenerVolumenMúsica() == 0)
            PlayerPrefs.SetFloat(TipoSonido.música.ToString(), volumenEstandar);

        if (ObtenerVolumenEfectos() == 0)
            PlayerPrefs.SetFloat(TipoSonido.efectos.ToString(), volumenEstandar);

        ActualizarVolumen(TipoSonido.general, ObtenerVolumenGeneral());
        ActualizarVolumen(TipoSonido.música, ObtenerVolumenMúsica());
        ActualizarVolumen(TipoSonido.efectos, ObtenerVolumenEfectos());

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
        return PlayerPrefs.GetFloat(TipoSonido.general.ToString());
    }

    public static float ObtenerVolumenMúsica()
    {
        return PlayerPrefs.GetFloat(TipoSonido.música.ToString());
    }

    public static float ObtenerVolumenEfectos()
    {
        return PlayerPrefs.GetFloat(TipoSonido.efectos.ToString());
    }

    // Música
    public static void ActivarMúsica(bool activar)
    {
        instancia.StartCoroutine(instancia.CambiarVolumenMúsica(activar));
    }

    private IEnumerator CambiarVolumenMúsica(bool activar)
    {
        // Intercalación lineal con curva
        float tiempoCambioVolumen = 4;
        tiempoLerp = 0;

        if (activar)
        {
            fuenteMúsica.volume = 0;
            fuenteMúsica.Play();
        }
        else
            fuenteMúsica.volume = ObtenerVolumenMúsica();

        while (tiempoLerp < tiempoCambioVolumen)
        {
            if (activar)
            {
                tiempoCambio = SistemaAnimacion.EvaluarCurva(tiempoLerp / tiempoCambioVolumen);
                fuenteMúsica.volume = Mathf.Lerp(0, ObtenerVolumenMúsica(), tiempoCambio);
            }
            else
            {
                tiempoCambio = SistemaAnimacion.EvaluarCurva(tiempoLerp / tiempoCambioVolumen);
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
    public static void ReproducirAnimación(Sonidos sonido)
    {
        switch (sonido)
        {
            case Sonidos.sillaEntrar:
                instancia.fuenteEfectos.PlayOneShot(instancia.sonidoSillaEntrar);
                break;
            case Sonidos.sillaSalir:
                instancia.fuenteEfectos.PlayOneShot(instancia.sonidoSillaSalir);
                break;
            case Sonidos.puertaEntrar:
                instancia.fuenteEfectos.PlayOneShot(instancia.sonidoPuertaEntrar);
                break;
            case Sonidos.matarUsuario:
                instancia.fuenteEfectos.PlayOneShot(instancia.sonidoMatarUsuario);
                break;
            case Sonidos.estática:
                instancia.fuenteEfectos.PlayOneShot(instancia.sonidoEstática);
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
