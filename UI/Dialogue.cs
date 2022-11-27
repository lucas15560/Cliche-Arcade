using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [Header("Components")]
    public GameObject DialogueObj;
    public static bool PlayerDia;
    public Image Profile;
    public Text speechText;
    public Text actornNameText;
    public AudioSource typing;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        DialogueObj.SetActive(true);
        PlayerDia = true;
        Profile.sprite = p;
        sentences = txt;
        actornNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }

    public void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.S))
        {
            typingSpeed = -1f;
        }
        else
        {
            typingSpeed = 0.06f;
        }
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            typing.Play();
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                DialogueObj.SetActive(false);
                PlayerDia = false;
            }
        }
    }
}
