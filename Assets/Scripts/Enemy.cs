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
        transform.LookAt(player.transform);
        //Vector3 playerPos = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        //enemyRB.transform.Translate(playerPos * speed * Time.deltaTime);        
    }
}
