using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;

    private bool isAlive = true;
    private int health;
    public float walkSpeed;
    public float runSpeed;
    public float moveSpeed;
    float moveX = 0f;
    float moveY = 0f;

    float horizontal;
    float vertical;

    public int Health
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

            if (value < 0)
            {
                animator.SetBool("Hit", true);
                Debug.Log($"{gameObject.name} took {value} damage and now has {health} health.");
            }

            if (health == 0)
            {
                animator.SetBool("Death", true);
                isAlive = false;
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Health = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }
        Move();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("MouseDown");
            FireBow();
        }
    }

    private void FireBow()
    {
        animator.SetTrigger("FireBow");
    }

    public void TriggerFireArrow()
    {
        GameObject arrowSpawner = GameObject.Find("arrowSpawner");
        var projectile = arrowSpawner.GetComponent<LaunchArrow>();
        //Debug.Log("Should Trigger Arrow");
        projectile.FireArrow();

    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Debug.Log($"H:{horizontal}, V: {vertical}");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement.Normalize();

        /**
         * if the player is moving at all and shift isn't pressed
         * then run. Run will handle the directions in the method
         */
        if (vertical != 0 || horizontal != 0)
        {
            Run();
        }

        /**
         * if no input then character isn't moving
         */
        if(horizontal == 0 && vertical == 0)
        {
            Idle();
        }

        animator.SetFloat("MoveY", moveY);
        animator.SetFloat("MoveX", moveX);
        transform.Translate(movement * Time.deltaTime * moveSpeed);

        //transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }
        else
        {
            moveSpeed = walkSpeed;
        }
        
        moveY = vertical;
        moveX = horizontal;
    }

    void Sprint()
    {
        moveSpeed = runSpeed;
    }

    void Idle()
    {
        moveY = 0f;
        moveX = 0f;
    }

}
