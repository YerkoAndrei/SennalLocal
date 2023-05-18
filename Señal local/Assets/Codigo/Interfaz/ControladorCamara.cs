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

    [Header("Posiciones")]
    [SerializeField] private Transform posiciónMenú;
    [SerializeField] private Transform posiciónJuego;
    [SerializeField] private Transform posiciónAnimación;

    private ControladorMenu controladorMenu;
    private CámarasCine últimaCámara;

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
                StartCoroutine(MoverCámara(duraciónCámaraMenú,
                                        cámara.localPosition, cámara.localRotation,
                                        posiciónMenú.localPosition, posiciónMenú.localRotation));
                break;
            case CámarasCine.juego:
                if(últimaCámara == CámarasCine.menú)
                StartCoroutine(MoverCámara(duraciónCámaraMenú,
                                        cámara.localPosition, cámara.localRotation,
                                        posiciónJuego.localPosition, posiciónJuego.localRotation));
                else
                    StartCoroutine(MoverCámara(duraciónCámaraCine,
                                        cámara.localPosition, cámara.localRotation,
                                        posiciónJuego.localPosition, posiciónJuego.localRotation));
                break;
            case CámarasCine.animación:
                StartCoroutine(MoverCámara(duraciónCámaraCine, 
                                        cámara.localPosition, cámara.localRotation,
                                        posiciónAnimación.localPosition, posiciónAnimación.localRotation));
                break;
        }

        últimaCámara = cámaraCine;
    }

    private IEnumerator MoverCámara(float duraciónObjetivo, Vector3 posiciónAnterior, Quaternion rotaciónAnterior, Vector3 posiciónObjetivo, Quaternion rotaciónObjetivo)
    {
        // Intercalación lineal con curva
        tiempoLerp = 0;
        while (tiempoLerp < duraciónObjetivo)
        {
            evaluaciónCurva = SistemaAnimación.instancia.curvaAnimaciónCámara.Evaluate(tiempoLerp / duraciónObjetivo);
            cámara.localPosition = Vector3.Lerp(posiciónAnterior, posiciónObjetivo, evaluaciónCurva);
            cámara.localRotation = Quaternion.Lerp(rotaciónAnterior, rotaciónObjetivo, evaluaciónCurva);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Término
        switch (últimaCámara)
        {
            case CámarasCine.juego:
                controladorMenu.MostrarMenúJuego(true);
                break;
            case CámarasCine.menú:
            case CámarasCine.animación:
                controladorMenu.MostrarMenúJuego(false);
                break;
        }
    }
}
