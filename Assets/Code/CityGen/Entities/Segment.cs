using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [HideInInspector] public float Length;
    public float Width;
    public Transform Quad;

    void Start()
    {
        Quad.transform.localScale = new Vector3(Width, Length, 1);
    }

    public Vector3 GetPointInSegment()
    {
        return new Vector3(0f, 0f, Random.Range(-Length / 2, Length / 2));
    }
}
