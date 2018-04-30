using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject BuildingPf;
    public float Radius;
    public int BuildingCount;
    public float MinY;
    public float MaxY;


    void Start()
    {
        UnityEngine.Random.InitState(67);

        while (BuildingCount > 0)
        {
            var pos = Random.insideUnitCircle * Radius;
            var bldg = Instantiate(BuildingPf, this.transform);
            bldg.transform.localPosition = new Vector3(pos.x, 0f, pos.y);
            var euler = Vector3.zero;
            euler.y = Random.Range(0f, 360f);
            bldg.transform.eulerAngles = euler;
            bldg.transform.localScale = new Vector3(1, Random.Range(MinY, MaxY), 1f);

            BuildingCount--;
        }
    }
}
