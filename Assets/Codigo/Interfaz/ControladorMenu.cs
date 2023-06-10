using System;
using UnityEngine;
using TMPro;
using static Constantes;
using UnityEngine.UI;

public class ControladorMenu : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private GameObject menúInicio;
    [SerializeField] private GameObject menúJuego;

    [Header("Paneles")]
    [SerializeField] private GameObject panelInicio;
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private GameObject panelCréditos;

    [Header("Botones")]
    [SerializeField] private GameObject btnIniciar;
    [SerializeField] private GameObject btnReiniciar;
    [SerializeField] private GameObject btnReanudar;

    [Header("Volúmenes")]
    [SerializeField] private Slider volumenMaestro;
    [SerializeField] private Slider volumenMúsica;
    [SerializeField] private Slider volumenEfectos;

    [Header("Referencias")]
    [SerializeField] private TMP_Text txtVersión;

    private ControladorDialogos controladorDiálogos;
    private ControladorCamara controladorCámara;

    private bool iniciado;

    private void Start()
    {
        // Semilla aleatoria
        var fecha = DateTime.Parse("08/02/1996");
        var semilla = (int)(DateTime.Now - fecha).TotalSeconds;

        aleatorio = new System.Random(semilla);
        UnityEngine.Random.InitState(semilla);

        // Diálogos
        controladorDiálogos = FindObjectOfType<ControladorDialogos>();

        // Visual
        controladorCámara = FindObjectOfType<ControladorCamara>();

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
        if (Input.GetKeyDown(KeyCode.Escape) && iniciado)
        {
            if (menúJuego.activeSelf)
                EnClicPausar();
            else
                EnClicReanudar();
        }
    }

    public void EnClicIniciar()
    {
        iniciado = true;
        menúInicio.SetActive(false);
        SistemaSonidos.ActivarBotónFuerte();

        // PENDIENTE animacion camara
        controladorDiálogos.MostrarPaneles(true);
        controladorDiálogos.ComenzarJuego();
    }

    public void EnClicReiniciar()
    {
        menúInicio.SetActive(false);
        menúJuego.SetActive(false);
        SistemaSonidos.ActivarBotónFuerte();

        // PENDIENTE animacion camara
        controladorDiálogos.MostrarPaneles(true);
        controladorDiálogos.ComenzarJuego();
    }

    public void EnClicReanudar()
    {
        if (!controladorDiálogos.ObtenerDisponibilidad() || !controladorCámara.ObtenerDisponibilidad())
            return;

        menúInicio.SetActive(false);
        SistemaSonidos.ActivarBotónFuerte();

        controladorCámara.CambiarPosición(CámarasCine.juego);
        ControladorOsciloscopio.ReanudarNivelEstrés();
        ControladorRadio.ReanudarNombreRuta();
        controladorDiálogos.MostrarPaneles(true);
    }

    public void EnClicPausar()
    {
        if (!controladorDiálogos.ObtenerDisponibilidad() || !controladorCámara.ObtenerDisponibilidad())
            return;

        SistemaSonidos.ActivarBotónSuave();
        btnIniciar.SetActive(false);
        btnReiniciar.SetActive(true);
        btnReanudar.SetActive(true);

        menúInicio.SetActive(true);
        menúJuego.SetActive(false);

        controladorCámara.CambiarPosición(CámarasCine.menú);
        ControladorOsciloscopio.CambiarNivelEstrés(NivelEstrés.pausa);
        ControladorRadio.CambiarNombreRuta(Rutas.menú);
        controladorDiálogos.MostrarPaneles(false);
    }

    public void EnClicOpciones()
    {
        SistemaSonidos.ActivarBotónSuave();

        if (panelOpciones.activeSelf)
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

    public void MostrarMenúJuego(bool mostrar)
    {
        menúJuego.SetActive(mostrar);
    }

    public void EnClicCréditos()
    {
        SistemaSonidos.ActivarBotónSuave();
        panelCréditos.SetActive(!panelCréditos.activeSelf);
    }

    public void EnClicSalir()
    {
        SistemaSonidos.ActivarBotónSuave();
        Application.Quit();
    }

    public void ActualizarVolumenMaestro()
    {
        SistemaSonidos.ActualizarVolumen(TipoSonido.Maestro, volumenMaestro.value);
    }

    public void ActualizarVolumenMúsica()
    {
        SistemaSonidos.ActualizarVolumen(TipoSonido.Música, volumenMúsica.value);
    }

    public void ActualizarVolumenEfectos()
    {
        SistemaSonidos.ActualizarVolumen(TipoSonido.Efectos, volumenEfectos.value);
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
