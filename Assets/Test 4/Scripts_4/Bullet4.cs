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
            transform.Translate(direction * bulletSpeed * Time.deltaTime,Space.World); // �̰� �������� ���� �÷��̾� �����ġ ���� �׳� space.world ���ָ� �ǳ�..
        }

    }

    IEnumerator BulletRoutine()
    {
        yield return new WaitForSeconds(bulletLifeTime);        
        pooledObject.ReturnPool();
    }
}

//���������� ������ ��� ��������Ʈ�� Null�� ���ؼ� �����Ҽ��� ���� ����?? 

