using UnityEngine;

public class AIParking : MonoBehaviour
{
    public float ParkingDelay;
    public float DistanceToTarget;
    public float SpeedModifier;

    private Garage target;
    private HovercarAdvanced controller;

    public void SetTarget(Garage trg)
    {
        target = trg;
        target.OccupyGarage();
    }

    void Start()
    {
        controller = this.GetComponent<HovercarAdvanced>();
        controller.MaxSpeed *= SpeedModifier;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            if (ParkingDelay > 0)
            {
                Steer();
                controller.Break();
                ParkingDelay -= Time.fixedDeltaTime;
            }
            else
            {
                controller.Accelerate();
                if (Vector3.Distance(this.transform.position, target.transform.position) < DistanceToTarget)
                {
                    Destroy(this.gameObject);
                    target.UnoccupyGarage();
                }
            }
        }
    }

    void Steer()
    {
        var relativePos = this.transform.InverseTransformPoint(target.transform.position);
        var steer = Vector2.zero;

        steer.x = relativePos.x;
        steer.y = -relativePos.y;

        controller.Steer(steer);
    }
}
