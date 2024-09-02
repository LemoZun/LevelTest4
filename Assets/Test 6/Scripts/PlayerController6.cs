using UnityEngine;

public class PlayerController6 : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xMovement, 0, zMovement);
        if(direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }

        if (direction != Vector3.zero) // ��� �Ʒ��� ���Ͱ� zero��� ������ ���� �߰�
        {
            
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        }
    }
}

