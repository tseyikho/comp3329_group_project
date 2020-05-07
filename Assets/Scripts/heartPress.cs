using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class heartPress : MonoBehaviour
{
    public GameObject littleHeart;
    public GameObject bigHeart;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 20;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bigHeart.SetActive(false);
            littleHeart.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            bigHeart.SetActive(true);
            littleHeart.SetActive(false);
            index--;
        }
        if(index <= 0)
        {
            SceneManager.LoadScene("ForthScene");
        }
    }


}
