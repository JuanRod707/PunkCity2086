using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSteering : MonoBehaviour
{
    public float SteerFactor;
    public float RollFactor;
    public float MaxPitch;
    public Transform Model;
    public float DeadZone;

    private float turn;
    private float amountTurned;
    
    private Vector3 center;

    void Start()
    {
        center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        var mCoord = Input.mousePosition;
        var resultSteer = center - mCoord;
        
        if (resultSteer.magnitude > DeadZone)
        {
            resultSteer.x *= -1;
            Steer(resultSteer * SteerFactor);
        }
    }

    void Steer(Vector2 vector)
    {
        this.transform.Rotate(0f, vector.x, 0f);

        if (vector.y > 0 && amountTurned <= MaxPitch)
        {
            amountTurned += vector.y;
            this.transform.Rotate(vector.y, 0f, 0f);
        }
        else if (vector.y < 0 && amountTurned >= -MaxPitch)
        {
            amountTurned += vector.y;
            this.transform.Rotate(vector.y, 0f, 0f);
        }

        Model.localEulerAngles = new Vector3(0f, 180f, vector.x * RollFactor);
        Normalize();
    }

    void Normalize()
    {
        var eul = this.transform.eulerAngles;
        eul.z = 0f;
        this.transform.eulerAngles = eul;
    }
}
