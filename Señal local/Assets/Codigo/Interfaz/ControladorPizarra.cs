using TMPro;
using UnityEngine;

public class ControladorPizarra : MonoBehaviour
{
    [Header("Textos")]
    [SerializeField] private GameObject txtUsuariosHuidos;
    [SerializeField] private GameObject txtUsuariosMuertos;
    [SerializeField] private GameObject txtUsuariosCapturados;

    [SerializeField] private GameObject txtDiálogosVistos;
    [SerializeField] private GameObject txtFinalesLogrados;
    [SerializeField] private GameObject txtPreguntasEncontradas;

    [Header("Cantidades")]
    [SerializeField] private TMP_Text txtCantidadUsuariosHuidos;
    [SerializeField] private TMP_Text txtCantidadUsuariosMuertos;
    [SerializeField] private TMP_Text txtCantidadUsuariosCapturados;

    [SerializeField] private TMP_Text txtCantidadDiálogosVistos;
    [SerializeField] private TMP_Text txtCantidadFinalesLogrados;
    [SerializeField] private TMP_Text txtCantidadPreguntasEncontradas;

    private void Start()
    {
        // Variable
        var huidos = SistemaMemoria.instancia.ObtenerUsuariosHuidos();
        var muertos = SistemaMemoria.instancia.ObtenerUsuariosMuertos();
        var capturados = SistemaMemoria.instancia.ObtenerUsuariosCapturados();

        var diálogos = SistemaMemoria.instancia.ObtenerDiálogosVistos();
        var finales = SistemaMemoria.instancia.ObtenerFinalesAlcanzados();
        var preguntas = SistemaMemoria.instancia.ObtenerPreguntasEncontradas();

        // Apaga / prende objeto
        txtUsuariosHuidos.SetActive(huidos > 0);
        txtUsuariosMuertos.SetActive(muertos > 0);
        txtUsuariosCapturados.SetActive(capturados > 0);

        txtDiálogosVistos.SetActive(diálogos > 0);
        txtFinalesLogrados.SetActive(finales > 0);
        txtPreguntasEncontradas.SetActive(preguntas > 0);

        // Texto
        txtCantidadUsuariosHuidos.text = huidos.ToString();
        txtCantidadUsuariosMuertos.text = muertos.ToString();
        txtCantidadUsuariosCapturados.text = capturados.ToString();

        txtCantidadDiálogosVistos.text = diálogos.ToString();
        txtCantidadFinalesLogrados.text = finales.ToString();
        txtCantidadPreguntasEncontradas.text = preguntas.ToString();
    }
}
