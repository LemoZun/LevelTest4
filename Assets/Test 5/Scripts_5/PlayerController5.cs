using UnityEngine;

public class PlayerController5 : MonoBehaviour
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

        if (direction != Vector3.zero) // 계속 아랫쪽 벡터가 zero라고 흰색경고가 떠서 추가
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        }
    }
}

