using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime.DynamicDispatching;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float DeadZone;

    private HovercarAdvanced controller;
    private Vector3 center;

    void Start()
    {
        controller = this.GetComponent<HovercarAdvanced>();
        center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            controller.Accelerate();
        }
        else
        {
            controller.Break();
        }

        var mCoord = Input.mousePosition;
        var resultSteer = center - mCoord;

        if (resultSteer.magnitude > DeadZone)
        {
            resultSteer.x *= -1;
            controller.Steer(resultSteer);
        }
    }
}
