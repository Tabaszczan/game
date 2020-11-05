using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;

    public float sensitivity = 200f;

    private float xRotation = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        player.Rotate(Vector3.up * mouseXMove);

        xRotation -= mouseYMove;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

       transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       transform.Rotate(new Vector3(-mouseYMove, 0f, 0f), Space.Self);



    }
}
