using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour
{
    public float moveSpeed;
    private float moveInput;
    float axis;
    public bool ladoDireito = true;

    private Rigidbody2D rb;
    private Animator animator;
    public Transform spritePlayer;

    void Start()
    {
        Dialogue.PlayerDia = false;
        rb = GetComponent<Rigidbody2D>();
        animator = spritePlayer.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        animator.SetFloat("Velocity", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        animator.SetFloat("VelocityF", (rb.velocity.y));

        if(Dialogue.PlayerDia == false)
        {
            axis = Input.GetAxis("Horizontal");

            if (axis > 0 && !ladoDireito)
                Vire();
            if (axis < 0 && ladoDireito)
                Vire();

            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
        else
        if(Dialogue.PlayerDia == true)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    void Vire()
    {
        ladoDireito = !ladoDireito;

        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        transform.localScale = novoScale;
    }
}