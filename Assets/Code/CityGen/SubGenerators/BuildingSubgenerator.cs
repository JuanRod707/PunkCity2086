using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingSubgenerator : SubGeneratorBase
{
    public CityData City;
    public int MaxBuildings;

    public override void GenerateNext()
    {
        if (MaxBuildings <= 0)
        {
            HasFinished = true;
        }

        if (!HasFinished)
        {
            City.Segments.PickOne().GetComponent<BuildingSpawner>().SpawnNewBuilding();
            MaxBuildings--;
        }
    }
}
