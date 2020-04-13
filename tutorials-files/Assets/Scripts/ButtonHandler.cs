using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private DisplayImage currentDisplay;

    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    


    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;
    }

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }

    public void OnClickZoomReturn()
    {
        GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.normal;
        var zoomInOnjects = FindObjectsOfType<ZoomInObject>();
        foreach(var zoomInObject in zoomInOnjects)
        {
            zoomInObject.gameObject.layer = 0;
        }
        Camera.main.orthographicSize = initialCameraSize;
        Camera.main.transform.position = initialCameraPosition;

    }
}
