using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCoin : MonoBehaviour
{
    public int coins;
    public Text coinstext;
    public GameObject Effect;
    public AudioSource coin;

    void Start()
    {
        coins = 0;
    }

    void Update()
    {
        coinstext.text = coins.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coin.Play();
            coins = coins + 1;
            Destroy(collision.gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
    }
}
