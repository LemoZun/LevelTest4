using System.Collections;
using UnityEngine;

public class Bullet4 : MonoBehaviour
{
    [SerializeField] PooledObject pooledObject;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float bulletSpeed;
    private Vector3 direction;
    [SerializeField] float bulletLifeTime;
    Coroutine bulletLifeRoutine;


    private void Start()
    {

    }

    private void OnEnable()
    {
        
        direction = muzzlePoint.forward;
        if(bulletLifeRoutine == null)
            bulletLifeRoutine = StartCoroutine(BulletRoutine());


    }

    private void OnDisable()
    {
        if (bulletLifeRoutine != null)
            bulletLifeRoutine = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        pooledObject.ReturnPool();
    }




    private void Update()
    {
        {
            transform.Translate(direction * bulletSpeed * Time.deltaTime,Space.World); // 이게 문제였다 괜히 플레이어 상대위치 말고 그냥 space.world 해주면 되네..
        }

    }

    IEnumerator BulletRoutine()
    {
        yield return new WaitForSeconds(bulletLifeTime);        
        pooledObject.ReturnPool();
    }
}

//프리팹으로 보내면 계속 머즐포인트가 Null로 변해서 진행할수가 없다 왜지?? 

