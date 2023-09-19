using UnityEngine;
using static Constantes;

public class ControladorOsciloscopio : MonoBehaviour
{
    private static ControladorOsciloscopio instancia;
    private static NivelEstrés nivelEstrésAnterior;

    [Header("Variables")]
    [SerializeField] private NivelEstrés nivelEstrésActual;
    [SerializeField] private float velocidadHorizontal;
    [SerializeField] private float velocidadVertical;

    [Header("Referencias visuales")]
    [SerializeField] private Transform visor;
    [SerializeField] private Transform luz;
    [SerializeField] private TrailRenderer rastro;

    [Header("Referencias posiciones")]
    [SerializeField] private Transform comienzo;
    [SerializeField] private Transform final;

    private bool subiendo;

    private Vector3 alto;
    private Vector3 bajo;
    private Vector3 objetivo;

    private void Awake()
    {
        instancia = this;
    }

    private void Start()
    {
        subiendo = true;
        objetivo = alto;
        visor.position = comienzo.position;
    }

    private void Update()
    {
        // En bucles es mejor Update que una corrutina
        MoverVisorHorizontal();
        MoverVertical();
    }

    private void MoverVertical()
    {
        luz.localPosition = Vector3.MoveTowards(luz.localPosition, objetivo, Time.deltaTime * velocidadVertical);

        if (Vector3.Distance(luz.localPosition, objetivo) <= 0)
        {
            if (subiendo)
                objetivo = bajo;
            else
                objetivo = alto;

            subiendo = !subiendo;
        }
    }

    private void MoverVisorHorizontal()
    {
        visor.position = Vector3.MoveTowards(visor.position, final.position, Time.deltaTime * velocidadHorizontal);

        // Control Trail Renderer
        if (Vector3.Distance(visor.position, final.position) <= 0.01f)
            rastro.emitting = false;
        else
            rastro.emitting = true;

        if (Vector3.Distance(visor.position, final.position) <= 0.0001f)
        {
            subiendo = true;
            visor.position = comienzo.position;
            luz.localPosition = new Vector3(luz.localPosition.x, 0, luz.localPosition.z);
        }
    }

    private void CambiarEstrés(NivelEstrés nivelEstrés)
    {
        if (nivelEstrésActual == nivelEstrés)
            return;

        // Centro
        luz.localPosition = new Vector3(luz.localPosition.x, 0, luz.localPosition.z);

        nivelEstrésAnterior = nivelEstrésActual;
        nivelEstrésActual = nivelEstrés;


        switch (nivelEstrésActual)
        {
            case NivelEstrés.muerto:
                velocidadVertical = 0;
                break;
            case NivelEstrés.bajo:
                velocidadVertical = 0.08f;
                alto = new Vector3(luz.localPosition.x, 0.008f, luz.localPosition.z);
                bajo = new Vector3(luz.localPosition.x, -(0.008f), luz.localPosition.z);
                break;
            case NivelEstrés.normal:
                velocidadVertical = 0.18f;
                alto = new Vector3(luz.localPosition.x, 0.015f, luz.localPosition.z);
                bajo = new Vector3(luz.localPosition.x, -(0.015f), luz.localPosition.z);
                break;
            case NivelEstrés.alto:
                velocidadVertical = 0.5f;
                alto = new Vector3(luz.localPosition.x, 0.02f, luz.localPosition.z);
                bajo = new Vector3(luz.localPosition.x, -(0.02f), luz.localPosition.z);
                break;
            case NivelEstrés.gritando:
                velocidadVertical = 0.8f;
                alto = new Vector3(luz.localPosition.x, 0.02f, luz.localPosition.z);
                bajo = new Vector3(luz.localPosition.x, -(0.02f), luz.localPosition.z);
                break;
        }
    }

    public static void CambiarNivelEstrés(NivelEstrés nivelEstrés)
    {
        instancia.CambiarEstrés(nivelEstrés);
    }

    public static void ReanudarNivelEstrés()
    {
        CambiarNivelEstrés(nivelEstrésAnterior);
    }
}
