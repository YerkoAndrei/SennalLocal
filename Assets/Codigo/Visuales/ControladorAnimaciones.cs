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
    private ControladorDialogos controladorDiálogos;

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
            MostrarAnimación(Animaciones.Escribir);

        if (Input.GetKeyDown(KeyCode.O))
            MostrarAnimación(Animaciones.Sentarse);

        if (Input.GetKeyDown(KeyCode.P))
            MostrarAnimación(Animaciones.LlegaUsuario);

        if (Input.GetKeyDown(KeyCode.U))
            MostrarAnimación(Animaciones.FinalAutor);

        if (Input.GetKeyDown(KeyCode.Y))
            StartCoroutine(AnimarRotaciónOjo(objetivoOjo));

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

    // Sistema animación
    public void MostrarAnimación(Animaciones animación)
    {
        switch (animación)
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

    public void CancelarAnimación()
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
        controladorCamara.CambiarPosición(CámarasCine.final);
        animadorOperador.SetTrigger("Mirar");

        yield return new WaitForSeconds(7f);
        StartCoroutine(AnimarRotaciónOjo(objetivoOjo));
        yield return new WaitForSeconds(0.3f);

        // Salida forzosa
        Application.Quit();
    }

    private IEnumerator AnimarSentarse()
    {
        animadorOperador.SetTrigger("Sentarse");
        animadorSilla.SetTrigger("Entrar");

        yield return new WaitForSeconds(0.4f);
        SistemaSonidos.ReproducirAnimación(Sonidos.SillaEntrar);
    }

    private IEnumerator AnimarLlegadaUsuario()
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

        // Operador
        yield return new WaitForSeconds(0.4f);
        animadorOperador.SetTrigger("Pararse");
        animadorSilla.SetTrigger("Salir");

        controladorCamara.CambiarDistanciaMínima(0.5f, 0.1f);
        SistemaSonidos.ReproducirAnimación(Sonidos.SillaSalir);
        StartCoroutine(AnimarEntrarRotación(rotaciónInicial));

        // Final con diálogos
        yield return new WaitForSeconds(1f);
        controladorDiálogos.MostrarÚltimoTextoFinalUsuario();
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

    private IEnumerator AnimarRotaciónOjo(Transform objetivo)
    {
        float tiempoLerp = 0;
        float tiempo = 0;
        float duraciónLerp = 0.2f;

        var posiciónInicial = ojoOperador.position;
        var rotaciónInicial = ojoOperador.rotation;

        while (tiempoLerp < duraciónLerp)
        {
            tiempo = tiempoLerp / duraciónLerp;

            ojoOperador.position = Vector3.Lerp(posiciónInicial, objetivo.position, tiempo);
            ojoOperador.rotation = Quaternion.Lerp(rotaciónInicial, objetivo.rotation, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        ojoOperador.position = objetivo.position;
        ojoOperador.rotation = objetivo.rotation;
    }
}
