using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public float speed = 2f;
    private float leftStart;
    private float leftEnd;
    private float rightStart;
    private float rightEnd;

    private bool opening = false;

    void Start()
    {
        leftStart = leftDoor.transform.position.z;
        leftEnd = leftStart + 2;
        rightStart = rightDoor.transform.position.z;
        rightEnd = rightStart - 2;
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(0, 0, speed);
        if (opening)
        {
            if (Math.Abs(leftDoor.transform.position.z - leftEnd) > 0.1)
            {
                leftDoor.transform.Translate(move * Time.deltaTime);
            }

            if (Math.Abs(rightDoor.transform.position.z - rightEnd) > 0.1)
            {
                rightDoor.transform.Translate((-move) * Time.deltaTime);
            }
        }
        else
        {
            if (Math.Abs(leftDoor.transform.position.z - leftStart) > 0)
            {
                leftDoor.transform.Translate((-move) * Time.deltaTime);

            }

            if (Math.Abs(rightDoor.transform.position.z - rightStart) > 0)
            {
                rightDoor.transform.Translate(move * Time.deltaTime);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            opening = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            opening = false;
        }
    }
}
