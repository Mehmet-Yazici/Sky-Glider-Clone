using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonBehaviour : MonoBehaviour
{
    
    public void OnButtonPress()
    {
        SceneManager.LoadScene("scene2");
    }
}
