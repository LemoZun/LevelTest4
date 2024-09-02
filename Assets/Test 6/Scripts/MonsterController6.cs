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
        // 레이가 플레이어와 몬스터의 키 차이때문에 바닥에 꼬꾸라짐
        // y 포지션만 그대로하고 레이를 쏠 포지션을 제대로 설정
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
        Debug.Log("플레이어 감지!");
        Vector3 curPlayerPosition = new Vector3(targetPosition.position.x, transform.position.y, targetPosition.position.z); //y축은 감지범위떄문에 몬스터 기준으로                
        transform.position = Vector3.MoveTowards(transform.position, curPlayerPosition, moveSpeed * Time.deltaTime);
    }

    private void StopMove()
    {
        Debug.Log("플레이어 찾는중!");
    }

    // 코루틴에서 해주는것보다 update나 fixedUpdate에서 해주니 움직임이 자연스러워졌다.

    private void OnEnable()
    {
        //if(ShootingRayRoutine == null ) 
        //    ShootingRayRoutine = StartCoroutine(ShootRayRoutine());

        //레이 쏘기 루틴 시작
    }

    private void OnDisable()
    {
        


        //if(ShootingRayRoutine != null)
        //    StopCoroutine(ShootingRayRoutine);
        // 레이 쏘기 루틴 끝

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


    //일단 더이상 코루틴으로 처리하지 않으니 주석처리

}
