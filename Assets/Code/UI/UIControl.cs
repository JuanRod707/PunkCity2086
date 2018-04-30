using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public GameObject StatusPanel;
    public GameObject Crosshair;
    private bool isUIHidden;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (isUIHidden)
            {
                isUIHidden = false;
                StatusPanel.SetActive(true);
                Crosshair.SetActive(true);
            }
            else
            {
                isUIHidden = true;
                StatusPanel.SetActive(false);
                Crosshair.SetActive(false);
            }
        }
    }
}