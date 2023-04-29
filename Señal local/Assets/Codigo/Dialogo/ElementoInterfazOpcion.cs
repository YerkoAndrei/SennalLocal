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

    [Header("Diálogo")]
    [Ocultar] public ElementoDialogo diálogo;

    private Action enClic;

    public void Iniciar(ElementoOpcion elementoDiálogo, Action acción)
    {
        btnOpción.interactable = false;
        diálogo = elementoDiálogo.siguienteDiálogo;
        txtOpción.text = elementoDiálogo.texto;
        enClic = acción;

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
