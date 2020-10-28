using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomGenerator : MonoBehaviour
{
    public GameObject obstacle;

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        while (count != 10)
        {
            Vector3 position = new Vector3(Random.Range(0f, 9.0f), 1.1f, Random.Range(-9.0f, 0f));
            if (!Physics.CheckBox(position, new Vector3(1f, 1f, 1f)))
            {
                Instantiate(obstacle, position, Quaternion.identity);
                count++;
            }
        }
    }

}
