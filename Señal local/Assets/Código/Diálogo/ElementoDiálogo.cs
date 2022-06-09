using UnityEngine;

public class ElementoDiálogo : MonoBehaviour
{
    public ControladorDiálogos.Personajes personaje;
    public string texto;

    [Header("Siguiente acción")]
    public ControladorDiálogos.TipoDiálogo tipoDiálogo;

    [Ocultar("tipoDiálogo", ControladorDiálogos.TipoDiálogo.opciones)]
    [SerializeField] private GameObject contenedorOpciones;

    [Ocultar("tipoDiálogo", ControladorDiálogos.TipoDiálogo.diálogo)]
    public ElementoDiálogo siguienteDiálogo;

    [Ocultar("tipoDiálogo", ControladorDiálogos.TipoDiálogo.final)]
    public ControladorDiálogos.TipoFinal tipoFinal;

    // [Ocultar] No puede ocultar arrays
    public ElementoOpción[] opciones => contenedorOpciones.GetComponentsInChildren<ElementoOpción>();
}
