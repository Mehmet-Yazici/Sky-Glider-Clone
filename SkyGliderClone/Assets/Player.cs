using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody rb;
    public float moveSpeed;
    Vector3 throwVec; 
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        throwVec = new Vector3(0f, moveSpeed, 0f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(rb.transform.forward * moveSpeed);
        }   
    }

    
}
