using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaEscenas : MonoBehaviour
{
    public static SistemaEscenas instancia;

    [Header("Animaciones")]
    [SerializeField] private Animation panelNegro;
    [SerializeField] private Animation imgCarga;
    [SerializeField] private AnimationClip animaciónEntrada;
    [SerializeField] private AnimationClip animaciónSalida;

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
        panelNegro.gameObject.SetActive(false);
        imgCarga.gameObject.SetActive(false);

        animaciónEntrada.legacy = true;
        animaciónSalida.legacy = true;

        // Entrar o salir de la carga
        panelNegro.AddClip(animaciónEntrada, "Entrar");
        panelNegro.AddClip(animaciónSalida, "Salir");

        imgCarga.AddClip(animaciónEntrada, "Entrar");
        imgCarga.AddClip(animaciónSalida, "Salir");
    }

    public void CambiarEscena(string escena)
    {
        panelNegro.gameObject.SetActive(true);
        panelNegro.Play("Entrar");

        StartCoroutine(CambiarEscenaAsíncrona(escena));
    }

    private IEnumerator CambiarEscenaAsíncrona(string escena)
    {
        yield return new WaitUntil(() => !panelNegro.isPlaying);
        imgCarga.gameObject.SetActive(true);
        imgCarga.Play("Entrar");

        // Carga y cambia de escena
        var cargaAsíncrona = SceneManager.LoadSceneAsync(escena, LoadSceneMode.Single);
        yield return new WaitUntil(() => cargaAsíncrona.isDone);

        panelNegro.Play("Salir");
        imgCarga.Play("Salir");

        yield return new WaitUntil(() => !panelNegro.isPlaying);
        panelNegro.gameObject.SetActive(false);
        imgCarga.gameObject.SetActive(false);
    }
}
