using System;
using UnityEngine;

public class ControladorMenu : MonoBehaviour
{
    public static int semilla;

    private void Start()
    {
        var fecha = DateTime.Parse("08/02/1996");
        var segundos = (int)(DateTime.Now - fecha).TotalSeconds;
        semilla = segundos;
    }

    private void Update()
    {
        
    }
}
