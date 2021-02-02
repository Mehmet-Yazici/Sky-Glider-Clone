using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody rb;
    Animator anim;
    public float moveSpeed;
    Vector3 throwVec; 
   

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        throwVec = new Vector3(0f, moveSpeed, 0f);
    }
    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            anim.enabled = true;
            anim.SetBool("isGliding", true);
            rb.AddForce(rb.transform.forward * moveSpeed);
        }   
    }

    
}
