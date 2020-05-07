using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSize : MonoBehaviour
{
    Vector3 defaultScale;

    public void OnMouseDown()
    {
        defaultScale = transform.localScale;
        Vector3 scale = defaultScale;
        scale.x = scale.x * 1.1f;
        scale.y = scale.y * 1.1f;
        transform.localScale = scale;
    }

    public void OnMouseUp()
    {
        Vector3 scale = defaultScale;
        transform.localScale = scale;
    }

}
