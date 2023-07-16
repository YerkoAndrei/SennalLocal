// YerkoAndrei
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Constantes;

public class ControladorMenu : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private GameObject menúInicio;
    [SerializeField] private GameObject menúJuego;

    [Header("Paneles")]
    [SerializeField] private GameObject panelBotones;
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private GameObject panelCréditos;

    [Header("Botones")]
    [SerializeField] private GameObject btnIniciar;
    [SerializeField] private GameObject btnReiniciar;
    [SerializeField] private GameObject btnReanudar;
    [SerializeField] private Button[] botones;

    [Header("Volúmenes")]
    [SerializeField] private Slider volumenMaestro;
    [SerializeField] private Slider volumenMúsica;
    [SerializeField] private Slider volumenEfectos;

    [Header("Animaciones")]
    [SerializeField] private RectTransform rectJuego;
    [SerializeField] private RectTransform rectBotones;
    [SerializeField] private RectTransform rectOpciones;
    [SerializeField] private RectTransform rectCréditos;

    [Header("Colores")]
    [SerializeField] private Color colorRojoClaro;
    [SerializeField] private Color colorRojoOscuro;

    [Header("Referencias")]
    [SerializeField] private Image panelOscuro;
    [SerializeField] private Image imgTítulo;
    [SerializeField] private TMP_Text txtVersión;

    private ControladorDialogos controladorDiálogos;
    private ControladorCamara controladorCámara;

    private bool iniciado;

    private void Start()
    {
        SistemaAnimacion.AnimarColor(imgTítulo, 2, colorRojoClaro, Color.white, null);
        SistemaAnimacion.AnimarColor(panelOscuro, 4, Color.black, Color.clear, () => panelOscuro.gameObject.SetActive(false));
        SistemaAnimacion.AnimarPanel(rectBotones, 0.5f, true, true, Direcciones.derecha, null);

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
        panelBotones.SetActive(true);
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

        ActivarBotones(false);
        SistemaAnimacion.AnimarColor(imgTítulo, 1, Color.white, colorTransparente, null);
        SistemaAnimacion.AnimarPanel(rectBotones, 0.3f, false, false, Direcciones.derecha, () =>
        {
            menúInicio.SetActive(false);
            ActivarBotones(true);
        });

        // PENDIENTE animacion camara
        controladorDiálogos.MostrarPaneles(true);
        controladorDiálogos.ComenzarJuego();
    }

    public void EnClicReiniciar()
    {
        menúInicio.SetActive(false);
        menúJuego.SetActive(false);

        ActivarBotones(false);
        SistemaAnimacion.AnimarColor(imgTítulo, 1, Color.white, colorTransparente, null);
        SistemaAnimacion.AnimarPanel(rectBotones, 0.3f, false, false, Direcciones.derecha, () =>
        {
            menúInicio.SetActive(false);
            ActivarBotones(true);
        });

        controladorDiálogos.Iniciar();

        // PENDIENTE animacion camara
        controladorDiálogos.MostrarPaneles(true);
        controladorDiálogos.ComenzarJuego();
    }

    public void EnClicReanudar()
    {
        if (!controladorDiálogos.ObtenerDisponibilidad() || !controladorCámara.ObtenerDisponibilidad())
            return;

        ActivarBotones(false);
        SistemaAnimacion.AnimarColor(imgTítulo, 1, Color.white, colorTransparente, null);
        SistemaAnimacion.AnimarPanel(rectBotones, 0.3f, false, false, Direcciones.derecha, () =>
        {
            menúInicio.SetActive(false);
            ActivarBotones(true);
        });

        controladorCámara.CambiarPosición(CámarasCine.juego);
        ControladorOsciloscopio.ReanudarNivelEstrés();
        ControladorRadio.ReanudarNombreRuta();
        controladorDiálogos.MostrarPaneles(true);
    }

    public void EnClicPausar()
    {
        if (!controladorDiálogos.ObtenerDisponibilidad() || !controladorCámara.ObtenerDisponibilidad())
            return;

        btnIniciar.SetActive(false);
        btnReiniciar.SetActive(true);
        btnReanudar.SetActive(true);

        menúInicio.SetActive(true);

        ActivarBotones(false);
        SistemaAnimacion.AnimarColor(imgTítulo, 1, colorTransparente, Color.white, null);
        SistemaAnimacion.AnimarPanel(rectJuego, 0.2f, false, false, Direcciones.arriba, () =>
        {
            menúJuego.SetActive(false);
            ActivarBotones(true);
        });
        SistemaAnimacion.AnimarPanel(rectBotones, 0.3f, true, true, Direcciones.derecha, null);

        controladorCámara.CambiarPosición(CámarasCine.menú);
        ControladorOsciloscopio.CambiarNivelEstrés(NivelEstrés.pausa);
        ControladorRadio.CambiarNombreRuta(Rutas.menú);
        controladorDiálogos.MostrarPaneles(false);
    }

    public void EnClicOpciones()
    {
        if (!panelOpciones.activeSelf)
        {
            panelOpciones.SetActive(true);

            ActivarBotones(false);
            SistemaAnimacion.AnimarPanel(rectOpciones, 0.2f, true, true, Direcciones.izquierda, null);
            SistemaAnimacion.AnimarPanel(rectBotones, 0.3f, false, false, Direcciones.derecha, () =>
            {
                panelBotones.SetActive(false);
                ActivarBotones(true);
            });
        }
        else
        {
            panelBotones.SetActive(true);

            ActivarBotones(false);
            SistemaAnimacion.AnimarPanel(rectBotones, 0.3f, true, true, Direcciones.derecha, null);
            SistemaAnimacion.AnimarPanel(rectOpciones, 0.2f, false, false, Direcciones.izquierda, () =>
            {
                panelOpciones.SetActive(false);
                ActivarBotones(true);
            });
        }
    }

    public void MostrarMenúJuego(bool mostrar)
    {
        menúJuego.SetActive(mostrar);
        SistemaAnimacion.AnimarPanel(rectJuego, 0.2f, mostrar, true, Direcciones.arriba, null);
    }

    public void EnClicCréditos()
    {
        if (!panelCréditos.activeSelf)
        {
            panelCréditos.SetActive(!panelCréditos.activeSelf);
            SistemaAnimacion.AnimarPanel(rectCréditos, 0.3f, true, true, Direcciones.izquierda, null);
        }
        else
            SistemaAnimacion.AnimarPanel(rectCréditos, 0.4f, false, false, Direcciones.izquierda, () => panelCréditos.SetActive(false));
    }

    public void ActivarBotones(bool activar)
    {
        foreach (var elemento in botones)
        {
            elemento.interactable = activar;
        }
    }

    public void EnClicSalir()
    {
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

    public void PresionarBotónFuerte()
    {
        SistemaSonidos.PresionarBotónFuerte();
    }

    public void SoltarBotónFuerte()
    {
        SistemaSonidos.SoltarBotónFuerte();
    }

    public void PresionarBotónSuave()
    {
        SistemaSonidos.PresionarBotónSuave();
    }

    public void SoltarBotónSuave()
    {
        SistemaSonidos.SoltarBotónSuave();
    }

    public void FinalizarJuego()
    {
        btnIniciar.SetActive(true);
        btnReiniciar.SetActive(false);
        btnReanudar.SetActive(false);

        menúInicio.SetActive(true);

        SistemaAnimacion.AnimarColor(imgTítulo, 2, colorRojoClaro, Color.white, null);
        SistemaAnimacion.AnimarPanel(rectBotones, 0.5f, true, true, Direcciones.derecha, null);
        SistemaAnimacion.AnimarPanel(rectJuego, 0.2f, false, true, Direcciones.arriba, () => menúJuego.SetActive(false));
    }
}
