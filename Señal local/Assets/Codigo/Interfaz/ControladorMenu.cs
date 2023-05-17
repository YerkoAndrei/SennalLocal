using System;
using UnityEngine;
using TMPro;
using static Constantes;

public class ControladorMenu : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private GameObject menúJuego;
    [SerializeField] private GameObject menúInicio;

    [Header("Paneles")]
    [SerializeField] private GameObject panelInicio;
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private GameObject panelCréditos;

    [Header("Botones")]
    [SerializeField] private GameObject btnIniciar;
    [SerializeField] private GameObject btnReiniciar;
    [SerializeField] private GameObject btnReanudar;

    [Header("Referencias")]
    [SerializeField] private TMP_Text txtVersión;

    private ControladorDialogos controladorDiálogos;

    private void Start()
    {
        // Semilla aleatoria
        var fecha = DateTime.Parse("08/02/1996");
        var semilla = (int)(DateTime.Now - fecha).TotalSeconds;

        aleatorio = new System.Random(semilla);
        UnityEngine.Random.InitState(semilla);

        // Diálogos
        controladorDiálogos = FindObjectOfType<ControladorDialogos>();
        controladorDiálogos.MostrarPaneles(false);

        // Visual
        ControladorOsciloscopio.CambiarNivelEstrés(NivelEstrés.pausa);
        ControladorRadio.CambiarNombreRuta(Rutas.menú);

        // Menú
        panelInicio.SetActive(true);
        panelOpciones.SetActive(false);
        panelCréditos.SetActive(false);

        btnIniciar.SetActive(true);
        btnReiniciar.SetActive(false);
        btnReanudar.SetActive(false);

        menúInicio.SetActive(true);
        menúJuego.SetActive(false);

        txtVersión.text = Application.version;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menúJuego.activeSelf)
                EnClicPausar();
            else
                EnClicReanudar();
        }
    }

    public void EnClicIniciar()
    {
        menúInicio.SetActive(false);
        menúJuego.SetActive(true);

        // PENDIENTE animacion camara
        controladorDiálogos.MostrarPaneles(true);
        controladorDiálogos.ComenzarJuego();
    }

    public void EnClicReiniciar()
    {
        menúInicio.SetActive(false);
        menúJuego.SetActive(true);

        // PENDIENTE animacion camara
        controladorDiálogos.MostrarPaneles(true);
        controladorDiálogos.ComenzarJuego();
    }

    public void EnClicReanudar()
    {
        menúInicio.SetActive(false);
        menúJuego.SetActive(true);

        // PENDIENTE animacion camara
        ControladorOsciloscopio.ReanudarNivelEstrés();
        ControladorRadio.ReanudarNombreRuta();
        controladorDiálogos.MostrarPaneles(true);
    }

    public void EnClicPausar()
    {
        btnIniciar.SetActive(false);
        btnReiniciar.SetActive(true);
        btnReanudar.SetActive(true);

        menúInicio.SetActive(true);
        menúJuego.SetActive(false);

        // PENDIENTE animacion camara
        ControladorOsciloscopio.CambiarNivelEstrés(NivelEstrés.pausa);
        ControladorRadio.CambiarNombreRuta(Rutas.menú);
        controladorDiálogos.MostrarPaneles(false);
    }

    public void EnClicOpciones()
    {
        if(panelOpciones.activeSelf)
        {
            panelInicio.SetActive(true);
            panelOpciones.SetActive(false);
        }
        else
        {
            panelInicio.SetActive(false);
            panelOpciones.SetActive(true);
        }
    }

    public void EnClicCréditos()
    {
        panelCréditos.SetActive(!panelCréditos.activeSelf);
    }

    public void EnClicSalir()
    {
        Application.Quit();
    }

    public void FinalizarJuego()
    {
        btnIniciar.SetActive(true);
        btnReiniciar.SetActive(false);
        btnReanudar.SetActive(false);

        menúInicio.SetActive(true);
        menúJuego.SetActive(false);
    }
}
