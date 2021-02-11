using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    Animator anim;
    float motionTimeTemp = 0f;
    Swipe swiper;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        anim.enabled = false;
        swiper = GameObject.Find("Swipe").GetComponent<Swipe>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            anim.enabled = true;
            anim.SetBool("isBending", true);
            anim.SetBool("released", false);
        }
        

        if (Input.GetMouseButton(0))
        {
            motionTimeTemp = 0.0022f * -swiper.SwipeDelta.x ;
            if (motionTimeTemp > 1.223f)
            {
                motionTimeTemp = 1.223f;
            }
            anim.SetFloat("motionTime", motionTimeTemp);
        }
        else if (motionTimeTemp >0.5f) 
        {
            
            anim.SetBool("isBending", false);
            anim.SetBool("released", true);

        }
        else
        {
            motionTimeTemp -= 2f * Time.deltaTime;
            anim.SetFloat("motionTime", motionTimeTemp);
        }
    }
}
