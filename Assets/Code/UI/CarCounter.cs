using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCounter : MonoBehaviour
{
    public Transform Traffic;
    public string Format;
    private Text myText;

    void Start()
    {
        myText = this.GetComponent<Text>();
    }

    void Update()
    {
        myText.text = string.Format(Format, Traffic.childCount);
    }
}