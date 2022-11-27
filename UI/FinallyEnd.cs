using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinallyEnd : MonoBehaviour
{
    public GameObject inte;
    public GameObject Final;
    public bool toca;

    void Update()
    {
        if(toca == true && Input.GetKeyDown(KeyCode.X))
        {
            Final.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inte.SetActive(true);
            toca = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inte.SetActive(false);
            toca = false;
        }
    }
}
