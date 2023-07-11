using UnityEngine;

public class AnimadorPersonaje : MonoBehaviour
{
    [SerializeField] private Animator animador;

    // Operador
    public void AnimarEscribir()
    {
        animador.SetTrigger("Escribir");
    }

    public void AnimarSentarse()
    {
        animador.SetTrigger("Sentarse");
    }

    public void AnimarPararse()
    {
        animador.SetTrigger("Pararse");
    }

    // Usuario
    public void AnimarEntrar()
    {
        animador.SetTrigger("Entrar");
    }
}
