using UnityEngine;

public class AnimadorLuz : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private MeshRenderer pared;
    [SerializeField] private Transform luz;

    [Header("Colores")]
    [SerializeField] private Color luzAlta;
    [SerializeField] private Color luzBaja;

    private Material paredRoja;
    private float multiplicador;
    private bool alzaLuz;

    private void Start()
    {
        paredRoja = pared.material;
        paredRoja.color = luzBaja;

        multiplicador = 10;
    }

    private void Update()
    {
        if (alzaLuz)
            paredRoja.color = Color.Lerp(paredRoja.color, luzAlta, Time.deltaTime * (multiplicador / 5));
        else
            paredRoja.color = Color.Lerp(paredRoja.color, luzBaja, Time.deltaTime * multiplicador);

        luz.Rotate(new Vector3(0, 0, Time.deltaTime * multiplicador));
    }

    public void AnimarEncuentro()
    {
        multiplicador = 100;
    }
}
