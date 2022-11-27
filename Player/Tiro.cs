using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiro : MonoBehaviour
{
    public float waitdelay;
    public bool podeatirar;
    public GameObject Bullet;
    public GameObject Player;
    public Rigidbody2D rb;
    public float speed;
    private Animator animator;
    public Transform spritePlayer;
    public Text FlechasText;
    public int Flechas;
    public AudioSource Atir;

    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>();
        rb = Player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.localPosition = Player.transform.position;
        FlechasText.text = Flechas.ToString();

        transform.localScale = new Vector2(1, 1);
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) *  Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        if(Input.GetMouseButton(0) && Flechas > 0 && podeatirar == true)
        {
            StartCoroutine("Tiro2");
        }
        else
        if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Atirei", false);
        }

        if(Input.GetMouseButton(0) && Flechas <= 0 && podeatirar == true)
        {
            StartCoroutine("Recarrega");
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine("Recarrega");
        }
    }

    IEnumerator Tiro2()
    {
        podeatirar = false;
        rb.AddForce(-transform.right * speed / 1.7f, ForceMode2D.Impulse);
        Atir.Play();
        Flechas = Flechas - 1;
        animator.SetBool("Atirei", false);
        yield return new WaitForSeconds(0.02f);
        animator.SetBool("Atirei", true);
        Instantiate(Bullet, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(waitdelay);
        podeatirar = true;
    }

    IEnumerator Recarrega()
    {
        podeatirar = false;
        animator.SetBool("Atirei", false);
        animator.SetBool("re", true);
        yield return new WaitForSeconds(0.10f);
        animator.SetBool("re", false);
        animator.SetBool("Atirei", false);
        yield return new WaitForSeconds(0.80f);
        Flechas = 5;
        yield return new WaitForSeconds(0.10f);
        podeatirar = true;
    }
}