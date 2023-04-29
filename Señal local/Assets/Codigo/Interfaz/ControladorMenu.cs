using System;
using UnityEngine;

public class ControladorMenu : MonoBehaviour
{
    [SerializeField] private GameObject panelInicio;
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private GameObject panelCréditos;

    public static int semilla;

    private void Start()
    {
        var fecha = DateTime.Parse("08/02/1996");
        var segundos = (int)(DateTime.Now - fecha).TotalSeconds;
        semilla = segundos;

        panelInicio.SetActive(true);
        panelOpciones.SetActive(false);
        panelCréditos.SetActive(false);
    }

    public void EnClicIniciar()
    {
        SistemaEscenas.instancia.CambiarEscena("Juego");
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
}
