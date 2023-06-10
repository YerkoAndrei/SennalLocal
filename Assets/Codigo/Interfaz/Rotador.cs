using UnityEngine;

public class Rotador : MonoBehaviour
{
    [Header("Velocidad")]
    [SerializeField] private float ánguloZ;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, ánguloZ * Time.deltaTime * 100));
    }
}
