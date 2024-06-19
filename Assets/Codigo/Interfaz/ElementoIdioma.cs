using UnityEngine;
using UnityEngine.UI;
using static Constantes;

public class ElementoIdioma : MonoBehaviour
{
    public Idiomas idioma;
    public Button botón;

    public void OnPointerDown()
    {
        if(botón.interactable)
            SistemaSonidos.PresionarBotónFuerte();
    }

    public void OnPointerUp()
    {
        if (botón.interactable)
            SistemaSonidos.SoltarBotónFuerte();
    }
}
