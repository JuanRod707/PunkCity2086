using UnityEngine;

public class Garage : MonoBehaviour
{
    public Transform Entrance;
    private bool isBusy;

    public bool IsBusy { get { return this.isBusy; } }

    public void OccupyGarage()
    {
        isBusy = true;
    }

    public void UnoccupyGarage()
    {
        isBusy = false;
    }
}
