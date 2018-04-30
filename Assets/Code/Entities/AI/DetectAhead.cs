using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Boo.Lang.Runtime.DynamicDispatching;
using UnityEngine;

public class DetectAhead : MonoBehaviour
{
    public float AvoidIncrement;
    public float MaxAvoidingFactor;

    private AINavigator navigator;
    private HovercarAdvanced controller;
    private List<Transform> detectedBuildings;
    private float avoidingFactor;

    void Start()
    {
        navigator = GetComponentInParent<AINavigator>();
        controller = GetComponentInParent<HovercarAdvanced>();
        detectedBuildings = new List<Transform>();
    }

    void FixedUpdate()
    {
        if (detectedBuildings.Any())
        {
            try
            {
                navigator.IsAvoiding = true;
                avoidingFactor = avoidingFactor < MaxAvoidingFactor ? avoidingFactor + AvoidIncrement : MaxAvoidingFactor;
                var closest = detectedBuildings
                    .OrderBy(x => Vector3.Distance(controller.transform.position, x.position))
                    .First();

                var relativePos = controller.transform.InverseTransformPoint(closest.position);
                var steering = new Vector2(-relativePos.x * avoidingFactor, 0f);
                controller.Steer(steering);
            }
            catch
            {
            }
        }
        else
        {
            navigator.IsAvoiding = false;
            avoidingFactor = avoidingFactor > 0 ? avoidingFactor - AvoidIncrement : 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (detectedBuildings != null)
        {
            if (other.tag.Equals("Obstacle"))
            {
                detectedBuildings.Remove(other.transform);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (detectedBuildings != null)
        {
            if (other.tag.Equals("Obstacle"))
            {
                if (!detectedBuildings.Contains(other.transform))
                {
                    detectedBuildings.Add(other.transform);
                }
            }
        }
    }


}
