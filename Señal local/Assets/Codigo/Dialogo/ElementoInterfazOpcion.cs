using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElementoInterfazOpcion : MonoBehaviour
{
    [Header("Multiplicador")]
    [SerializeField] private float multiplicadorTamaño;

    [Header("Referencias")]
    [SerializeField] private Button btnOpción;
    [SerializeField] private TMP_Text txtOpción;
    [SerializeField] private GameObject imgResaltado;
    [SerializeField] private GameObject imgElegido;

    [Header("Diálogo")]
    [Ocultar] public ElementoDialogo siguienteDiálogo;
    [Ocultar] public string texto;

    private Action enClic;

    public void Iniciar(ElementoOpcion elementoDiálogo, Action acción)
    {
        btnOpción.interactable = false;
        siguienteDiálogo = elementoDiálogo.siguienteDiálogo;
        txtOpción.text = elementoDiálogo.texto;
        enClic = acción;

        texto = elementoDiálogo.texto;
        imgElegido.SetActive(elementoDiálogo.yaElegido);

        OnPointerExit();
    }

    public void ActivarBotón()
    {
        btnOpción.interactable = true;
    }

    public void EnClic()
    {
        enClic.Invoke();
    }

    public void OnPointerEnter()
    {
        if (btnOpción.interactable)
        {
            btnOpción.transform.localScale *= multiplicadorTamaño;
            imgResaltado.SetActive(true);
        }
    }

    public void OnPointerExit()
    {
        btnOpción.transform.localScale = Vector3.one;
        imgResaltado.SetActive(false);
    }
}
