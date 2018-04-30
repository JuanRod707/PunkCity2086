using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratorMaster : MonoBehaviour
{
    public float InitialDelay;
    public float StepTimer;
    public CityData City;

    private float stepElapsed;
    private List<SubGeneratorBase> subGens;
    private SubGeneratorBase currentSubgen;
    private int subGenIndex;
    private bool hasFinished;
    private float tickElapsed;

    // Use this for initialization
    void Start () {
        City.Buildings = new List<Building>();
	    City.Hubs = new List<Transform>();

        subGens = this.GetComponentsInChildren<SubGeneratorBase>().OrderBy(x => x.Priority).ToList();
	    currentSubgen = subGens.First();
	    subGenIndex = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (InitialDelay < 0)
        {
            tickElapsed -= Time.fixedDeltaTime;
            if (tickElapsed < 0)
            {
                Tick();
                tickElapsed = StepTimer;
            }
        }
        else
        {
            InitialDelay -= Time.fixedDeltaTime;
        }
    }

    void Tick()
    {
        if (!hasFinished && currentSubgen != null)
        {
            if (currentSubgen.HasFinished)
            {
                subGenIndex++;
                if (subGenIndex >= subGens.Count)
                {
                    hasFinished = true;
                }
                else
                {
                    currentSubgen = subGens[subGenIndex];
                }
            }
            else
            {
                currentSubgen.GenerateNext();
            }
        }
    }
}
