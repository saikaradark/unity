using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coche : MonoBehaviour
{
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public Text txtSpeed;
    private Rigidbody rbCoche;
    public float brakeForce;
    public void FixedUpdate()
    {
        txtSpeed.text = rbCoche.velocity.magnitude.ToString();
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
                leftWheel.brakeTorque


            }
            if (Input.GetKey(KeyCode.LeftControl))
        {
            leftWheel.brakeTorque = leftWheel.brakeTorque + brakeForce;
            rightWheel.brakeTorque = leftWheel.brakeTorque + brakeForce;
        }
            if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;
        }
    }
}
