using UnityEngine;

public class MoveTowardsMouse : MonoBehaviour
{
    private Camera mainCamera;
    private bool isMoving = false;
    private Vector3 targetPosition;

    public float movementSpeed = 5f;
    public float rotationSpeed = 5f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Planet"))
                {
                    targetPosition = hit.point;
                    targetPosition.y = transform.position.y;
                    isMoving = true;
                }
            }
        }

        if (isMoving)
        {
            Vector3 direction = targetPosition - transform.position;

            if (direction.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            else
            {
                isMoving = false;
            } 
            float dist = Vector3.Distance(transform.position, targetPosition);



            if(dist < 0.25f)
            {
                isMoving = false;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            transform.rotation = transform.rotation;
        }
    }
}
