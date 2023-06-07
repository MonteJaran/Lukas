using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 5f, -10f);
    public float smoothness = 0.5f;

    private Vector3 initialOffset;
    private Vector3 desiredPosition;

    private void Start()
    {
        if (target != null)
        {
            initialOffset = transform.position - target.position;
            desiredPosition = target.position + initialOffset;
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            desiredPosition = target.position + initialOffset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothness * Time.deltaTime);
        }
    }
}
