// YerkoAndrei
using UnityEngine;
using static Constantes;

public class SistemaTraduccion : MonoBehaviour
{
    private static SistemaTraduccion instancia;

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
