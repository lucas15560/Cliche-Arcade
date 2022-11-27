using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyController
{
    public bool PodeAtacar = true;
    public GameObject Bullet;
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
                PodeAtacar = false;
                StartCoroutine("attack4");
            }
        }
    
    }

    IEnumerator attack4()
    {
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(0.4f);
        Mirar();
        yield return new WaitForSeconds(0.3f);
        Mirar();
        yield return new WaitForSeconds(0.3f);
        Mirar();
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Attack", false);
        yield return new WaitForSeconds(1f);
        PodeAtacar = true;
    }

    void Mirar()
    {
        var relativePos = player.position - transform.position;
        var angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        Instantiate(Bullet, this.transform.position, this.transform.rotation);
    }
}
