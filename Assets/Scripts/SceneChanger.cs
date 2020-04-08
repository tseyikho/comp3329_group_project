﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public Dialog dialog;

    public void SceneQuestion1()
    {
        SceneManager.LoadScene("question1");        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }

    public void question1CorrectAnswer()
    {   
        StartCoroutine(wait());
        SceneManager.LoadScene("Scene2");
    }
}