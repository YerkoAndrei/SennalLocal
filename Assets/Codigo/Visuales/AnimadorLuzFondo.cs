using System.Collections;
using UnityEngine;

public class AnimadorLuzFondo : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private MeshRenderer pared;
    [SerializeField] private Light luz;
    [SerializeField] private Light luzOperador;

    [Header("Colores")]
    [SerializeField] private Color luzAlta;
    [SerializeField] private Color luzBaja;

    private Material paredRoja;

    private void Start()
    {
        paredRoja = pared.material;
        paredRoja.SetColor("ColorLuz", luzBaja);
        luz.intensity = 0;
        luzOperador.intensity = 0;
    }

    public void AnimarEncuentro()
    {
        StartCoroutine(AnimaciónPared());
        StartCoroutine(AnimaciónLuz());
    }

    public void AnimarOperador()
    {
        StartCoroutine(AnimaciónLuzOperador());
    }

    private IEnumerator AnimaciónPared()
    {
        yield return new WaitForSeconds(1);

        float duraciónLerp = 5;
        float tiempoLerp = 0;
        float tiempo = 0;

        while (tiempoLerp < duraciónLerp)
        {
            tiempo = tiempoLerp / duraciónLerp;

            paredRoja.SetColor("ColorLuz", Color.Lerp(luzBaja, luzAlta, tiempo));

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        paredRoja.SetColor("ColorLuz", luzAlta);
    }

    private IEnumerator AnimaciónLuz()
    {
        yield return new WaitForSeconds(1);

        float duraciónLerp = 1;
        float tiempoLerp = 0;
        float tiempo = 0;

        while (tiempoLerp < duraciónLerp)
        {
            tiempo = tiempoLerp / duraciónLerp;
            luz.intensity = Mathf.Lerp(0, 3, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        luz.intensity = 3;
    }

    private IEnumerator AnimaciónLuzOperador()
    {
        yield return new WaitForSeconds(2);

        float duraciónLerp = 8;
        float tiempoLerp = 0;
        float tiempo = 0;

        while (tiempoLerp < duraciónLerp)
        {
            tiempo = tiempoLerp / duraciónLerp;
            luzOperador.intensity = Mathf.Lerp(0, 1, tiempo);

            tiempoLerp += Time.deltaTime;
            yield return null;
        }

        // Fin
        luzOperador.intensity = 1;
    }
}
