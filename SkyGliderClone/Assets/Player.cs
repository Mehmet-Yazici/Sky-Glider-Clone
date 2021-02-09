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
    bool EnteredTrigger;
    public bool EnteredTriggerOnce=false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "throw trigger")
        { 
            EnteredTrigger = true;
            EnteredTriggerOnce = true;
        }
    }



    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        throwVec = new Vector3(0f, moveSpeed * 0.8f,moveSpeed);
        
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
        else
        {

            if (Input.GetMouseButton(0))
            {
                anim.enabled = true;
                anim.SetBool("isGliding", true);
                rb.angularVelocity -= new Vector3(4f, 0f, 0f) * Time.deltaTime;
                Debug.Log(playerTransform.rotation.eulerAngles.x);
                /*if(rb.angularVelocity.x > 0) { 
                    rb.angularVelocity -= new Vector3(16f, 0f, 0f ) * Time.deltaTime;
                    
                    Debug.Log(playerTransform.rotation.eulerAngles.x);
                }
                else if(playerTransform.rotation.x >100 ||(playerTransform.rotation.x <-90f && playerTransform.rotation.x > -180f)){
                    playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, Quaternion.Euler(-95f, 0f, 0f), 750f * Time.deltaTime);
                } 
                else
                {
                    rb.angularVelocity = new Vector3(0f, 0f, 0f);
                    playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, Quaternion.Euler(90f, 0f, 0f), 750f * Time.deltaTime);
                }*/

            }
            else
            {
                anim.SetBool("isGliding", false);
                
            }


            if (Input.GetMouseButton(1))
            {
                rb.angularVelocity = new Vector3(0f, 0f, 0f);
                playerTransform.rotation.eulerAngles.Set(90f, playerTransform.rotation.eulerAngles.y, playerTransform.rotation.eulerAngles.z);
            }
        }

        if (GetComponent<Player>().EnteredTrigger){ 
            ThrowBall();
            EnteredTrigger = false;
        }
    }

    void ThrowBall()
    {
        onStick = false;
        rb.useGravity = true;
        rb.AddTorque(800f, 0f, 0f,ForceMode.Force);
        rb.AddForce(throwVec * 100f);
    }

    


}
