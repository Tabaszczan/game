using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCubeSquare : MonoBehaviour
{
    public float Speed = 2f;
    public float Step = 2f;
    private float _x;
    private static readonly int[] WayList = new[] {0, 1, 2, 3};
    private int _way = WayList[0];
    Quaternion target = Quaternion.Euler(0, -90, 0);
    private bool _rotate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if ((transform.position.x <= 10 && _way == 0) || (transform.position.z <= 10 && _way == 1))
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
        else
        {
            if (!_rotate && transform.eulerAngles.y > 270 || Math.Abs(transform.eulerAngles.y) < 0.1)
            {
                
                transform.rotation =
                    Quaternion.Slerp(transform.rotation, target, Time.deltaTime * Step);
            }
            else
            {
                _rotate = true;
                transform.Translate(0, 0, Speed * Time.deltaTime);

            }
        }

    }
}
