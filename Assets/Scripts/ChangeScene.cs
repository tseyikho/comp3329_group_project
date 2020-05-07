using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public AudioSource TeleportationSound;
    public AudioSource BackgroundSong;
    public void nextScene()
    {
        StartCoroutine(HandleIt());
    }
    private IEnumerator HandleIt()
    {
        BackgroundSong.Stop();
        TeleportationSound.Play();
        yield return new WaitForSeconds(0.5f);
        name = gameObject.name;
        SceneManager.LoadScene(name);
    }
}