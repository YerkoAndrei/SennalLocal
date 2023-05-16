using System;
using UnityEngine;
using TMPro;

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

    public static int semilla;

    private ControladorDialogos controladorDiálogos;

    private void Start()
    {
        var fecha = DateTime.Parse("08/02/1996");
        var segundos = (int)(DateTime.Now - fecha).TotalSeconds;
        semilla = segundos;

        controladorDiálogos = FindObjectOfType<ControladorDialogos>();
        controladorDiálogos.gameObject.SetActive(false);

        menúInicio.SetActive(true);
        menúJuego.SetActive(false);

        panelInicio.SetActive(true);
        panelOpciones.SetActive(false);
        panelCréditos.SetActive(false);

        btnIniciar.SetActive(true);
        btnReiniciar.SetActive(false);
        btnReanudar.SetActive(false);

        txtVersión.text = Application.version;
    }

    public void EnClicIniciar()
    {
        menúInicio.SetActive(false);
        menúJuego.SetActive(true);

        // PENDIENTE animacion camara
        controladorDiálogos.gameObject.SetActive(true);
        controladorDiálogos.ComenzarJuego();
    }

    public void EnClicReiniciar()
    {
        menúInicio.SetActive(false);
        menúJuego.SetActive(true);

        // PENDIENTE animacion camara
        controladorDiálogos.gameObject.SetActive(true);
        controladorDiálogos.ComenzarJuego();
    }

    public void EnClicReanudar()
    {
        menúInicio.SetActive(false);
        menúJuego.SetActive(true);

        // PENDIENTE animacion camara
        controladorDiálogos.gameObject.SetActive(true);
    }

    public void EnClicPausar()
    {
        menúInicio.SetActive(true);
        menúJuego.SetActive(false);

        btnIniciar.SetActive(false);
        btnReiniciar.SetActive(true);
        btnReanudar.SetActive(true);

        // PENDIENTE animacion camara
        controladorDiálogos.gameObject.SetActive(false);
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
        panelInicio.SetActive(true);
        panelOpciones.SetActive(false);
        panelCréditos.SetActive(false);

        btnIniciar.SetActive(true);
        btnReiniciar.SetActive(false);
        btnReanudar.SetActive(false);
    }
}
