using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeSubgenerator : SubGeneratorBase
{
    public CityData City;
    public GameObject NodePrefab;
    public float CityRadius;
    public float MaxNodeDistance;
    public float MinNodeDistance;
    public int MinNodesToGenerate;
    public int MaxNodesToGenerate;
    public int Tries;

    private int nodesBuilt;
    private int nodes;

    void Start()
    {
        nodes = Random.Range(MinNodesToGenerate, MaxNodesToGenerate);
    }

    public override void GenerateNext()
    {
        if (nodesBuilt < nodes)
        { 
            var node = Instantiate(NodePrefab, City.transform).transform;
            City.Hubs.Add(node);
            node.transform.localPosition = GetValidNodePosition();
            City.Buildings.Add(node.GetComponent<Building>());
            nodesBuilt++;
        }
        else
        {
            HasFinished = true;
        }
    }

    public Vector3 GetValidNodePosition()
    {
        var pos = Random.insideUnitCircle * CityRadius;
        var pos3 = new Vector3(pos.x, 0f, pos.y);
        var currentTries = Tries;

        while (!IsCorrectDistance(pos3) && currentTries > 0)
        {
            pos = Random.insideUnitCircle * CityRadius;
            pos3 = new Vector3(pos.x, 0f, pos.y);
            currentTries--;
        }

        return pos3;
    }

    bool IsCorrectDistance(Vector3 pos3)
    {
       return City.Hubs.All(x => Vector3.Distance(x.position, pos3) > MinNodeDistance) &&
            City.Hubs.Any(x => Vector3.Distance(x.position, pos3) < MaxNodeDistance);
    }
}
