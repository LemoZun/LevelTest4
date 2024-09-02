using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController4 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

}
