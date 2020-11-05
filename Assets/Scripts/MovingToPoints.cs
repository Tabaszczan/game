using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToPoints : MonoBehaviour
{
    public List<Vector3> Points;
    public float speed = 2f;
    private int pointIndex = 0;
    private bool goingup = true;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (pointIndex <= Points.Count - 1 && goingup)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                Points[pointIndex], speed * Time.deltaTime);
            if (transform.position == Points[pointIndex])
            {
                pointIndex++;
            }
        }
        else
        {
            goingup = false;
        }

        if (pointIndex > 0 && !goingup)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                Points[pointIndex - 1], speed * Time.deltaTime);
            if (transform.position == Points[pointIndex - 1])
            {
                pointIndex--;
            }
        }
        else
        {
            goingup = true;
        }
    }
}
