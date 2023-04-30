using System;
using System.Collections.Generic;
using static UnityEditor.PlayerSettings;

[Serializable]
public class ModeloDatos
{
    public int usuariosHuidos { get; set; }
    public int usuariosMuertos { get; set; }
    public int usuariosCapturados { get; set; }

    public List<string> diálogosElegidos { get; set; }
    public List<string> opcionesElegidas { get; set; }
    public List<string> finalesElegidos { get; set; }

    public ModeloDatos()
    {
        // Datos vacíos
        usuariosHuidos = 0;
        usuariosMuertos = 0;
        usuariosCapturados = 0;

        diálogosElegidos = new List<string>();
        opcionesElegidas = new List<string>();
        finalesElegidos = new List<string>();
    }
}
