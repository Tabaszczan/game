using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCubeSquare : MonoBehaviour
{
    public float Speed = 9f;
    public float Step = 1f;
    public double Tolerance = 0.2;
    private const float Degrees = 90;
    readonly Vector3 _to = new Vector3(0, Degrees, 0);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((transform.position.x <= 10 && Math.Abs(transform.position.z) < Tolerance && Math.Abs(transform.eulerAngles.y) < Tolerance) ||
            (Math.Abs(transform.position.x - 10) < Tolerance && transform.position.z >= -10 && Math.Abs(transform.eulerAngles.y - 90) < Tolerance ) ||
            (transform.position.x >= 0 && Math.Abs(transform.position.z - (-10)) < Tolerance && Math.Abs(transform.eulerAngles.y - 180) < Tolerance) ||
            (Math.Abs(transform.position.x) < Tolerance && transform.position.z <= 0 && Math.Abs(transform.eulerAngles.y - 270) < Tolerance ))
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, transform.rotation.eulerAngles + _to, Time.deltaTime*Step);
        }


    }
}
