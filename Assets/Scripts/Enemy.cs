using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody enemyRB;
    GameObject player;

    [SerializeField]protected float speed;
    protected int health;
    protected int abilityCharges;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAtPlayer();
        MoveTowardsPlayer();
    }

    protected void LookAtPlayer()
    {
        transform.LookAt(player.transform);
    }

    protected void MoveTowardsPlayer()
    {
        enemyRB.transform.position = Vector3.MoveTowards(enemyRB.transform.position,
            player.transform.position, speed);
    }
}
