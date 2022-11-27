using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool Arma;
    public int health;
    public float distanceAttack;
    public float speed;

    protected bool isMoving = false;

    protected Rigidbody2D rb;
    protected Animator anim;
    protected Transform player;
    protected SpriteRenderer sprite;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    protected float PlayerDistance()
    {
        return Vector2.Distance(player.position, transform.position);
    }

    protected void Flip()
    {
        if(!Arma)
        {
            sprite.flipX = !sprite.flipX;
            speed *= -1;
        }
    }

    protected virtual void Update()
    {
        float distance = PlayerDistance();
        isMoving = (distance <= distanceAttack);

        if(isMoving)
        {
            if((player.position.x > transform.position.x && sprite.flipX) ||
            (player.position.x > transform.position.x && !sprite.flipX))
            {
                Flip();
            }
        }
    }
}
