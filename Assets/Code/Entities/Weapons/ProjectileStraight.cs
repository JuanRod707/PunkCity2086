using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStraight : MonoBehaviour
{

    public float Speed;
    
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate(Vector3.forward * Speed);
	}
}
