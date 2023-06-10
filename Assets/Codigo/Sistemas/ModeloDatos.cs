using System;
using System.Collections.Generic;

[Serializable]
public class ModeloDatos
{
    public string últimoNombre;

    public int usuariosHuidos;
    public int usuariosMuertos;
    public int usuariosCapturados;

    public List<string> diálogosElegidos;
    public List<string> opcionesElegidas;
    public List<string> finalesElegidos;
    public List<string> preguntasEncontradas;

    public ModeloDatos()
    {
        // Datos vacíos
        últimoNombre = string.Empty;
        usuariosHuidos = 0;
        usuariosMuertos = 0;
        usuariosCapturados = 0;

        diálogosElegidos = new List<string>();
        opcionesElegidas = new List<string>();
        finalesElegidos = new List<string>();
        preguntasEncontradas = new List<string>();
    }
}
