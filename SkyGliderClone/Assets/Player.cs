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
    public int counter = 0;
    int done = 0; //variable to check if addtorque has been used

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
                done = 0;
                anim.enabled = true;
                anim.SetBool("isGliding", true);

                //if(rb.angularVelocity.x > 0) { rb.angularVelocity -= new Vector3(rb.angularVelocity.x / 500f, 0f, 0f) * Time.deltaTime; }
                rb.angularVelocity = new Vector3(0.01f, 0f, 0f);
                playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, Quaternion.Euler(90f, 0f, 0f), 300f * Time.deltaTime);
                

            }
            else
            {
                anim.SetBool("isGliding", false);
                if (done == 0)
                {
                    rb.AddTorque(600f, 0f, 0f, ForceMode.Force);
                    done = 1;
                }
            }


            if (Input.GetMouseButton(1))
            {
                //rb.angularVelocity = new Vector3(0f, 0f, 0f);
                //playerTransform.rotation.eulerAngles.Set(90f, playerTransform.rotation.eulerAngles.y, playerTransform.rotation.eulerAngles.z);
                //playerTransform.eulerAngles  .Set(90f, playerTransform.eulerAngles.y, playerTransform.eulerAngles.z);
                Vector3 tmp = playerTransform.eulerAngles;
                tmp.x = 90f;
                playerTransform.eulerAngles = tmp;
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
