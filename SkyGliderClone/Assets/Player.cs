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
    bool doneTorque = false; //variable to check if addtorque has been used
    bool Slowdown = false;
    float yDeg = 0f;
    float zDeg = 0f;
    Swipe swiper;

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
        throwVec = new Vector3(0f, moveSpeed * 0.2f,moveSpeed);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;
        anim.enabled = false;
        swiper = GameObject.Find("Swipe").GetComponent<Swipe>();
        

    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log(swiper.SwipeDelta);
        
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
                doneTorque = false;
                anim.enabled = true;
                anim.SetBool("isGliding", true);

                //if(rb.angularVelocity.x > 0) { rb.angularVelocity -= new Vector3(rb.angularVelocity.x / 500f, 0f, 0f) * Time.deltaTime; }
                rb.angularVelocity = new Vector3(0.01f, 0f, 0f);
                playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, Quaternion.Euler(90f, yDeg, 0f), 300f * Time.deltaTime);

                Slowdown = true;

            }
            else
            {
                Slowdown = false;
                anim.SetBool("isGliding", false);
                if (doneTorque == false)
                {
                    rb.AddRelativeTorque(600f,0f,0f, ForceMode.Force);
                    doneTorque = true;

                }
            }


            if (Input.GetMouseButton(1))
            {

                /*Vector3 tmp = playerTransform.eulerAngles;
                tmp.x = 90f;
                playerTransform.eulerAngles = tmp;*/

                //playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, Quaternion.Euler(90f, 45f, 0f), 300f * Time.deltaTime);
                yDeg += 30f * Time.deltaTime;
                //rb.velocity = Vector3.Scale(rb.velocity,playerTransform.forward) * Time.deltaTime *15;
                //Debug.Log(playerTransform.up);
                rb.AddForce(Vector3.right*4500*Time.deltaTime);
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

    private void FixedUpdate()
    {

        if (Slowdown)
        {
            rb.AddForce(-Physics.gravity / 2);
        }
    }




}
