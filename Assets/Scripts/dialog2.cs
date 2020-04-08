using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialog2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public GameObject Picture1;
    public GameObject continueButton;

    public void NextSentence()
    {
        Instantiate(Picture1, new Vector3(0, 0, 0), Quaternion.identity);
        Picture1.SetActive(true);
        textDisplay.enabled = false;
        continueButton.SetActive(false);
    }


}
