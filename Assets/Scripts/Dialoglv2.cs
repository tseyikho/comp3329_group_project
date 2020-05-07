using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialoglv2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public SceneChanger sceneChanger;
    public GameObject whiteBackground;
    public GameObject continueButton;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {       
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {

            //Debug.Log("index: " + index);

            // Question 1
            if (index == 2)
            {                
                //Instantiate(whiteBackground, new Vector3(0, 0, 0), Quaternion.identity);
                sceneChanger.SceneQuestion1();
            }

            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
}
