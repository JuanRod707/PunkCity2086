using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public float XSeparation;
    public float BuildingSeparation;
    public int BuildingsToPlace;

    private Segment sgm;
    private References refs;
    private CityData city;
    
    void Start()
    {
        refs = GlobalAccess.GetReferences();
        city = GlobalAccess.GetCity();
        sgm = this.GetComponent<Segment>();
    }

    public void SpawnNewBuilding()
    {
        var pos = sgm.GetPointInSegment();
        var rot = Vector3.zero;

        if (MathHelper.DiceRoll(50))
        {
            pos.x = XSeparation;
            rot.y = -90f;
        }
        else
        {
            pos.x = -XSeparation;
            rot.y = 90f;
        }

        if (city.IsLegalPosition(this.transform.TransformPoint(pos), BuildingSeparation))
        {
            BuildingsToPlace--;
            var bldg = Instantiate(refs.BuildingPfs.PickOne(), this.transform).transform;
            bldg.localPosition = pos;
            bldg.localEulerAngles = rot;

            city.Buildings.Add(bldg.GetComponent<Building>());
            bldg.SetParent(city.transform);
        }
    }
}
