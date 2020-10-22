using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public float Speed = 2.0f;
    bool _way = true;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x <= 10 && _way)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
        else
        {
            _way = false;
            transform.Translate(Speed * Time.deltaTime * -1, 0, 0);
            if (transform.position.x <= 0 && !_way)
            {
                _way = true;
            }

        }
    }

}
