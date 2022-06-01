using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody enemyRB;
    protected GameObject player;
    protected Animator animator;

    protected float speed;
    protected int abilityCharges;
    protected bool inAttackRange = false;
    protected bool isAttacking = false;
    protected string attack;

    private int health = 0;

    protected int Health
    {
        get { return health; }
        set
        {
            if ((health + value) < 0)
            {
                health = 0;
            }
            else
            {
                health += value;
            }
        }        
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    protected void LookAtPlayer()
    {
        transform.LookAt(player.transform);
    }

    protected void MoveTowardsPlayer()
    {
        enemyRB.transform.position = Vector3.MoveTowards(enemyRB.transform.position,
            new Vector3(player.transform.position.x, 0, player.transform.position.z), speed);
        Walk();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerMeleeRange"))
        {
            inAttackRange = true;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("playerMeleeRange"))
        {
            inAttackRange = false;
        }
    }

    protected virtual void Attack(string attack)
    {
        animator.SetBool(attack, true);
        isAttacking = true;
    }

    protected virtual void EndAttack(string attack)
    {
        isAttacking = false;
        animator.SetBool(attack, false);
    }

    protected void FixedUpdate()
    {

        if (!inAttackRange && !isAttacking)
        {
            LookAtPlayer();
            MoveTowardsPlayer();
            
        }

        if (inAttackRange && !isAttacking)
        {
            Idle();
            Attack(attack);
        }
    }

    protected void Walk()
    {
        animator.SetFloat("speedv", 1);
    }

    protected void Idle()
    {
        animator.SetFloat("speedv", 0);
    }
}
