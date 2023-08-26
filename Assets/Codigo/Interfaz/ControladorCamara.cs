using System.Collections;
using UnityEngine;
using static Constantes;

public class ControladorCamara : MonoBehaviour
{
    [Header("Referencias")]
    public Transform posicionadorCámara;
    [SerializeField] private Transform vibradorCámara;
    [SerializeField] private Camera cámara;

    [Header("Curvas")]
    [SerializeField] private AnimationCurve curvaSuave;
    [SerializeField] private AnimationCurve curvaInicio;
    [SerializeField] private AnimationCurve curvaUsuario;
    [SerializeField] private AnimationCurve curvaAutor;

    [Header("Variables")]
    [SerializeField] private float duraciónCámaraMenú;
    [SerializeField] private float duraciónCámaraInicio;
    [SerializeField] private float duraciónCámaraUsuario;
    [SerializeField] private float duraciónCámaraAutor;

    [Header("Posiciones")]
    [SerializeField] private Transform posiciónMenú;
    [SerializeField] private Transform posiciónJuego;
    [SerializeField] private Transform posiciónUsuario;
    [SerializeField] private Transform posiciónAutor;

    private ControladorMenu controladorMenu;
    private CámarasCine últimaCámara;
    private Vector3 vibraciónAnterior;
    private bool moviendo;

    private void Start()
    {
        controladorMenu = FindObjectOfType<ControladorMenu>();
        vibraciónAnterior = Vector3.zero;
        StartCoroutine(VibrarCámara());

        últimaCámara = CámarasCine.menú;
        posicionadorCámara.localPosition = posiciónMenú.localPosition;
        posicionadorCámara.localRotation = posiciónMenú.localRotation;
    }

    public void CambiarPosición(CámarasCine cámaraCine)
    {
        switch (cámaraCine)
        {
            case CámarasCine.menú:
                StartCoroutine(MoverCámara(duraciónCámaraMenú, SistemaAnimacion.ObtenerCurva(), posiciónMenú.localPosition, posiciónMenú.localRotation));
                break;
            case CámarasCine.juego:
                StartCoroutine(MoverCámara(duraciónCámaraMenú, SistemaAnimacion.ObtenerCurva(), posiciónJuego.localPosition, posiciónJuego.localRotation));
                break;
            case CámarasCine.inicio:
                StartCoroutine(MoverCámara(duraciónCámaraInicio, curvaInicio, posiciónJuego.localPosition, posiciónJuego.localRotation));
                break;
            case CámarasCine.usuario:
                StartCoroutine(MoverCámara(duraciónCámaraUsuario, curvaUsuario, posiciónUsuario.localPosition, posiciónUsuario.localRotation));
                break;
            case CámarasCine.autor:
                StartCoroutine(MoverCámara(duraciónCámaraAutor, curvaAutor, posiciónAutor.localPosition, posiciónAutor.localRotation));
                break;
        }

        últimaCámara = cámaraCine;
    }

    public void CambiarDistanciaMínima(float duraciónObjetivo, float distanciaObjetivo)
    {
        StartCoroutine(ModificarDistanciaMínima(duraciónObjetivo, distanciaObjetivo));
    }
    
    private IEnumerator MoverCámara(float duraciónObjetivo, AnimationCurve curva, Vector3 posiciónObjetivo, Quaternion rotaciónObjetivo)
    {
        // Intercalación lineal con curva
        moviendo = true;
        var posiciónInicio = posicionadorCámara.localPosition;
        var rotaciónInicio = posicionadorCámara.localRotation;

        float tiempoLerp = 0;
        float evaluaciónCurva = 0;
        float evaluaciónCurvaRotación = 0;

        while (tiempoLerp < duraciónObjetivo)
        {
            evaluaciónCurva = curva.Evaluate(tiempoLerp / duraciónObjetivo);
            evaluaciónCurvaRotación = curva.Evaluate(tiempoLerp / duraciónObjetivo);
            posicionadorCámara.localPosition = Vector3.Slerp(posiciónInicio, posiciónObjetivo, evaluaciónCurva);
            posicionadorCámara.localRotation = Quaternion.Lerp(rotaciónInicio, rotaciónObjetivo, evaluaciónCurvaRotación);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin Lerp
        moviendo = false;
        switch (últimaCámara)
        {
            case CámarasCine.juego:
            case CámarasCine.inicio:
                controladorMenu.MostrarMenúJuego(true);
                break;
            case CámarasCine.menú:
            case CámarasCine.usuario:
            case CámarasCine.autor:
                controladorMenu.MostrarMenúJuego(false);
                break;
        }
    }

    // Vibración natural
    private IEnumerator VibrarCámara()
    {
        var x = Random.Range(-0.002f, 0.002f);
        var y = Random.Range(-0.006f, 0.006f);
        var z = Random.Range(-0.001f, 0.001f);

        var posiciónObjetivo = new Vector3(x, y, z);
        float duraciónObjetivo = 1.5f;
        float tiempoLerp = 0;
        float evaluación = 0;

        while (tiempoLerp < duraciónObjetivo)
        {
            evaluación = curvaSuave.Evaluate(tiempoLerp / duraciónObjetivo);
            vibradorCámara.localPosition = Vector3.Lerp(vibraciónAnterior, posiciónObjetivo, evaluación);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin Lerp
        vibraciónAnterior = posiciónObjetivo;
        vibradorCámara.localPosition = posiciónObjetivo;
        StartCoroutine(VibrarCámara());
    }

    private IEnumerator ModificarDistanciaMínima(float duraciónObjetivo, float distanciaObjetivo)
    {
        // Intercalación lineal sin curva
        moviendo = true;
        var distanciaActual = cámara.nearClipPlane;
        float tiempoLerp = 0;
        float evaluación = 0;

        while (tiempoLerp < duraciónObjetivo)
        {
            evaluación = tiempoLerp / duraciónObjetivo;
            cámara.nearClipPlane = Mathf.Lerp(distanciaActual, distanciaObjetivo, evaluación);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin Lerp
        cámara.nearClipPlane = distanciaObjetivo;
    }

    public bool ObtenerDisponibilidad()
    {
        return !moviendo;
    }
}
