using System;
using System.Collections.Generic;

[Serializable]
public class ModeloDatos
{
    public string últimoNombre;

    public int usuariosMuertos;
    public int usuariosCapturados;
    public int usuariosEscapados;

    public List<string> diálogosElegidos;
    public List<string> opcionesElegidas;
    public List<string> finalesElegidos;
    public List<string> preguntasEncontradas;

    public ModeloDatos()
    {
        // Datos vacíos
        últimoNombre = string.Empty;
        usuariosMuertos = 0;
        usuariosCapturados = 0;
        usuariosEscapados = 0;

        diálogosElegidos = new List<string>();
        opcionesElegidas = new List<string>();
        finalesElegidos = new List<string>();
        preguntasEncontradas = new List<string>();
    }
}
