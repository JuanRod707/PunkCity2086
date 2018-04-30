using UnityEngine;

public class AINavigator : MonoBehaviour
{
    public float SteeringTolerance;
    public float DistanceToTarget;

    [HideInInspector] public bool IsAvoiding;

    private Garage target;
    private HovercarAdvanced controller;
    
    public void SetTarget(Garage trg)
    {
        target = trg;
    }

    void Start()
    {
        controller = this.GetComponent<HovercarAdvanced>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            controller.Accelerate();
            if (!IsAvoiding)
            {
                Steer();
            }

            if (Vector3.Distance(this.transform.position, target.Entrance.position) < DistanceToTarget)
            {
                var coordinator = this.GetComponent<AICoordinator>();

                if (target.IsBusy)
                {
                    coordinator.Navigate();
                }
                else
                {
                    coordinator.Park(target);
                }
            }
        }
    }

    void Steer()
    {
        var relativePos = this.transform.InverseTransformPoint(target.Entrance.position);
        var steer = Vector2.zero;

        steer.x = relativePos.x/2;
        steer.y = -relativePos.y;

        controller.Steer(steer);
    }
}
