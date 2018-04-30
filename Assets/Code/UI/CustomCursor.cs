using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{
    private RectTransform myRect;
    
    void Start()
    {
        myRect = this.GetComponent<RectTransform>();
        Cursor.visible = false;
    }

    void Update()
    {
        myRect.position = Input.mousePosition;
    }
}