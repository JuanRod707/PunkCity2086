using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBounds : MonoBehaviour
{
    public float BoundDistance;

    [HideInInspector] public Vector2 Center;
    [HideInInspector] public float BoundPosX;
    [HideInInspector] public float BoundNegX;
    [HideInInspector] public float BoundPosY;
    [HideInInspector] public float BoundNegY;

    void Start()
    {
        Center = this.transform.position;
        BoundPosX = this.transform.position.x + BoundDistance;
        BoundNegX = this.transform.position.x - BoundDistance;
        BoundPosY = this.transform.position.y + BoundDistance;
        BoundNegY = this.transform.position.y - BoundDistance;
    }
}
