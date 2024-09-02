using UnityEngine;

public class GunFireController : MonoBehaviour
{
    [SerializeField] ObjectPool bulletPool;
    [SerializeField] PooledObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;
    



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
    private void Fire()
    {
        PooledObject bullet = bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);

        if (bullet != null)
        {
            bullet.transform.forward = muzzlePoint.position;
        }
        else
        {
            Debug.Log("총알이 생성되지 않음");
        }

    }
}
