using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour
{
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
   
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

       
            if (Mathf.Abs(steering)>0)
            {
                leftWheel.steerAngle = steering;
                rightWheel.steerAngle = steering;
            }
            if (Mathf.Abs(motor)>0)
            {
                leftWheel.motorTorque = motor;
                rightWheel.motorTorque = motor;
            }
        
    }
}
