using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    public GameObject[] boxes;
    int spawnAmount = 95;
    public Vector3[] spawnValues ;
    bool valsOK = false;
    


    void Start()
    {
        spawnValues = new Vector3[spawnAmount];

        for (int i = 0; i<spawnAmount ;i++)
        {
            valsOK = false;
            Vector3 vals = new Vector3(Random.Range(-245f, 245f), 2f + Random.Range(-6f, 12.5f), Random.Range(-200f, 600f));

            //check to see if shapes intersect
            int c = 0;
            while (!valsOK)
            {
               if (vals.x < spawnValues[c].x + 27 && vals.x > spawnValues[c].x - 27)
               {
                    if (vals.z < spawnValues[c].z + 27 && vals.z > spawnValues[c].z - 27)
                    {
                        vals = new Vector3(Random.Range(-200f, 200f), 2f + Random.Range(-6f, 12.5f), Random.Range(-210f, 285f));
                        c=-1;    
                    }
               }
               c++;
                if (c == spawnValues.Length){ valsOK = true; }
                
            }

            //done

            Debug.Log(i);
            spawnValues[i] = vals;
        }

        for (int k = 0; k < spawnAmount; k++)
        {
            Instantiate(boxes[Random.Range(0, boxes.Length)], spawnValues[k] + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        }
        
    }

    
    
}
