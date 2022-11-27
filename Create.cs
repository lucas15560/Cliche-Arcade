using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject[] itens;
    public bool estatocando;

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach(GameObject ob in itens)
        { 
            if (other.CompareTag("Player"))
            {
                estatocando = true;
                ob.SetActive(true);
            } 
        }
    }
}
