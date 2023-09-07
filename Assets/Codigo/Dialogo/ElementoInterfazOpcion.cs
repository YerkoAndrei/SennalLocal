using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElementoInterfazOpcion : MonoBehaviour
{
    [Header("Multiplicador")]
    [SerializeField] private float multiplicadorTamaño;

    [Header("Referencias")]
    [SerializeField] private Button btnOpción;
    [SerializeField] private Image imgOpción;
    [SerializeField] private TMP_Text txtOpción;
    [SerializeField] private GameObject imgResaltado;
    [SerializeField] private GameObject imgElegido;

    [Header("Diálogo")]
    [Ocultar] public ElementoDialogo siguienteDiálogo;
    [Ocultar] public string texto;
    [Ocultar] public bool yaElegido;

    private Action enClic;

    public void Iniciar(ElementoOpcion elementoDiálogo, Action acción)
    {
        btnOpción.interactable = false;
        siguienteDiálogo = elementoDiálogo.siguienteDiálogo;
        yaElegido = elementoDiálogo.yaElegido;
        enClic = acción;

        txtOpción.text = SistemaTraduccion.ObtenerTraducción(elementoDiálogo.texto);
        texto = elementoDiálogo.texto;

        imgElegido.SetActive(elementoDiálogo.yaElegido);
        EnCurorFuera();
    }

    public void ActivarBotón(bool activar)
    {
        btnOpción.interactable = activar;
    }

    public void EnClic()
    {
        enClic.Invoke();
    }

    public void EnCurorDentro()
    {
        if (!btnOpción.interactable)
            return;

        btnOpción.transform.localScale *= multiplicadorTamaño;
        imgOpción.maskable = false;
        imgResaltado.SetActive(true);
    }

    public void EnCurorFuera()
    {
        btnOpción.transform.localScale = Vector3.one;
        imgOpción.maskable = true;
        imgResaltado.SetActive(false);
    }

    public void EnClicEntra()
    {
        if (yaElegido)
            SistemaSonidos.PresionarBotónSuave();
        else
            SistemaSonidos.PresionarBotónFuerte();
    }

    public void EnClicFuera()
    {
        if (yaElegido)
            SistemaSonidos.SoltarBotónSuave();
        else
            SistemaSonidos.SoltarBotónFuerte();
    }
}
