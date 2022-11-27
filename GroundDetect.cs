using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetect : MonoBehaviour
{
    public Pular pular;
    private Animator animator;
    public Transform spritePlayer;
    public Rigidbody2D rb;
    public GameObject Effect;
    public GameObject Player;

    public string estado;
    public string AR = "ar";
    public string CHAO = "chao";
    public bool nochao;

    void Start()
    {
        pular = Player.GetComponent<Pular>();
        animator = spritePlayer.GetComponent<Animator>();
        rb = Player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        pular.estado = estado;
        pular.AR = AR;
        pular.CHAO = CHAO;
        pular.nochao = nochao;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            nochao = true;
            estado = CHAO;
            animator.SetBool("NoChao", true);
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            nochao = false;
            estado = AR;
            animator.SetBool("NoChao", false);
        }
    }
}
