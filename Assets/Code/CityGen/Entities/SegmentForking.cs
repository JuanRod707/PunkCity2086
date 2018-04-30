using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SegmentForking : MonoBehaviour
{
    public float ForkPerDistance;
    public int IntersectionChance;
    public float MinDistance;
    public int MinForks;

    private int maxForks;
    private int forkCount;
    private Segment sgm;

    void Start()
    {
        sgm = this.GetComponent<Segment>();
        maxForks = (int)(sgm.Length / ForkPerDistance);
        forkCount = Random.Range(MinForks, maxForks);

        if (forkCount > 0)
        {
            Fork();
        }
    }

    void Fork()
    {
        var existingForks = new List<Vector3>();

        while (forkCount > 0)
        {
            var pos = sgm.GetPointInSegment();
            if (!existingForks.Any() || existingForks.Any(x => Vector3.Distance(pos, x) < MinDistance))
            {
                var fork = Instantiate(GlobalAccess.GetReferences().SmallSegmentPf, this.transform)
                    .GetComponent<Segment>();
                var length = Random.Range(sgm.Length / 1.5f, sgm.Length);
                existingForks.Add(pos);
                if (MathHelper.DiceRoll(IntersectionChance))
                {
                    if (MathHelper.DiceRoll(50))
                    {
                        pos.x = length / 2;
                    }
                    else
                    {
                        pos.x = -length / 2;
                    }
                }


                fork.Length = length;
                fork.transform.localPosition = pos;
                fork.transform.localEulerAngles = new Vector3(0, 90, 0);
                GlobalAccess.GetCity().Segments.Add(fork);
                fork.transform.SetParent(GlobalAccess.GetCity().transform);

            }

            forkCount--;
        }
    }
}
