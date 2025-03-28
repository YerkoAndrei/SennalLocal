using UnityEngine;
using static Constantes;

public class LuzDesactivable : MonoBehaviour
{
    [SerializeField] private GameObject luzBaja;
    [SerializeField] private GameObject luzMedia;
    [SerializeField] private GameObject luzAlta;

    public void CambiarLuz(Gráficos gráficos)
    {
        switch (gráficos)
        {
            case Gráficos.bajos:
                luzBaja.SetActive(true);
                luzMedia.SetActive(false);
                luzAlta.SetActive(false);
                break;
            case Gráficos.medios:
                luzBaja.SetActive(false);
                luzMedia.SetActive(true);
                luzAlta.SetActive(false);
                break;
            case Gráficos.altos:
                luzBaja.SetActive(false);
                luzMedia.SetActive(false);
                luzAlta.SetActive(true);
                break;
        }
    }
}