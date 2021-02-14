using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform top_bone;
    GameObject meshPlayer;
    public Rigidbody rb;
    Animator anim;
    public Transform playerTransform;
    public float moveSpeed;
    Vector3 throwVec;
    bool onStick = true;
    bool EnteredTrigger;
    public bool EnteredTriggerOnce=false;
    public int counter = 0;
    bool doneTorque = false; //variable to check if addtorque has been used
    public bool Slowdown = false;
    float yDeg = 0f;
    float yDegRecorder = 0f;
    float zDeg = 0f;
    Swipe swiper;
    float swipeDeltaTotal = 0f;
    bool boxTrigger = false;
    bool cylTrigger = false;
    bool jumpDone = false;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "throw trigger")
        { 
            EnteredTrigger = true;
            EnteredTriggerOnce = true;
        }
        else if(other.tag == "Box"){
            Debug.Log("INNNNN");
            boxTrigger = true;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            Debug.Log("INNNNN");
            boxTrigger = true;

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


        //on the stick
        if (onStick)
        {
            playerTransform.position = top_bone.position;
            playerTransform.rotation = top_bone.rotation;
        }
        else if (boxTrigger) //use this movement until jump is over
        {
            
            
            if (!jumpDone) { //check if done once
                rb.AddForce(new Vector3(0, 54f, 0), ForceMode.Impulse);
                jumpDone = true;
            }
            
            rb.AddForce(new Vector3(0, -18.8f * Time.deltaTime, 0), ForceMode.Impulse);


            if (rb.velocity.y > 5.2f)
            {
                if (rb.velocity.y < 10f)
                {
                    boxTrigger = false;
                    jumpDone = false;
                    swiper.Reset();
                }
            }
                

        }
        else  //ready to fly
        {

            if (Input.GetMouseButton(0))
            {
                doneTorque = false;
                anim.enabled = true;
                anim.SetBool("isGliding", true);

                
                rb.angularVelocity = new Vector3(0.01f, 0f, 0f);
                playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, Quaternion.Euler(98f, yDeg, 0), 450f * Time.deltaTime);
                //playerTransform.RotateAround(new Vector3(playerTransform.position.x, playerTransform.position.y +5 , playerTransform.position.z), Vector3.forward,100 * Time.deltaTime);
                //playerTransform.rotation = Quaternion.AngleAxis(0, Vector3.up)   * Quaternion.AngleAxis(98f, Vector3.right) * Quaternion.AngleAxis(yDeg, Vector3.forward);
                //playerTransform.rotation = Quaternion.Euler(0f, 0, yDeg) * Quaternion.Euler(98f, 0, 0) ;
                


                //turning motion
                yDeg = yDegRecorder + swiper.SwipeDelta.x / 8f;
                //turning motion done

                Slowdown = true;

            }
            else
            {
                
                Slowdown = false;
                anim.SetBool("isGliding", false);
                yDegRecorder = yDeg;
                if (doneTorque == false)
                {
                    rb.AddRelativeTorque(600f,0f,0f, ForceMode.Force);
                    doneTorque = true;

                }
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
        rb.AddForce(throwVec * 85f);
    }

    private void FixedUpdate()
    {
        if (!boxTrigger)
        {
            if (Input.GetMouseButton(0))
            {


                if (180 - playerTransform.rotation.eulerAngles.x > 96 && 180 - playerTransform.rotation.eulerAngles.x < 100)
                {

                    Vector3 velocity = rb.velocity;
                    float magnitude = velocity.magnitude;
                    velocity = playerTransform.up * magnitude;


                    rb.velocity = velocity;
                }


            }
        }

        if (Slowdown)
        {
            //rb.AddForce(-Physics.gravity / 2);
        }
    }




}