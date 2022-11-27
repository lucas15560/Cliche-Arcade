using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float Delay;

    void Start()
    {
        StartCoroutine("DESTROY");
    }

    IEnumerator DESTROY()
    {
        yield return new WaitForSeconds(Delay);
        Destroy(this.gameObject);
    }
}
