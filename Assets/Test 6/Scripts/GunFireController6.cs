using System.Collections;
using UnityEngine;

public class GunFireController6 : MonoBehaviour
{
    [SerializeField] ObjectPool bulletPool;
    [SerializeField] PooledObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float shootingPeriod;
    Coroutine ShootingRoutine;
    



    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (ShootingRoutine == null)
                ShootingRoutine = StartCoroutine(ShootRoutine());
        }
        else
        {
            if(ShootingRoutine != null)
            {
                StopCoroutine(ShootingRoutine);
                ShootingRoutine = null;
            }
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

    IEnumerator ShootRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(shootingPeriod);


        while (true)
        {
            
            Fire();
            yield return delay;
        }
    }
        


}
