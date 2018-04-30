using System;
using System.Linq;
using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    public GameObject[] HovercarPfs;
    public float SpawnTimer;
    public int MaxCars;

    private Transform traffic;
    private float spawnElapsed;

    void Start()
    {
        spawnElapsed = SpawnTimer;
        traffic = GameObject.Find("Traffic").transform;
    }

    void FixedUpdate()
    {
        if (spawnElapsed <= 0 && AreThereGarages())
        {
            if (traffic.childCount < MaxCars)
            {
               SpawnCar();
            }
        }

        spawnElapsed -= Time.fixedDeltaTime;
    }

    bool AreThereGarages()
    {
        return this.GetComponentsInChildren<Transform>().Any(x => x.tag.Equals("Garage"));
    }

    void SpawnCar()
    {
        try
        {
            var spawnPoint = GlobalAccess.GetRandomGarage();
            var car = Instantiate(HovercarPfs.PickOne(), spawnPoint.transform.position, spawnPoint.transform.rotation);
            car.transform.SetParent(traffic);
            spawnElapsed = SpawnTimer;
            car.GetComponent<AICoordinator>().TakeOff(spawnPoint);
        }
        catch (Exception e)
        {
            DebugConsole.LogMessage(e.Message);
        }
    }
}


