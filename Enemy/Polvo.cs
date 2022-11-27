using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polvo : EnemyController
{
    public bool PodeAtacar = true;
    private Animator animator;
    public Transform spritePlayer;
    public ParticleSystem Effect;
    public Rigidbody2D rb2;
    public GameObject Player;

    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>(); 
        rb2 = Player.GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();

        if(isMoving)
        {
            if(PodeAtacar == true)
            {
                var relativePos = player.position - transform.position;
                var angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
                var rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                transform.rotation = rotation;
                StartCoroutine("attack");
                PodeAtacar = false;
            }
        }

        if(health <= 0)
        {
            StartCoroutine("morte");
        }
    }

    IEnumerator attack()
    {
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1);
        Effect.Play();
        rb.AddForce(transform.up * 6f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
        animator.SetBool("Attack", false);
        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(0.7f);
        PodeAtacar = true;
    }

    IEnumerator morte()
    {
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
            rb2.AddForce(transform.up * 2, ForceMode2D.Impulse);
        }
    }
}
