using UnityEngine;

public class AnimadorLuzMecanica : MonoBehaviour
{
    public enum ModoLuz
    {
        palpitar,
        intercambiar,
    }

    [Header("Tipo")]
    [SerializeField] private ModoLuz tipoLuz;
    [SerializeField] private bool inicioPrendida;
    [SerializeField] private bool parpadeoSingular;
    [SerializeField] private float multiplicadorTiempo = 1;
    [SerializeField] private float tiempoParpadeo = 0.15f;

    [Header("Referencias")]
    [SerializeField] private Light luz;
    [SerializeField] private MeshRenderer renderizadorLuz;

    [Header("Colores")]
    [SerializeField] private Material luzAlta;
    [SerializeField] private Material luzBaja;

    private bool prendida;
    private float tiempo;
    private float temporizador;

    private float temporizadorParpadeo;
    private int contadorParpadeos;
    private int parpadeos;

    private void Start()
    {
        prendida = !inicioPrendida;

        ReiniciarTiemposAleatorios();
        CambiarEstadoLuz();
    }

    private void Update()
    {
        switch(tipoLuz)
        {
            case ModoLuz.palpitar:
                PalpitaLuz();
                break;
            case ModoLuz.intercambiar:
                CambiaLuz();
                break;
        }
    }

    private void PalpitaLuz()
    {
        temporizador -= Time.deltaTime;
        if (temporizador > 0)
            return;

        temporizadorParpadeo -= Time.deltaTime;
        if (temporizadorParpadeo > 0)
            return;

        CambiarEstadoLuz();
        temporizadorParpadeo = tiempoParpadeo;
        contadorParpadeos++;

        if (contadorParpadeos > parpadeos && prendida == inicioPrendida)
            ReiniciarTiemposAleatorios();
    }

    private void CambiaLuz()
    {
        temporizador -= Time.deltaTime;
        if (temporizador > 0)
            return;

        CambiarEstadoLuz();
        ReiniciarTiemposAleatorios();
    }

    private void CambiarEstadoLuz()
    {
        if (prendida)
            renderizadorLuz.material = luzBaja;
        else
            renderizadorLuz.material = luzAlta;

        luz.enabled = !prendida;
        prendida = !prendida;
    }

    private void ReiniciarTiemposAleatorios()
    {
        tiempo = Random.Range(10, 21);
        parpadeos = Random.Range(3, 7);

        tiempo *= multiplicadorTiempo;

        if (parpadeoSingular)
            parpadeos = 1;

        temporizador = tiempo;
        temporizadorParpadeo = tiempoParpadeo;
        contadorParpadeos = 0;
    }
}
