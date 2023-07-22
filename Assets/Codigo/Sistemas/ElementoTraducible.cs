using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElementoTraducible : MonoBehaviour
{
    public string c�digo;

    public void MostrarTexto()
    {
        if (string.IsNullOrEmpty(c�digo))
            return;

        if (GetComponent<TMP_Text>() != null)
        {
            TMP_Text tmpText = GetComponent<TMP_Text>();
            tmpText.text = SistemaTraduccion.ObtenerTraducci�n(c�digo);
        }
        else if (GetComponent<Text>() != null)
        {
            Text oldText = GetComponent<Text>();
            oldText.text = SistemaTraduccion.ObtenerTraducci�n(c�digo);
        }
        else
            Debug.LogError("Componente no encontrado en: " + gameObject.name);
    }
}
