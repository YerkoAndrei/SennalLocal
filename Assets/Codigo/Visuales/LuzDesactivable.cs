using UnityEngine;
using UnityEngine.Rendering;
using static Constantes;

public class LuzDesactivable : MonoBehaviour
{
    [SerializeField] private Light luz;

    public void CambiarLuz(Gr�ficos gr�ficos)
    {
        switch (gr�ficos)
        {
            case Gr�ficos.bajos:
                luz.shadows = LightShadows.Hard;
                luz.shadowResolution = LightShadowResolution.Low;
                break;
            case Gr�ficos.medios:
                luz.shadows = LightShadows.Hard;
                luz.shadowResolution = LightShadowResolution.Medium;
                break;
            case Gr�ficos.altos:
                luz.shadows = LightShadows.Soft;
                luz.shadowResolution = LightShadowResolution.High;
                break;
        }
    }
}
