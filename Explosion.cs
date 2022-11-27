using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject Effect;
    public GameObject Colidder;
    public GameObject Father;
    public GameObject ExSound;
    private Animator animator;
    public Transform spritePlayer;

    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pe"))
        {
            StartCoroutine("Ex");
        }

        if (collision.CompareTag("Morte"))
        {
            StartCoroutine("Ex");
        }
    }

    IEnumerator Ex()
    {
        animator.SetBool("Toc", true);
        yield return new WaitForSeconds(0.7f);
        Instantiate(Effect, Father.transform.position, Quaternion.identity);
        Instantiate(Colidder, Father.transform.position, Quaternion.identity);
        Instantiate(ExSound, Father.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
