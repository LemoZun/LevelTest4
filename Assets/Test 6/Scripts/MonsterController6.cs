using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController6 : MonoBehaviour
{
    [SerializeField] PooledObject pooledObject;
    [SerializeField] Transform targetPosition;
    [SerializeField] float detectionRange;
    [SerializeField] float moveSpeed;    
    public event Action OnDied;
    Coroutine ShootingRayRoutine;


   
    private void FixedUpdate()
    {
        ShootRay();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            OnDied?.Invoke();
            pooledObject.ReturnPool();
        }
    }
    private void ShootRay()
    {
        Vector3 startedPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        // ���̰� �÷��̾�� ������ Ű ���̶����� �ٴڿ� ���ٶ���
        // y �����Ǹ� �״���ϰ� ���̸� �� �������� ����� ����
        Vector3 direction = (new Vector3(targetPosition.transform.position.x,transform.position.y,targetPosition.transform.position.z)-startedPosition).normalized;
        Debug.DrawRay(startedPosition, direction*detectionRange, Color.red,0.1f);

        if (Physics.Raycast(startedPosition, direction, out RaycastHit hit, detectionRange))
        {
            if (hit.collider.tag == "Player")
            {
                GoMove();
            }
            else
            {
                StopMove();
            }
        }
        else
        {
            StopMove();
        }
    }

    private void GoMove()
    {
        Debug.Log("�÷��̾� ����!");
        Vector3 curPlayerPosition = new Vector3(targetPosition.position.x, transform.position.y, targetPosition.position.z); //y���� �������������� ���� ��������                
        transform.position = Vector3.MoveTowards(transform.position, curPlayerPosition, moveSpeed * Time.deltaTime);
    }

    private void StopMove()
    {
        Debug.Log("�÷��̾� ã����!");
    }

    // �ڷ�ƾ���� ���ִ°ͺ��� update�� fixedUpdate���� ���ִ� �������� �ڿ�����������.

    private void OnEnable()
    {
        //if(ShootingRayRoutine == null ) 
        //    ShootingRayRoutine = StartCoroutine(ShootRayRoutine());

        //���� ��� ��ƾ ����
    }

    private void OnDisable()
    {
        


        //if(ShootingRayRoutine != null)
        //    StopCoroutine(ShootingRayRoutine);
        // ���� ��� ��ƾ ��

    }
    IEnumerator ShootRayRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(0.1f);
        while (true)
        {
            ShootRay();
            yield return delay;
        }
    }


    //�ϴ� ���̻� �ڷ�ƾ���� ó������ ������ �ּ�ó��

}
