using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public int avg;
    public Text display_t;

    public void Update()
    {
        float current = 0;
        current = 1/Time.deltaTime;
        avg = (int)current;
        display_t.text = "FPS: " + avg.ToString();
    }
}
