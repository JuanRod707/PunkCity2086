using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasecam : MonoBehaviour
{
    public SmoothMove TargetView;
    public float MoveSpeed;

    private HovercarAnchor targetShip;

    void FixedUpdate()
    {
        if (targetShip != null)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, targetShip.ChasePosition.position, MoveSpeed);
        }

        if (TargetView != null)
        {
            this.transform.LookAt(TargetView.transform);
        }

        var eul = this.transform.eulerAngles;
        eul.z = 0f;
        this.transform.eulerAngles = eul;
    }

    public void AttachToAnchor(HovercarAnchor anch)
    {
        targetShip = anch;
        TargetView.Target = anch.TargetPoint;
    }
}
