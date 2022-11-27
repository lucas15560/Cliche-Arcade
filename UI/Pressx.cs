using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pressx : MonoBehaviour
{
    public string Scene;

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(Scene);
        }
    }
}
