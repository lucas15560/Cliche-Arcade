using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pular : MonoBehaviour
{
    public string estado;
    public string AR = "ar";
    public string CHAO = "chao";

    private float jumpTimeCounter;
    public float jumpTime;
    public float jumpForce;
    private bool isJumping;
    private float moveInput;
    public bool nochao;

    private Rigidbody2D rb;
    private Animator animator;
    public Transform spritePlayer;
    public AudioSource walk;
    public GameObject Player;
    public Water water;

    void Start()
    {
        water = Player.GetComponent<Water>();
        rb = GetComponent<Rigidbody2D>();
        animator = spritePlayer.GetComponent<Animator>();
        walk = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetButton("Horizontal") && nochao == true)
        {
            walk.enabled = true;
        }
        else
        {
            walk.enabled = false;
        }

        if(Dialogue.PlayerDia == false)
        {
            KeyInputs();
        }
    }

    private void KeyInputs()
    {
        if (Input.GetKeyDown(KeyCode.Z) && estado == CHAO)
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKey(KeyCode.Z) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else { isJumping = false; }
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Z) && water.tocandoagua == true)
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
        }

    }
}
