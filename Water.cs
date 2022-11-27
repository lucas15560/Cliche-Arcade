using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public Transform spritePlayer;
    public Pular pular;
    public GameObject Effect;
    public bool tocandoagua;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = spritePlayer.GetComponent<Animator>();
        pular = GetComponent<Pular>();
    }

    void Update()
    {
        if(tocandoagua == true)
        {
            pular.jumpForce = 2.4f;
            pular.jumpTime = 0.1f;
            rb.gravityScale = 0.3f;
            rb.mass = 0.3f;
            rb.drag = 1;
        }
        else
        {
            pular.jumpForce = 4.4f;
            pular.jumpTime = 0.3f;
            rb.gravityScale = 1f;
            rb.mass = 1f;
            rb.drag = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            Instantiate(Effect, transform.position - new Vector3(0f, 1.4f, 0f), Quaternion.identity);
            animator.SetBool("NoChao", false);
            tocandoagua = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            animator.SetBool("NoChao", false); 
            tocandoagua = false;
        }
    }
}
