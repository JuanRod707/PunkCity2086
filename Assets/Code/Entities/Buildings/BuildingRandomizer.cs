using UnityEngine;

public class BuildingRandomizer : MonoBehaviour
{
    public float BaseMultiplier;
    public float HeightMultiplier;
    public float MinMultiplier;

    void Start()
    {
        var scale = new Vector3(Random.Range(1, BaseMultiplier), Random.Range(MinMultiplier, HeightMultiplier), Random.Range(1, BaseMultiplier));
        this.transform.localScale = scale;
    }
}
