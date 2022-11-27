using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;
    bool onRadious;

    private Dialogue dc;

    private void Start()
    {
        dc = FindObjectOfType<Dialogue>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && onRadious == true)
        {
            dc.Speech(profile, speechTxt, actorName);
            Destroy(this.gameObject);
        }
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

        if(hit != null)
        {
            onRadious = true;
        }
        else
        {
            onRadious = false;
        }
    }
}
