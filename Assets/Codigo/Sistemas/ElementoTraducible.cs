using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElementoTraducible : MonoBehaviour
{
    public string código;

    public void MostrarTexto()
    {
        if (string.IsNullOrEmpty(código))
            return;

        if (GetComponent<TMP_Text>() != null)
        {
            TMP_Text tmpText = GetComponent<TMP_Text>();
            tmpText.text = SistemaTraduccion.ObtenerTraducción(código);
        }
        else if (GetComponent<Text>() != null)
        {
            Text oldText = GetComponent<Text>();
            oldText.text = SistemaTraduccion.ObtenerTraducción(código);
        }
        else
            Debug.LogError("Componente no encontrado en: " + gameObject.name);
    }
}
