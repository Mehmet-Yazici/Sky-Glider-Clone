using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    Animator anim;
    float motionTimeTemp = 0f;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
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
            anim.SetBool("isBending", true);
            anim.SetBool("released", false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("released", true);
            anim.SetBool("isBending", false);
            Debug.Log(motionTimeTemp);
        }

        if (Input.GetMouseButton(0))
        {
            motionTimeTemp += 0.0058f;
            if (motionTimeTemp > 1.223f)
            {
                motionTimeTemp = 1.223f;
            }
            anim.SetFloat("motionTime", motionTimeTemp);
        }
        else
        {
            motionTimeTemp -= 0.026f;
            if (motionTimeTemp < 0)
            {
                motionTimeTemp =0f;
            }
            anim.SetFloat("motionTime", motionTimeTemp);
        }
    }
}
