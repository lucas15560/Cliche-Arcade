using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorspen : MonoBehaviour
{
    private Animator animator;
    public Transform spritePlayer;
    public Collider2D col;
    public bool locked;

    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>(); 
    }

    void Update()
    {
        if(locked == true)
        {
            col.isTrigger = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.Play("DoorO");
        }
    }
}
