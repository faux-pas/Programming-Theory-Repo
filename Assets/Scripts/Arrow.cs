using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody arrowRb;
    // Start is called before the first frame update
    void Start()
    {
        arrowRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(arrowRb.velocity);
    }

    
}
