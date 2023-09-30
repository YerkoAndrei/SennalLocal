using UnityEngine;
using static Constantes;

public class ElementoDesactivable : MonoBehaviour
{
    [SerializeField] private Gr�ficos desactivador;
    [SerializeField] private GameObject[] elementos;

    public void DesActivar()
    {
        var desactivar = (SistemaAnimacion.gr�ficos == desactivador);

        if (desactivador == Gr�ficos.medios && SistemaAnimacion.gr�ficos == Gr�ficos.bajos)
            desactivar = true;

        foreach (var elemento in elementos)
        {
            elemento.SetActive(!desactivar);
        }
    }
}
