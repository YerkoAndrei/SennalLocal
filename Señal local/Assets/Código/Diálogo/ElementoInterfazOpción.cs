using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElementoInterfazOpción : MonoBehaviour
{
    [Header("Multiplicador")]
    [SerializeField] private float multiplicadorTamaño;

    [Header("Referencias")]
    [SerializeField] private Button btnOpcion;
    [SerializeField] private GameObject imgResaltado;
    [SerializeField] private TMP_Text txtOpción;

    [Header("Diálogo")]
    [Ocultar] public ElementoDiálogo dialogo;

    private Action enclic;

    public void Iniciar(ElementoOpción elementoDiálogo, Action acción)
    {
        btnOpcion.interactable = false;
        dialogo = elementoDiálogo.siguienteDiálogo;
        txtOpción.text = elementoDiálogo.texto;
        enclic = acción;

        OnPointerExit();
    }

    public void ActivarBotón()
    {
        btnOpcion.interactable = true;
    }

    public void EnClic()
    {
        enclic.Invoke();
    }

    public void OnPointerEnter()
    {
        if (btnOpcion.interactable)
        {
            btnOpcion.transform.localScale *= multiplicadorTamaño;
            imgResaltado.SetActive(true);
        }
    }

    public void OnPointerExit()
    {
        btnOpcion.transform.localScale = Vector3.one;
        imgResaltado.SetActive(false);
    }
}
