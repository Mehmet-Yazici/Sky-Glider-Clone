using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform top_bone;
    Rigidbody rb;
    Animator anim;
    Transform playerTransform;
    public float moveSpeed;
    Vector3 throwVec;
    bool onStick = true;
    
   

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        throwVec = new Vector3(0f, moveSpeed, 0f);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;
        anim.enabled = false;
        
    }


    // Update is called once per frame
    void Update()
    {
        //on the stick
        if (onStick)
        {
            playerTransform.position = top_bone.position;
            playerTransform.rotation = top_bone.rotation;
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Invoke("ThrowBall",0.31f);
        }   
    }

    void ThrowBall()
    {
        onStick = false;
        rb.useGravity = true;
        anim.enabled = true;
        anim.SetBool("isGliding", true);
        rb.AddForce(rb.transform.forward * moveSpeed * 100f);
    }

    


}
