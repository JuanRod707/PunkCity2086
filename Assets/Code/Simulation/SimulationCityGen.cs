using UnityEngine;

public class SimulationCityGen : MonoBehaviour
{
    public GameObject[] BuildingPfs;
    public float Radius;
    public int BuildingCount;
    public float MinY;
    public float MaxY;

    void Start()
    {
        while (BuildingCount > 0)
        {
            var pos = Random.insideUnitCircle * Radius;
            var bldg = Instantiate(BuildingPfs.PickOne(), this.transform);
            bldg.transform.localPosition = new Vector3(pos.x, 0f, pos.y);
            var euler = Vector3.zero;
            euler.y = Random.Range(0f, 360f);
            bldg.transform.eulerAngles = euler;

            var scale = bldg.transform.localScale;
            scale.y *= Random.Range(MinY, MaxY);
            bldg.transform.localScale = scale;

            BuildingCount--;
        }
    }
}
