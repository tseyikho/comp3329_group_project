using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private DisplayImage currentDisplay;
    public ParticleSystem stream;
    public GameObject fireExtinguisherSound;
    public AudioSource source;
    public AudioClip clip;
    void Start()
    {
        currentDisplay = GameObject.Find("Display Wall").GetComponent<DisplayImage>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 rayPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPostion, Vector2.zero, 100);

            if (hit && hit.transform.tag == "Interactable")
            {
                hit.transform.GetComponent<IInteractable>().Interact(currentDisplay);
            }

            if (currentDisplay.ExtinguisherIsActive)
            {
                Vector2 spawnPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Destroy(Instantiate(stream, spawnPoint, Quaternion.identity),1);
                currentDisplay.StreamIsActive = true;
                fireExtinguisherSound.SetActive(true);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            currentDisplay.StreamIsActive = false;
            fireExtinguisherSound.SetActive(false);
        }
    }
}
