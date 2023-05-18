using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaAnimación : MonoBehaviour
{
    public static SistemaAnimación instancia;

    public AnimationCurve curvaAnimaciónCámara;

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
}
