using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder;
using Random = UnityEngine.Random;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public List<GameObject> RandomBlockList;
    private MeshFilter mesh;
    private GameObject randomBlock;
    private int _whileflag = 0;
    public int RandObjectCount = 0;

    void Start()
    {
        mesh = GetComponent<MeshFilter>();
        Vector3 position = transform.position;
        float maxX = mesh.mesh.bounds.center.x * 2;
        float maxZ = mesh.mesh.bounds.center.z * 2;
        for (int i = 0; i < RandObjectCount; i++)
        {
            this.positions.Add(new Vector3(Random.Range((int) position.x, maxX), 5, Random.Range((int) position.z, maxZ)));
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        while (_whileflag != RandObjectCount)
        {
            randomBlock = RandomBlockList[Random.Range(0, RandomBlockList.Count)];
            Instantiate(randomBlock, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
            _whileflag++;
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
