using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peixe : EnemyController
{
    public GameObject Olho;
    private Animator animator;
    public Transform spritePlayer;
    public Visao visao;
    public ParticleSystem Effect;
    public bool PodeAtacar = true;
    public float ladoDireito = 1;

    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>(); 
        visao = Olho.GetComponent<Visao>();
    }

    protected override void Update()
    {
        if(visao.toquei == true && PodeAtacar == true)
        {
            StartCoroutine("attack2");
            Olho.SetActive(false);
            PodeAtacar = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = new Vector2(0f, 0f);
            StartCoroutine("Morte2");
        }
    }

    IEnumerator attack2()
    {
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(0.1f);
        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(0.2f);
        rb.AddForce(transform.right * speed * distanceAttack * ladoDireito, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
        animator.SetBool("Attack", false);
        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(0.6f);
        PodeAtacar = true;
        Olho.SetActive(true);
    }

    IEnumerator Morte2()
    {
        animator.SetBool("Morto", true);
        rb.AddForce(transform.up * 0.4f, ForceMode2D.Impulse);
        Effect.Play();
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}