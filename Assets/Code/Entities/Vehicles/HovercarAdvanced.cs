using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime.DynamicDispatching;
using UnityEngine;

public class HovercarAdvanced : MonoBehaviour
{
    public float Acceleration;
    public float Deceleration;
    public float MaxSpeed;
    public float SteerFactor;
    public float RollFactor;
    public float MaxPitch;
    public Transform Model;

    private float turn;
    private float amountTurned;
    private float speed;
    
	void FixedUpdate ()
    {
        this.transform.Translate(Vector3.forward * speed);
    }

    public void Break()
    {
        speed -= Deceleration;
        if (speed <= 0)
        {
            speed = 0;
        }
    }

    public void Accelerate()
    {
        speed += Acceleration;
        if (speed > MaxSpeed)
        {
            speed = MaxSpeed;
        }
    }

    public void Steer(Vector2 vector)
    {
        vector = vector * SteerFactor;
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
