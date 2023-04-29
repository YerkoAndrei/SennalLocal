using UnityEngine;

public class SistemaMemoria : MonoBehaviour
{
    public static SistemaMemoria instancia;

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
