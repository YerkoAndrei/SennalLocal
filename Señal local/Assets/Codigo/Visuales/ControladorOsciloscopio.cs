using UnityEngine;

public class ControladorOsciloscopio : MonoBehaviour
{

    [Header("Variables")]
    [SerializeField] private float velocidadHorizontal;
    [SerializeField] private float velocidadVertical;
    [SerializeField] private float máximaSeparación;

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

    void Start()
    {
        visor.position = comienzo.position;

        alto = new Vector3(luz.localPosition.x, luz.localPosition.y + máximaSeparación, luz.localPosition.z);
        bajo = new Vector3(luz.localPosition.x, luz.localPosition.y - máximaSeparación, luz.localPosition.z);

        subiendo = true;
        objetivo = alto;
    }

    private void Update()
    {
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

        if (Vector3.Distance(visor.position, final.position) <= 0.01)
            rastro.emitting = false;
        else
            rastro.emitting = true;

        if (Vector3.Distance(visor.position, final.position) <= 0.0001f)
        {
            subiendo = true;
            visor.position = comienzo.position;
        }
    }
}
