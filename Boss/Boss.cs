using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public int health;
    private float timeBtwDamage = 1.5f;
	public bool isFlipped = false;

    public GameObject Effect;
    public GameObject Video;
    public Transform player;
    public Animator camAnim;
    public Slider healthBar;
    private Animator anim;
    public GameObject Projetil;
    public GameObject Projetil2;
    public GameObject Projetil3;
    private Rigidbody2D rb;
    public bool isDead;
    public bool Attack;
    public bool Teleport;
    private int rand;
    private int rand2;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(0f, 0f);
        LookAtPlayer();

        if(Attack == true)
        {
            StartCoroutine("AtirarMuitokk");
            rand = Random.Range(0, 3);
        }

        if(Teleport == true)
        {
            StartCoroutine("Teleport2");
            rand2 = Random.Range(0, 2);
        }

        if (health <= 0) {
            anim.SetTrigger("death");
            StartCoroutine("Morte");
        }

        if (timeBtwDamage > 0) {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isDead == false) {
            if (timeBtwDamage <= 0) {
                camAnim.SetTrigger("shake");
            }
        } 

        if (other.CompareTag("Pe") && isDead == false) {
            if (timeBtwDamage <= 0) {
                health = health - 1;
                Destroy(other.gameObject);
            }
        }
    }

    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
            transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
            transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
			isFlipped = true;
		}
	}

    IEnumerator AtirarMuitokk()
    {
        if(rand == 0)
        {
            Attack = false;
            yield return new WaitForSeconds(0.6f);
            Instantiate(Projetil, this.transform.position, this.transform.rotation);
            yield return new WaitForSeconds(0.3f);
            Instantiate(Projetil, this.transform.position, this.transform.rotation);
            yield return new WaitForSeconds(0.3f);
            Instantiate(Projetil, this.transform.position, this.transform.rotation);            
        }
        else
        if(rand == 1)
        {
            Attack = false;
            yield return new WaitForSeconds(0.6f);
            Projetil2.SetActive(true);
            yield return new WaitForSeconds(3.4f);
            Projetil2.SetActive(false);
        }
        else
        if(rand == 2)
        {
            Attack = false;
            yield return new WaitForSeconds(0.6f);
            Projetil3.SetActive(true);
            yield return new WaitForSeconds(3.6f);
            Projetil3.SetActive(false);
        }
    }

    IEnumerator Teleport2()
    {
        if(rand2 == 0)
        {
            Teleport = false;
            yield return new WaitForSeconds(1f);
            transform.localPosition = new Vector3(transform.localPosition.x + 6f, transform.localPosition.y, transform.localPosition.z); 
        }
        else
        if(rand2 == 1)
        {
            Teleport = false;
            yield return new WaitForSeconds(1f); 
            transform.localPosition = new Vector3(transform.localPosition.x - 6f, transform.localPosition.y, transform.localPosition.z); 
        }
    }

    IEnumerator Morte()
    {
        Instantiate(Effect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f); 
        Instantiate(Effect, transform.position, Quaternion.identity);
        Video.SetActive(true);
        Destroy(this.gameObject);
    }
}
