using UnityEngine;
using UnityEngine.UI;
using static Constantes;

public class ElementoIdioma : MonoBehaviour
{
    public Idiomas idioma;
    public Button bot�n;

    public void OnPointerDown()
    {
        if(bot�n.interactable)
            SistemaSonidos.PresionarBot�nFuerte();
    }

    public void OnPointerUp()
    {
        if (bot�n.interactable)
            SistemaSonidos.SoltarBot�nFuerte();
    }
}
