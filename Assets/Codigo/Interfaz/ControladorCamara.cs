using System.Collections;
using UnityEngine;
using static Constantes;

public class ControladorCamara : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform transformCámara;
    [SerializeField] private Camera cámara;

    [Header("Variables")]
    [SerializeField] private float duraciónCámaraMenú;
    [SerializeField] private float duraciónCámaraJuego;
    [SerializeField] private float duraciónCámaraOperador;
    [SerializeField] private float duraciónCámaraUsuario;
    [SerializeField] private float duraciónCámaraFinal;

    [Header("Posiciones")]
    [SerializeField] private Transform posiciónMenú;
    [SerializeField] private Transform posiciónJuego;
    [SerializeField] private Transform posiciónOperador;
    [SerializeField] private Transform posiciónUsuario;
    [SerializeField] private Transform posiciónFinal;

    private ControladorMenu controladorMenu;
    private CámarasCine últimaCámara;
    private bool moviendo;

    private void Start()
    {
        controladorMenu = FindObjectOfType<ControladorMenu>();

        últimaCámara = CámarasCine.menú;
        transformCámara.localPosition = posiciónMenú.localPosition;
        transformCámara.localRotation = posiciónMenú.localRotation;
    }

    public void CambiarPosición(CámarasCine cámaraCine)
    {
        switch (cámaraCine)
        {
            case CámarasCine.menú:
                StartCoroutine(MoverCámara(duraciónCámaraMenú, posiciónMenú.localPosition, posiciónMenú.localRotation));
                break;
            case CámarasCine.juego:
                StartCoroutine(MoverCámara(duraciónCámaraJuego, posiciónJuego.localPosition, posiciónJuego.localRotation));
                break;
            case CámarasCine.operador:
                StartCoroutine(MoverCámara(duraciónCámaraOperador, posiciónOperador.localPosition, posiciónOperador.localRotation));
                break;
            case CámarasCine.usuario:
                StartCoroutine(MoverCámara(duraciónCámaraUsuario, posiciónUsuario.localPosition, posiciónUsuario.localRotation));
                break;
            case CámarasCine.final:
                controladorMenu.MostrarMenúJuego(false);
                StartCoroutine(MoverCámara(duraciónCámaraFinal, posiciónFinal.localPosition, posiciónFinal.localRotation));
                break;
        }

        últimaCámara = cámaraCine;
    }

    public void CambiarDistanciaMínima(float duraciónObjetivo, float distanciaObjetivo)
    {
        StartCoroutine(ModificarDistanciaMínima(duraciónObjetivo, distanciaObjetivo));
    }
    
    private IEnumerator MoverCámara(float duraciónObjetivo, Vector3 posiciónObjetivo, Quaternion rotaciónObjetivo)
    {
        // Intercalación lineal con curva
        moviendo = true;
        var posiciónInicio = transformCámara.localPosition;
        var rotaciónInicio = transformCámara.localRotation;

        float tiempoLerp = 0;
        float evaluaciónCurva = 0;

        while (tiempoLerp < duraciónObjetivo)
        {
            evaluaciónCurva = SistemaAnimacion.EvaluarCurva(tiempoLerp / duraciónObjetivo);
            transformCámara.localPosition = Vector3.Lerp(posiciónInicio, posiciónObjetivo, evaluaciónCurva);
            transformCámara.localRotation = Quaternion.Lerp(rotaciónInicio, rotaciónObjetivo, evaluaciónCurva);

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
            case CámarasCine.usuario:
                controladorMenu.MostrarMenúJuego(false);
                break;
            case CámarasCine.final:
                controladorMenu.FinalizarJuego();
                break;
        }
    }

    private IEnumerator ModificarDistanciaMínima(float duraciónObjetivo, float distanciaObjetivo)
    {
        // Intercalación lineal con curva
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
