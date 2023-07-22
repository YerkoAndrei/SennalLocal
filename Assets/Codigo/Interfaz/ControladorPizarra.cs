using TMPro;
using UnityEngine;

public class ControladorPizarra : MonoBehaviour
{
    [Header("Textos")]
    [SerializeField] private GameObject txtUsuariosMuertos;
    [SerializeField] private GameObject txtUsuariosCapturados;
    [SerializeField] private GameObject txtUsuariosEscapados;

    [SerializeField] private GameObject txtDiálogosVistos;
    [SerializeField] private GameObject txtFinalesLogrados;
    [SerializeField] private GameObject txtPreguntasEncontradas;

    [Header("Cantidades")]
    [SerializeField] private TMP_Text txtCantidadUsuariosMuertos;
    [SerializeField] private TMP_Text txtCantidadUsuariosCapturados;
    [SerializeField] private TMP_Text txtCantidadUsuariosEscapados;

    [SerializeField] private TMP_Text txtCantidadDiálogosVistos;
    [SerializeField] private TMP_Text txtCantidadFinalesLogrados;
    [SerializeField] private TMP_Text txtCantidadPreguntasEncontradas;

    private void Start()
    {
        // Variable
        var muertos = SistemaMemoria.ObtenerUsuariosMuertos();
        var capturados = SistemaMemoria.ObtenerUsuariosCapturados();
        var escapados = SistemaMemoria.ObtenerUsuariosEscapados();

        var diálogos = SistemaMemoria.ObtenerDiálogosVistos();
        var finales = SistemaMemoria.ObtenerFinalesAlcanzados();
        var preguntas = SistemaMemoria.ObtenerPreguntasEncontradas();

        // Apaga / prende objeto
        txtUsuariosMuertos.SetActive(muertos > 0);
        txtUsuariosCapturados.SetActive(capturados > 0);
        txtUsuariosEscapados.SetActive(escapados > 0);

        txtDiálogosVistos.SetActive(diálogos > 0);
        txtFinalesLogrados.SetActive(finales > 0);
        txtPreguntasEncontradas.SetActive(preguntas > 0);

        // Texto
        txtCantidadUsuariosMuertos.text = muertos.ToString();
        txtCantidadUsuariosCapturados.text = capturados.ToString();
        txtCantidadUsuariosEscapados.text = escapados.ToString();

        txtCantidadDiálogosVistos.text = diálogos.ToString();
        txtCantidadFinalesLogrados.text = finales.ToString();
        txtCantidadPreguntasEncontradas.text = preguntas.ToString();
    }
}
