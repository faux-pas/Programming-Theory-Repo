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
    protected bool inAttackRange = false;
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

        if (!inAttackRange)
        {
            MoveTowardsPlayer();
        }
    }

    protected void LookAtPlayer()
    {
        transform.LookAt(player.transform);
    }

    protected void MoveTowardsPlayer()
    {
        enemyRB.transform.position = Vector3.MoveTowards(enemyRB.transform.position,
            new Vector3(player.transform.position.x, 0, player.transform.position.z), speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerMeleeRange"))
        {
            inAttackRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("playerMeleeRange"))
        {
            inAttackRange = false;
        }
    }
}
