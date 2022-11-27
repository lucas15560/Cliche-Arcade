using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Morte : MonoBehaviour
{
    public GameObject intro;
    public Image[] Vidas;
    private Animator animator;
    public Transform spritePlayer;
    public Rigidbody2D rb;
    public GameObject Player;
    public int ulti;
    public int Health;
    public ParticleSystem Effect;
    public bool invineravel;

    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>();
        rb = Player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Health <= 0)
        {
            Health = 99999;
            StartCoroutine(morte());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Morte")
        {
            if(invineravel == false)
            {
                rb.AddForce(transform.up * 3, ForceMode2D.Impulse);
                Destroy(Vidas[ulti]);
                ulti = ulti - 1;
                Health = Health - 1;
                StartCoroutine(Dano());
            }
        }
    }

    IEnumerator Dano()
    {
        invineravel = true;
        animator.SetBool("Morto", true);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Morto", false);
        yield return new WaitForSeconds(0.3f);
        invineravel = false;
    }

    IEnumerator morte()
    {
        Dialogue.PlayerDia = true;
        invineravel = true;
        Effect.Play();
        animator.SetBool("Morto", true);
        rb.AddForce(transform.up * 0.4f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.32f);
        animator.SetBool("Morto", true);
        intro.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        invineravel = false;
    }
}
