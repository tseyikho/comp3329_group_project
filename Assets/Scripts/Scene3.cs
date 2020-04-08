using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Scene3 : MonoBehaviour   
{
    public TextMeshProUGUI textDisplay;
    public GameObject continueButton;
    public GameObject dialogBox;
    public GameObject Picture1;
    private int index = 1;

    public void NextSentence()
    {
        //textDisplay.enabled = false;
        continueButton.SetActive(false);
        //dialogBox.SetActive(false);

        if (index == 2)
        {
            textDisplay.SetText("What next step should you take?");
            index++;
            continueButton.SetActive(true);
        }
        //index = 3. continue.
        if (index == 3)
        {
            index++;
            SceneManager.LoadScene("question2");
            //Instantiate(Picture1, new Vector3(0, 0, 0), Quaternion.identity);
            //Picture1.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.name == "dirtyCloth")
                {
                    print("You hit dirty cloth");
                }
                if (hit.transform.name == "cleanCloth")
                {
                    print("yout hit clean cloth");
                    textDisplay.SetText("You are right. We should clean the person’s wound with the clean cloth first.");
                    continueButton.SetActive(true);
                    index = 2;
                }
            }
        }        
    }


}
