using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroIN : EnemyController
{
    public bool PodeAtacar = true;
    public GameObject Bullet;
    private Animator animator;
    public Transform spritePlayer;
    public ParticleSystem Effect;
    public Rigidbody2D rb2;
    public GameObject Player;
    public AudioSource Atir;

    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>(); 
        rb2 = Player.GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        var relativePos = player.position - transform.position;
        var angle = Mathf.Atan2(relativePos.y + 0.5f, relativePos.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        base.Update();

        if(isMoving)
        {
            if(PodeAtacar == true)
            {   
                PodeAtacar = false;
                StartCoroutine("attack4");
            }
        }
    
    }

    IEnumerator attack4()
    {
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("Attack", true);
        Atir.Play();
        Mirar();
        yield return new WaitForSeconds(0.7f);
        animator.SetBool("Attack", false);
        yield return new WaitForSeconds(1f);
        PodeAtacar = true;
    }

    void Mirar()
    {
        Instantiate(Bullet, this.transform.position, this.transform.rotation);
    }
}
