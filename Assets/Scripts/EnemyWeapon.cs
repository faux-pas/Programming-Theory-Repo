using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>();
            if(gameObject.transform.root.name == "WeakFastSkeleton")
            {
                damage = -1;
            }

            if(gameObject.transform.root.name == "StrongSlowSkeleton"){
                damage = -3;
            }

            player.Health = damage;

        }
    }
}
