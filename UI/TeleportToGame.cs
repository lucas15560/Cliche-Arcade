using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportToGame : MonoBehaviour
{
    public AudioSource music;
    public GameObject inte;
    public GameObject player;
    public Rigidbody2D rb;
    public string Scene;
    public bool col;
    public bool click;
    public GameObject intro;

    void Start()
    {
        rb = player.transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        StartCoroutine("Pitch");
        
        if(click == true)
        {
            rb.velocity = Vector2.up * 1.3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inte.SetActive(true);
            col = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inte.SetActive(false);
            col = false;
        }
    }

    IEnumerator Pitch()
    {
        if(Input.GetKey(KeyCode.X) && col == true)
        {
            intro.SetActive(true);
            rb.gravityScale = 0;
            click = true;
            music.pitch = 0.3f;
            yield return new WaitForSeconds(0.5f);
            music.pitch = -0.3f;
            yield return new WaitForSeconds(0.5f);
            music.pitch = -0.5f;
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(Scene);
        }
    }
}
