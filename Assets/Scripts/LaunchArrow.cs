using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArrow : MonoBehaviour
{
    public GameObject projectile;


    public void FireArrow()
    {
        //Debug.Log("Launching Arrow");
        GameObject arrow = Instantiate(projectile, transform.position,
                                                     transform.rotation);

        arrow.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 30;
    }
}
