using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private BoxCollider2D cameraBox;

    void Start()
    {
        cameraBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        FollowPlayerz();
    }

    void FollowPlayerz()
    {
        if(GameObject.Find("Boundary"))
        {
            transform.position = new Vector3(Mathf.Clamp(player.position.x, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.x + cameraBox.size.x / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.x - cameraBox.size.x / 2), 
                                            Mathf.Clamp(player.position.y + 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.y + cameraBox.size.y / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.y - cameraBox.size.y / 2),
                                            transform.position.z);
        }
    }
}
