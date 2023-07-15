using UnityEngine;

public class AnimadorPersonaje : MonoBehaviour
{
    [SerializeField] private Animator animadorPersonaje;
    [SerializeField] private Animator animadorAccesorio;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            AnimarSentarse();

        if (Input.GetKeyDown(KeyCode.P))
            AnimarPararse();
    }

    // Operador
    public void AnimarEscribir()
    {
        animadorPersonaje.SetTrigger("Escribir");
    }

    public void AnimarSentarse()
    {
        animadorPersonaje.SetTrigger("Sentarse");
        animadorAccesorio.SetTrigger("Entrar");
    }

    public void AnimarPararse()
    {
        animadorPersonaje.SetTrigger("Pararse");
        animadorAccesorio.SetTrigger("Salir");
    }

    // Usuario
    public void AnimarEntrar()
    {
        animadorPersonaje.SetTrigger("Entrar");
    }
}
