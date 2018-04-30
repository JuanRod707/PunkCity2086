using UnityEngine;

public class DetailRandomizer : MonoBehaviour
{
    public int RoofChance;
    public int SideChance;

    public Transform[] RoofDetails;
    public Transform[] SideDetails;

    void Start()
    {
        var refs = GameObject.Find("References").GetComponent<References>();

        foreach (var r in RoofDetails)
        {
            if (MathHelper.DiceRoll(RoofChance))
            {
                Instantiate(refs.RoofsPfs.PickOne(), r);
            }
        }

        foreach (var s in SideDetails)
        {
            if (MathHelper.DiceRoll(SideChance))
            {
                Instantiate(refs.SidesPfs.PickOne(), s);
            }
        }
    }
}
