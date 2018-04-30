using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDispose : MonoBehaviour
{
    public float LifeTime;
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    LifeTime -= Time.fixedDeltaTime;
	    if (LifeTime < 0)
	    {
	        Destroy(this.gameObject);
	    }
	}
}
