using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private void Attack()
    {    
        animator.SetBool("Attack1h1", true);
        isAttacking = true;
    }

    private void EndAttack()
    {
        isAttacking = false;
        animator.SetBool("Attack1h1", false);
    }

    private void FixedUpdate()
    {
        LookAtPlayer();

        if (!inAttackRange)
        {
            MoveTowardsPlayer();
        }

        if (inAttackRange && !isAttacking)
        {
            Attack();
        }
    }

}
