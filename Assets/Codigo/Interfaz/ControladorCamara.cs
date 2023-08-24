using System.Collections;
using UnityEngine;
using static Constantes;

public class ControladorCamara : MonoBehaviour
{
    [Header("Referencias")]
    public Transform transformCámara;
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
                if(últimaCámara == CámarasCine.menú)
                    StartCoroutine(MoverCámara(duraciónCámaraMenú, posiciónJuego.localPosition, posiciónJuego.localRotation));
                else
                    StartCoroutine(MoverCámara(duraciónCámaraJuego, posiciónJuego.localPosition, posiciónJuego.localRotation));
                break;
            case CámarasCine.operador:
                StartCoroutine(MoverCámara(duraciónCámaraOperador, posiciónOperador.localPosition, posiciónOperador.localRotation));
                break;
            case CámarasCine.usuario:
                StartCoroutine(MoverCámara(duraciónCámaraUsuario0, posiciónUsuario0.localPosition, posiciónUsuario0.localRotation));
                break;
            case CámarasCine.final:
                controladorMenu.MostrarMenúJuego(false);
                StartCoroutine(MoverCámara(duraciónCámaraFinal0, posiciónFinal0.localPosition, posiciónFinal0.localRotation));
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
                controladorMenu.MostrarMenúJuego(false);
                break;
            case CámarasCine.usuario:
                controladorMenu.MostrarMenúJuego(false);
                StartCoroutine(MoverCámara(duraciónCámaraUsuario1, posiciónUsuario1.localPosition, posiciónUsuario1.localRotation));
                break;
            case CámarasCine.final:
                SistemaAnimacion.MostrarAnimación(Animaciones.FinalAutor);
                StartCoroutine(MoverCámara(duraciónCámaraFinal1, posiciónFinal1.localPosition, posiciónFinal1.localRotation));
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
