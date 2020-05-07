using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireHandler : MonoBehaviour
{
    private DisplayImage currentDisplay;

    private Animator fireAnim;
    public GameObject smoke;
    public float spawnTime;
    float time;
    float timeStart;
    float timeSpread;
    public float fireSpread = 20;
    public GameObject fire;
    public GameObject button;
    public BoxCollider2D window;
    public BoxCollider2D frame;
    public BoxCollider2D fireExtinguisherFrame;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("Display Wall").GetComponent<DisplayImage>();
        timeStart = Time.timeSinceLevelLoad;
        timeSpread= Time.timeSinceLevelLoad;
        fireAnim = this.GetComponent<Animator>();
        InvokeRepeating("addSmoke", spawnTime, spawnTime);
    }



    // Update is called once per frame
    void Update()
    {
        time = Time.timeSinceLevelLoad;
        fireAnim.SetFloat("Time", time-timeStart);
        if (time - timeSpread > fireSpread)
        {
            addFire();
            timeSpread = time;
        }
        if (currentDisplay.StreamIsActive)
        {
            button.SetActive(true);
        }
        if (!(currentDisplay.StreamIsActive))
        {
            button.SetActive(false);
        }
    }

    void addSmoke()
    {
        Renderer rd = GetComponent<Renderer>();
        float s = rd.bounds.size.x / 2;

        // Variables to store the X position of the spawn object
        float x1 = transform.position.x - s;
        float x2 = transform.position.x + s;

        // Randomly pick a point within the spawn object    
        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y + 1);

        // Create an enemy at the 'spawnPoint' position    
        GameObject smokeObject = Instantiate(smoke, spawnPoint, Quaternion.identity);

        float scale = 0.1f * Random.Range(2, 4)* (time - timeStart) / 40;
        smokeObject.transform.localScale = new Vector3(scale, scale, scale);

    }

    void addFire()
    {
        if (currentDisplay.FireNumber < 300)
        {
            Renderer rd = GetComponent<Renderer>();
            float s = rd.bounds.size.x / 2 + 1;

            // Variables to store the X position of the spawn object
            float x1 = transform.position.x - s;
            float x2 = transform.position.x + s;
            float y1 = transform.position.y - s;
            float y2 = transform.position.y + s;
            // Randomly pick a point within the spawn object    
            Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));
            // Create an enemy at the 'spawnPoint' position   
            // Check if the spawnPoint is on in the window
            if (frame.bounds.Contains(new Vector3(spawnPoint.x, spawnPoint.y, (float)90.0))){
                if (!(window.bounds.Contains(new Vector3(spawnPoint.x, spawnPoint.y, (float)90.0))))
                {
                    if (!(fireExtinguisherFrame.bounds.Contains(new Vector3(spawnPoint.x, spawnPoint.y, (float)0.0))))
                    {
                        GameObject fireObject = Instantiate(fire, spawnPoint, Quaternion.identity);
                        currentDisplay.FireNumber = currentDisplay.FireNumber + 1;
                    }
                }
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
        currentDisplay.FireNumber = currentDisplay.FireNumber - 1;
    }
}