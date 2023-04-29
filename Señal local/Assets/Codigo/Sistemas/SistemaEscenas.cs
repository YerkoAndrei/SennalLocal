﻿using UnityEngine;

public class SistemaEscenas : MonoBehaviour
{
    public static SistemaEscenas instancia;

    private void Start()
    {
        if (instancia != null)
            Destroy(gameObject);
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            Iniciar();
        }
    }

    private void Iniciar()
    {

    }

    public void CambiarEscena(string escena)
    {

    }
}
