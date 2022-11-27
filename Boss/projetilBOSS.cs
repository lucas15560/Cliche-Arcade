using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilBOSS : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed;
    public GameObject Effect;
    public Transform player;
    public bool atirar;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        Mirar();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(atirar)
        {
            Vector2 Vel = transform.up * Speed;
            rb.AddForce(Vel); 
        }

        if(!atirar)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            atirar = false;
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
    }

    void Mirar()
    {
        var relativePos = player.position - transform.position;
        var angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        atirar = true;
    }
}
