using System.Collections;
using UnityEngine;
using static Constantes;

public class ControladorCamara : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform cámara;

    [Header("Variables")]
    [SerializeField] private float duraciónCámaraCine;
    [SerializeField] private float duraciónCámaraMenú;
    [SerializeField] private float duraciónCámaraFinal;

    [Header("Posiciones")]
    [SerializeField] private Transform posiciónMenú;
    [SerializeField] private Transform posiciónJuego;
    [SerializeField] private Transform posiciónAnimación;

    private ControladorMenu controladorMenu;
    private CámarasCine últimaCámara;
    private bool moviendo;

    // Lerp
    private float tiempoLerp;
    private float evaluaciónCurva;

    private void Start()
    {
        controladorMenu = FindObjectOfType<ControladorMenu>();

        últimaCámara = CámarasCine.menú;
        cámara.localPosition = posiciónMenú.localPosition;
        cámara.localRotation = posiciónMenú.localRotation;
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
                    StartCoroutine(MoverCámara(duraciónCámaraCine, posiciónJuego.localPosition, posiciónJuego.localRotation));
                break;
            case CámarasCine.animación:
                StartCoroutine(MoverCámara(duraciónCámaraCine, posiciónAnimación.localPosition, posiciónAnimación.localRotation));
                break;
            case CámarasCine.final:
                controladorMenu.MostrarMenúJuego(false);
                StartCoroutine(MoverCámara(duraciónCámaraFinal, posiciónMenú.localPosition, posiciónMenú.localRotation));
                break;
        }

        últimaCámara = cámaraCine;
    }

    private IEnumerator MoverCámara(float duraciónObjetivo, Vector3 posiciónObjetivo, Quaternion rotaciónObjetivo)
    {
        // Intercalación lineal con curva
        tiempoLerp = 0;
        moviendo = true;
        var posiciónInicio = cámara.localPosition;
        var rotaciónInicio = cámara.localRotation;

        while (tiempoLerp < duraciónObjetivo)
        {
            evaluaciónCurva = SistemaAnimación.EvaluarCurva(tiempoLerp / duraciónObjetivo);
            cámara.localPosition = Vector3.Lerp(posiciónInicio, posiciónObjetivo, evaluaciónCurva);
            cámara.localRotation = Quaternion.Lerp(rotaciónInicio, rotaciónObjetivo, evaluaciónCurva);

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
            case CámarasCine.animación:
                controladorMenu.MostrarMenúJuego(false);
                break;
            case CámarasCine.final:
                controladorMenu.FinalizarJuego();
                break;
        }
    }

    public bool ObtenerDisponibilidad()
    {
        return !moviendo;
    }
}
