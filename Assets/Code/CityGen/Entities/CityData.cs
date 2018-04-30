using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CityData : MonoBehaviour
{
    public List<Transform> Hubs;
    public List<Building> Buildings;
    public List<Segment> Segments;

    public bool IsLegalPosition(Vector3 pos, float distance)
    {
        if (!Buildings.Any())
        {
            return true;
        }

        return Buildings.All(x => Vector3.Distance(x.transform.position, pos) > distance);
    }
}
