using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiroIN1 : EnemyController
{
    public bool PodeAtacar = true;
    private Animator animator;
    public Transform spritePlayer;
    public Rigidbody2D rb2;
    public GameObject Player;
    public Text mortotext;
    public static int morto;
    public int morto2;
    public float podemorrer;

    void Start()
    {
        morto = 0;
        animator = spritePlayer.GetComponent<Animator>(); 
        rb2 = Player.GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        mortotext.text = morto.ToString();
        morto2 = morto;
        base.Update();

        if(isMoving)
        {
            if(PodeAtacar == true)
            {   

            }
        }

        if(health <= 0 && podemorrer == 1f)
        {
            podemorrer = 2f;
            StartCoroutine("morte");
        }
    }

    IEnumerator morte()
    {
        morto = morto + 1;
        PodeAtacar = false;
        rb.velocity = new Vector2(0f, 0f);
        animator.SetBool("morto", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pe")
        {
            health = health - 1;
            rb.AddForce(transform.up * 2, ForceMode2D.Impulse);
        }
        else
        if (collision.gameObject.tag == "Damage")
        {
            health = health - 5;
            rb.AddForce(transform.up * 2, ForceMode2D.Impulse);
        }
    }
}
