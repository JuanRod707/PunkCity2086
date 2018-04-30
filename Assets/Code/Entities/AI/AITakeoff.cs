using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime.DynamicDispatching;
using UnityEngine;

public class AITakeoff : MonoBehaviour
{
    public float DistanceToTarget;
    public float SpeedModifier;
    
    private Garage target;
    private HovercarAdvanced controller;

    public void SetTarget(Garage trg)
    {
        target = trg;
        target.OccupyGarage();
    }

    void Start()
    {
        controller = this.GetComponent<HovercarAdvanced>();
        controller.MaxSpeed *= SpeedModifier;

        this.GetComponentInChildren<DetectAhead>().enabled = false;
        this.GetComponentInChildren<Rigidbody>().isKinematic = true;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Steer();
            controller.Accelerate();

            if (Vector3.Distance(this.transform.position, target.Entrance.position) < DistanceToTarget)
            {
                controller.MaxSpeed /= SpeedModifier;
                this.GetComponent<AICoordinator>().Navigate();
                target.UnoccupyGarage();
            }
        }
    }

    void Steer()
    {
        var relativePos = this.transform.InverseTransformPoint(target.Entrance.position);
        var steer = Vector2.zero;

        steer.x = relativePos.x;
        steer.y = -relativePos.y;

        controller.Steer(steer);
    }
}
