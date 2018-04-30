using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime.DynamicDispatching;
using UnityEngine;

public class Hovercar : MonoBehaviour
{
    public float Acceleration;
    public float Deceleration;
    public float MaxSpeed;
    public float TurnAcceleration;
    public float MaxTurnSpeed;

    private float turn;
    private float speed;

	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Accelerate();
        }
        else
        {
            speed -= Deceleration;
            if (speed <= 0)
            {
                speed = 0;
            }
        }

        this.transform.Translate(Vector3.forward * speed);

        if (Input.GetKey(KeyCode.D))
        {
            turn += TurnAcceleration;
            if (turn > MaxTurnSpeed)
            {
                turn = MaxTurnSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            turn -= TurnAcceleration;
            if (turn < -MaxTurnSpeed)
            {
                turn = -MaxTurnSpeed;
            }
        }
        else
        {
            if (turn > 0)
            {
                turn -= TurnAcceleration;
                if (turn < 0.2f)
                {
                    turn = 0;
                }
            }
            else if (turn < 0)
            {
                turn += TurnAcceleration;
                if (turn > -0.2f)
                {
                    turn = 0;
                }
            }
        }

        Turn();
    }

    void Accelerate()
    {
        speed += Acceleration;
        if (speed > MaxSpeed)
        {
            speed = MaxSpeed;
        }
    }

    void Turn()
    {
        this.transform.Rotate(Vector3.up * turn);
    }
}
