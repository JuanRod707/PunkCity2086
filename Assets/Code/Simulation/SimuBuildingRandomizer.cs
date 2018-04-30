using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SimuBuildingRandomizer : MonoBehaviour
{
    public float MinY;
    public float MaxY;

    void Start()
    {
        var euler = Vector3.zero;
        euler.y = Random.Range(0f, 360f);
        this.transform.eulerAngles = euler;

        var scale = this.transform.localScale;
        scale.y *= Random.Range(MinY, MaxY);
        this.transform.localScale = scale;
    }
}
