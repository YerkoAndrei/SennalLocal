using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaAnimación : MonoBehaviour
{
    public static SistemaAnimación instancia;

    [Header("Curvas")]
    [SerializeField] private AnimationCurve curvaAnimaciónEstandar;

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

    public float EvaluarCurva(float tiempo)
    {
        return curvaAnimaciónEstandar.Evaluate(tiempo);
    }
}
