using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    public GameObject[] boxes;
    public int spawnAmount = 50;
    public Vector3[] spawnValues ;
    


    void Start()
    {
        spawnValues = new Vector3[spawnAmount];

        for (int i = 0; i<spawnAmount ;i++)
        {
            spawnValues[i] = new Vector3(Random.Range(-150f, 150f), 0f, Random.Range(-200f, 180f));
        }

        for (int k = 0; k < spawnAmount; k++)
        {
            Instantiate(boxes[Random.Range(0, boxes.Length)], spawnValues[k] + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        }
        
    }

    
    
}
