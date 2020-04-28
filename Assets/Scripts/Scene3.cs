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
    public static int stage = 1;
    public static int index_part = 1;

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        print("stage : " + stage);

        if(stage == 5)
        {
            SceneManager.LoadScene("Scene3");
        }

        if (stage == 4)
        {
            stage++;
            textDisplay.SetText("Now go back to the medicine cabinet and select something to wrap the wound");
            continueButton.SetActive(true);
            index_part = 3;
        }

        //stage = 3. continue.
        if (stage == 3)
        {
            print("running nextsentence index = 3 ");
            stage++;
            SceneManager.LoadScene("question2");
            //Instantiate(Picture1, new Vector3(0, 0, 0), Quaternion.identity);
            //Picture1.SetActive(true);
        }

        if (stage == 2)
        {
            print("running nextsentence index = 2 ");
            textDisplay.SetText("What next step should you take?");
            stage++;
            continueButton.SetActive(true);
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
                if (hit.transform.name == "antiseptic" && index_part == 2)
                {
                    print("You hit antiseptic and the index_part = " + index_part);
                    textDisplay.SetText("Great! You're almost there!");

                }
                if (hit.transform.name == "cleanCloth" && index_part == 1)
                {
                    print("index_part : " + index_part);
                    print("yout hit clean cloth");
                    textDisplay.SetText("You are right. We should clean the person’s wound with the clean cloth first.");
                    continueButton.SetActive(true);
                    stage = 2;
                }
                if (hit.transform.name == "bandageRoll" && index_part == 3)
                {
                    print("you hit bandageRoll and the index_part = " + index_part);
                    textDisplay.SetText("Objective accomplished! Level cleared!");
                    continueButton.SetActive(false);

                }
            }
        }        
    }


}
