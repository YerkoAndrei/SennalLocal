using UnityEngine;
using UnityEngine.Rendering;
using static Constantes;

public class LuzDesactivable : MonoBehaviour
{
    [SerializeField] private Light luz;

    public void CambiarLuz(Gráficos gráficos)
    {
        switch (gráficos)
        {
            case Gráficos.bajos:
                luz.shadows = LightShadows.Hard;
                luz.shadowResolution = LightShadowResolution.Low;
                break;
            case Gráficos.medios:
                luz.shadows = LightShadows.Hard;
                luz.shadowResolution = LightShadowResolution.Medium;
                break;
            case Gráficos.altos:
                luz.shadows = LightShadows.Soft;
                luz.shadowResolution = LightShadowResolution.High;
                break;
        }
    }
}
