using UnityEngine;

public class ControladorCable : MonoBehaviour
{
    [SerializeField] private Rigidbody entradaCable;
    [SerializeField] private Collider[] colisionesCable;
    [SerializeField] private FixedJoint cable;

    private void Awake()
    {
        foreach(var col in colisionesCable)
        {
            col.enabled = false;
        }

        cable.transform.position = entradaCable.position;
        cable.transform.rotation = entradaCable.rotation;

        cable.connectedBody = entradaCable;

        foreach (var col in colisionesCable)
        {
            col.enabled = true;
        }
    }
}
