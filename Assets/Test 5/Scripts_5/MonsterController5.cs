using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterController5 : MonoBehaviour
{
    [SerializeField] Transform targetPosition;
    private Vector3 direction;
    Coroutine ShootingRay;


    private void OnEnable()
    {
        direction = (targetPosition.position-transform.position).normalized;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }


    }

    //IEnumerator ShootRayRoutine()


    //private void ShootRay()
    //{
    //    Debug.DrawRay(transform.position, transform.forward, Color.red);

    //    if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
    //    {
    //        if(hit.collider.tag == "Player")
    //        {
    //            //hit.collider
    //        }

    //    }
    //}

}
