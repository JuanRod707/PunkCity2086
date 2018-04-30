using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainSegmentSubgenerator : SubGeneratorBase
{
    public CityData City;
    public GameObject MainSegmentPf;

    private int hubIndex;
    private List<Transform> visitedHubs;

    public override void GenerateNext()
    {
        if (visitedHubs == null)
        {
            visitedHubs = new List<Transform>();
        }

        var currentHub = City.Hubs[hubIndex];
        visitedHubs.Add(currentHub);

        var neighbours = City.Hubs.Where(x => x != currentHub)
            .OrderBy(y => Vector3.Distance(y.position, currentHub.position)).Take(2);

        foreach (var n in neighbours)
        {
            if (!visitedHubs.Contains(n))
            {
                var middlePos = Vector3.Lerp(currentHub.position, n.position, 0.5f);
                var sgm = Instantiate(MainSegmentPf, middlePos, Quaternion.identity).GetComponent<Segment>();
                sgm.transform.LookAt(n.position);
                sgm.Length = Vector3.Distance(currentHub.position, n.position);
                City.Segments.Add(sgm);
                sgm.transform.SetParent(City.transform);
            }
        }

        hubIndex++;
        if (hubIndex >= City.Hubs.Count)
        {
            HasFinished = true;
        }
    }
}
