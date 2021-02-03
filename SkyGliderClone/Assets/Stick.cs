using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    Animator anim;
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
        }
    }
}
