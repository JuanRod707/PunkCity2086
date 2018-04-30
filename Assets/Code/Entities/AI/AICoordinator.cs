using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime.DynamicDispatching;
using UnityEngine;

public class AICoordinator : MonoBehaviour
{
    private AINavigator navigator;
    private AIParking parking;
    private AITakeoff takeoff;

    void Initialize()
    {
        navigator = this.GetComponent<AINavigator>();
        parking = this.GetComponent<AIParking>();
        takeoff = this.GetComponent<AITakeoff>();
    }

    public void Park(Garage trg)
    {
        this.GetComponentInChildren<DetectAhead>().enabled = false;
        this.GetComponentInChildren<Rigidbody>().isKinematic = true;
        this.GetComponent<CapsuleCollider>().enabled = false;

        navigator.enabled = false;
        parking.enabled = true;
        takeoff.enabled = false;

        parking.SetTarget(trg);
    }

    public void TakeOff(Garage trg)
    {
        Initialize();

        this.GetComponentInChildren<DetectAhead>().enabled = false;
        this.GetComponentInChildren<Rigidbody>().isKinematic = true;
        this.GetComponent<CapsuleCollider>().enabled = false;

        navigator.enabled = false;
        parking.enabled = false;
        takeoff.enabled = true;

        takeoff.SetTarget(trg);
    }

    public void Navigate()
    {
        this.GetComponentInChildren<DetectAhead>().enabled = true;
        this.GetComponentInChildren<Rigidbody>().isKinematic = false;
        this.GetComponent<CapsuleCollider>().enabled = true;

        navigator.enabled = true;
        parking.enabled = false;
        takeoff.enabled = false;

        navigator.SetTarget(GlobalAccess.GetRandomGarage());
    }
}
