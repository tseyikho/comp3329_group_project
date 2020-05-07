using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeScript : MonoBehaviour
{
    private DisplayImage currentDisplay;
    private Animator smokeAnim;

    public int speed = -5;
    public Rigidbody2D rb;
    public Vector2 v;
    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("Display Wall").GetComponent<DisplayImage>();
        smokeAnim = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        v = rb.velocity;
        v.x = 0;
        v.y = speed;
        rb.velocity = v;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDisplay.CurrentWall == 2)
        {
            smokeAnim.SetBool("Fade", true);
            Destroy(gameObject, 10);
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
