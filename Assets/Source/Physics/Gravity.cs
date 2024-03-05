using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    [SerializeField]
    private float gravityScale = 9.81f;
    
    public bool useCustomGravity = true;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        if (useCustomGravity)
        {
            ApplyGravity();
        }
    }

    private void ApplyGravity()
    {
        Vector3 gravityDirection = (Physics.gravity.normalized * gravityScale);
        Vector3 gravityVector = gravityDirection * Time.fixedDeltaTime;
        rb.AddForce(gravityVector, ForceMode.VelocityChange);
    }
}
