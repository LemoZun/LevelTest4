using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xMovement, 0, zMovement).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        if (direction != Vector3.zero)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        }
    }
}

