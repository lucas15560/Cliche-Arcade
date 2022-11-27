using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTKey : MonoBehaviour
{
    private Doorspen doorspen;
    public GameObject DoorToOpen;
    public GameObject inte;
    public bool tocando;
    public Collider2D col;

    void Start()
    {
        doorspen = DoorToOpen.GetComponent<Doorspen>();
        col = DoorToOpen.GetComponent<Collider2D>();
    }

    void Update()
    {
        if(tocando == true && Input.GetKeyDown(KeyCode.X))
        {
            col.isTrigger = true;
            doorspen.locked = false;
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inte.SetActive(true);
            tocando = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inte.SetActive(false);
            tocando = false;
        }
    }
}
