using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHorizontal : MonoBehaviour
{
    public float Speed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private float startPosition;
    private float endPosition;
    private bool toEnd = true;
    private CharacterController cc;

    void Start()
    {
        endPosition = transform.position.x + distance;
        startPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(Speed, 0, 0);
        if (Math.Abs(transform.position.x - endPosition) < 0.2)
        {
            toEnd = false;
        }
        else if (Math.Abs(transform.position.x - startPosition) < 0.2)
        {
            toEnd = true;
        }
        if (isRunning && toEnd)
        {
            transform.Translate(move * Time.deltaTime);
            cc.Move(move * Time.deltaTime);

        }
        else if (isRunning && !toEnd)
        {
            transform.Translate((-move) * Time.deltaTime);
            cc.Move((-move) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunning = true;
            cc = other.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunning = false;
        }
    }
}

