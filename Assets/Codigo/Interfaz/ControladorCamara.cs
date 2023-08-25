using System.Collections;
using UnityEngine;
using static Constantes;

public class ControladorCamara : MonoBehaviour
{
    [Header("Referencias")]
    public Transform posicionadorCámara;
    [SerializeField] private Transform vibradorCámara;
    [SerializeField] private Camera cámara;

    [Header("Variables")]
    [SerializeField] private float duraciónCámaraMenú;
    [SerializeField] private float duraciónCámaraJuego;
    [SerializeField] private float duraciónCámaraOperador;
    [SerializeField] private float duraciónCámaraUsuario0;
    [SerializeField] private float duraciónCámaraUsuario1;
    [SerializeField] private float duraciónCámaraFinal0;
    [SerializeField] private float duraciónCámaraFinal1;

    [Header("Posiciones")]
    [SerializeField] private Transform posiciónMenú;
    [SerializeField] private Transform posiciónJuego;
    [SerializeField] private Transform posiciónOperador;
    [SerializeField] private Transform posiciónUsuario0;
    [SerializeField] private Transform posiciónUsuario1;
    [SerializeField] private Transform posiciónFinal0;
    [SerializeField] private Transform posiciónFinal1;

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
                StartCoroutine(MoverCámara(duraciónCámaraMenú, false, posiciónMenú.localPosition, posiciónMenú.localRotation));
                break;
            case CámarasCine.juego:
                if(últimaCámara == CámarasCine.menú)
                    StartCoroutine(MoverCámara(duraciónCámaraMenú, false, posiciónJuego.localPosition, posiciónJuego.localRotation));
                else
                    StartCoroutine(MoverCámara(duraciónCámaraJuego, false, posiciónJuego.localPosition, posiciónJuego.localRotation));
                break;
            case CámarasCine.operador:
                StartCoroutine(MoverCámara(duraciónCámaraOperador, false, posiciónOperador.localPosition, posiciónOperador.localRotation));
                break;
            case CámarasCine.usuario:
                StartCoroutine(MoverCámara(duraciónCámaraUsuario0, true, posiciónUsuario0.localPosition, posiciónUsuario0.localRotation));
                break;
            case CámarasCine.final:
                controladorMenu.MostrarMenúJuego(false);
                StartCoroutine(MoverCámara(duraciónCámaraFinal0, true, posiciónFinal0.localPosition, posiciónFinal0.localRotation));
                break;
        }

        últimaCámara = cámaraCine;
    }

    public void CambiarDistanciaMínima(float duraciónObjetivo, float distanciaObjetivo)
    {
        StartCoroutine(ModificarDistanciaMínima(duraciónObjetivo, distanciaObjetivo));
    }
    
    private IEnumerator MoverCámara(float duraciónObjetivo, bool secuencia, Vector3 posiciónObjetivo, Quaternion rotaciónObjetivo)
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
            evaluaciónCurva = SistemaAnimacion.EvaluarCurva(tiempoLerp / duraciónObjetivo);
            evaluaciónCurvaRotación = SistemaAnimacion.EvaluarCurvaCámara(tiempoLerp / duraciónObjetivo);
            posicionadorCámara.localPosition = Vector3.Lerp(posiciónInicio, posiciónObjetivo, evaluaciónCurva);
            posicionadorCámara.localRotation = Quaternion.Lerp(rotaciónInicio, rotaciónObjetivo, evaluaciónCurvaRotación);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin Lerp
        moviendo = false;
        switch (últimaCámara)
        {
            case CámarasCine.juego:
                controladorMenu.MostrarMenúJuego(true);
                break;
            case CámarasCine.menú:
            case CámarasCine.operador:
                controladorMenu.MostrarMenúJuego(false);
                break;
            case CámarasCine.usuario:
                if (secuencia)
                {
                    controladorMenu.MostrarMenúJuego(false);
                    StartCoroutine(MoverCámara(duraciónCámaraUsuario1, false, posiciónUsuario1.localPosition, posiciónUsuario1.localRotation));
                }
                break;
            case CámarasCine.final:
                if (secuencia)
                    StartCoroutine(MoverCámara(duraciónCámaraFinal1, false, posiciónFinal1.localPosition, posiciónFinal1.localRotation));
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
            evaluación = SistemaAnimacion.EvaluarCurvaCámara(tiempoLerp / duraciónObjetivo);
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
