using UnityEngine;

public class ControladorCable : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidÚltimocable;
    [SerializeField] private Rigidbody entradaCable;

    private void Start()
    {
        rigidÚltimocable.transform.position = entradaCable.position;
        rigidÚltimocable.transform.rotation = entradaCable.rotation;
        rigidÚltimocable.GetComponent<FixedJoint>().connectedBody = entradaCable;

        rigidÚltimocable.constraints = RigidbodyConstraints.FreezePosition;
    }

    private void LateUpdate()
    {
        rigidÚltimocable.transform.position = entradaCable.position;
    }
}
