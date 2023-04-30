using UnityEngine;
using static Constantes;

public class SistemaMemoria : MonoBehaviour
{
    public static SistemaMemoria instancia;

    public int diálogosVistos;
    public int finalesVistos;

    public int usuariosMuertos;
    public int usuariosCapturados;

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

    public bool VerificarDiálogoVisto(string texto)
    {
        return false;
    }
}
