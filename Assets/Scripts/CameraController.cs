using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;

    public float mousexSensitivity;
    public float mouseySensitivity;


    private void Start()
    {
        player = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousexSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseySensitivity * Time.deltaTime;

        player.Rotate(Vector3.up, mouseX);
        //transform.Rotate(Vector3.right, mouseY);

        
    }
}
