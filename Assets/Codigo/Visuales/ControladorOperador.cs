using UnityEngine;

public class ControladorOperador : MonoBehaviour
{
    [SerializeField] private Animator animador;

    public void AnimarEscribir()
    {
        animador.SetTrigger("Escribir");
    }

    public void AnimarPararse()
    {
        animador.SetTrigger("Pararse");
    }
}
