using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroConfig : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed;
    public GameObject Effect;
    public GameObject Atir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Destroy");
    }

    void Update()
    {
        Vector2 Vel = transform.right * Speed;
        rb.AddForce(Vel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
            Instantiate(Atir, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "Door")
        {
            Destroy(this.gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
            Instantiate(Atir, transform.position, Quaternion.identity);
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.6f);
        Destroy(this.gameObject);
    }
}
