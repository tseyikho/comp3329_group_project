using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayImage : MonoBehaviour
{
    public enum State
    {
        normal, zoom
    };

    public State CurrentState{ get; set; }
    public int CurrentWall
    {
        get { return currentWall; }
        set
        {
            if (value == 5)
                currentWall = 1;
            else if (value == 0)
                currentWall = 4;
            else
                currentWall = value;
        }
    }

    public int FireNumber
    {
        get { return fireNumber; }
        set
        { fireNumber = value;}
    }

    public bool ExtinguisherIsActive
    {
        get { return extinguisherIsActive; }
        set
        { extinguisherIsActive = value; }
    }

    public bool StreamIsActive
    {
        get { return streamIsActive; }
        set
        { streamIsActive = value; }
    }

    public bool extinguisherIsActive = false;
    public bool streamIsActive = false;
    private int currentWall;
    private int previousWall;
    private int fireNumber=1;
    public int maxFireNumber = 100;
    public Slider slider;
    public GameObject exitButton;

    void Start()
    {
        previousWall = 0;
        currentWall = 1;
    }

    void Update()
    {
        if (currentWall != previousWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWall.ToString());
        }
        previousWall = currentWall;
        if (currentWall == 1)
        {
            slider.maxValue = 100;
            slider.value = fireNumber + 25;
            if (fireNumber >= 75)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        if (currentWall == 2)
        {
            slider.maxValue = 100;
            slider.value = fireNumber;
            if (fireNumber >= 100)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        if (fireNumber <= 0)
        {
            extinguisherIsActive = false;
            exitButton.SetActive(true);
        }

    }


    //void OnGUI()
    //{
    //    if (fireNumber >= maxFireNumber)
    //    {
    //        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 500, 200), "<size=80><color=black>Game Over</color></size>");
    //        Time.timeScale = 0;
    //    }
    //}



}
