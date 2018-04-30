using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAdvert : MonoBehaviour
{
    public int MaterialIndex;
    public float MinInterval;
    public float MaxInterval;

    private float intervalElapsed;

    // Update is called once per frame
    void FixedUpdate ()
	{
	    if (intervalElapsed < 0)
	    {
	        var mesh = this.GetComponent<MeshRenderer>();

            var mats = mesh.materials;
	        mats[MaterialIndex] = GlobalAccess.GetReferences().AdLights.PickOne();
	        mesh.materials = mats;

	        ResetInterval();
	    }

	    intervalElapsed -= Time.fixedDeltaTime;
	}

    void ResetInterval()
    {
        intervalElapsed = Random.Range(MinInterval, MaxInterval);
    }
}
