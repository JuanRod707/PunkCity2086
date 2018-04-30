using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimuBuildingSpawner : MonoBehaviour
{
    public float SpawnRadius;
    public float MinDistance;
    public float MaxDistanceToCenter;
    public int Tries;
    public int MaxSpawnedBuildings;
    public float TickTimer;

    public bool isGenerating;
    private CityData City;
    public int generation;
    private float tickElapsed;
    private Transform buildings;
    private References refs;

    void Start()
    {
        refs = GameObject.Find("References").GetComponent<References>();
        City = GameObject.Find("Buildings").GetComponent<CityData>();
        buildings = GameObject.Find("Buildings").transform;
        tickElapsed = TickTimer;
    }

    void FixedUpdate()
    {
        tickElapsed -= Time.fixedDeltaTime;
        if (tickElapsed < 0)
        {
            Tick();
            tickElapsed = TickTimer;
        }
    }

    void Tick()
    {
        if (isGenerating)
        {
            var pos = Random.insideUnitCircle * SpawnRadius;
            var pos3 = new Vector3(this.transform.position.x + pos.x, this.transform.position.y, this.transform.position.z + pos.y);

            var bldg = Instantiate(refs.BuildingPfs.PickOne(), buildings);
            bldg.transform.position = pos3;
            var distance = Vector3.Distance(this.transform.position, bldg.transform.position);

            int tries = Tries;
            while (distance < MinDistance && tries > 0)
            {
                pos = Random.insideUnitCircle * SpawnRadius;
                pos3 = new Vector3(this.transform.position.x + pos.x, this.transform.position.y, this.transform.position.z + pos.y);
                bldg.transform.position = pos3;
                distance = Vector3.Distance(this.transform.position, bldg.transform.position);

                tries--;
            }

            bldg.GetComponent<SimuBuildingSpawner>().StartGenerating(generation-1);

            MaxSpawnedBuildings--;

            if (MaxSpawnedBuildings <= 0)
            {
                isGenerating = false;
            }
        }
    }

    public void StartGenerating(int gen)
    {
        this.generation = gen;

        if (Vector3.Distance(Vector3.zero, this.transform.position) < MaxDistanceToCenter)
        {
            isGenerating = true;
        }

        if (gen <= 0)
        {
            isGenerating = false;
        }
    }
}
