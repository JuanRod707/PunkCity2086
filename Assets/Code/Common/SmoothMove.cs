using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    public Transform Target;
    public float LerpFactor;
	
	void FixedUpdate ()
	{
	    if (Target != null)
	    {
	        this.transform.position = Vector3.Lerp(this.transform.position, Target.position, LerpFactor);
	    }
	}

    public void SetTarget(Transform target)
    {
        Target = target;
    }
}
