using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilInimigo : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed;
    public GameObject Effect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 Vel = transform.up * Speed;
        rb.AddForce(Vel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
    }
}
