using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime.DynamicDispatching;
using UnityEngine;

public class HovercarWeapons : MonoBehaviour
{
    public GameObject PlasmaShotPf;
    public GameObject BeamShotPf;
    public Transform GunPoint;
    public float RateOfFire;

    private float fireElapsed;

	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetMouseButton(0))
        {
            if (fireElapsed <= 0)
            {
                FirePlasma();
                fireElapsed = RateOfFire;
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (fireElapsed <= 0)
            {
                FireBeam();
                fireElapsed = RateOfFire;
            }
        }

        if (fireElapsed > 0)
        {
            fireElapsed -= Time.fixedDeltaTime;
        }
    }

    void FirePlasma()
    {
        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        var plasma = Instantiate(PlasmaShotPf, GunPoint.position, Quaternion.identity);
        plasma.transform.LookAt(mouseRay.GetPoint(100));
    }

    void FireBeam()
    {
        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        var beam = Instantiate(BeamShotPf, GunPoint.position, Quaternion.identity).GetComponent<LineRenderer>();

        beam.SetPosition(0, GunPoint.position);
        beam.SetPosition(1, mouseRay.GetPoint(100));
    }
}
