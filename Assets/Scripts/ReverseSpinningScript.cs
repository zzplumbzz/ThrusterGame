using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseSpinningScript : MonoBehaviour
{
   public float speed;
    public float angularSpeed;
    protected Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //sets the speed and velocity of torque trap
        speed = rb.velocity.magnitude;
        angularSpeed = rb.angularVelocity.magnitude;
        rb.maxAngularVelocity = 1f;
        rb.AddTorque(Vector3.back);
    }
}
