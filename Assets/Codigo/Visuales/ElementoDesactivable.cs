using UnityEngine;
using static Constantes;

public class ElementoDesactivable : MonoBehaviour
{
    [SerializeField] private Gráficos desactivador;
    [SerializeField] private GameObject[] elementos;

    public void DesActivar()
    {
        var desactivar = (SistemaAnimacion.gráficos == desactivador);

        if (desactivador == Gráficos.medios && SistemaAnimacion.gráficos == Gráficos.bajos)
            desactivar = true;

        foreach (var elemento in elementos)
        {
            elemento.SetActive(!desactivar);
        }
    }
}
