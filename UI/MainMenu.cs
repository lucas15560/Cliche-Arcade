using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool IrParaGame;
    public bool Cut;
    public string Scene;
    public AudioSource music;

    public void Start()
    {
        if(Cut == true)
        {
            StartCoroutine("B");
        }
    }

    public void Update()
    {
        if(IrParaGame == true)
        {
            StartCoroutine("A");
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator A()
    {
        music.pitch = 1.19f;
        yield return new WaitForSeconds(0.5f);
        music.pitch = 0.3f;
        yield return new WaitForSeconds(0.5f);
        music.pitch = -0.5f;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Scene);
    }

    IEnumerator B()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    public void VoltarJogo()
    {
        Time.timeScale = 1;
    }

    public void cursoron()
    {
        Cursor.visible = true;
    }

    public void cursorfalse()
    {
        Cursor.visible = false;
    }

}