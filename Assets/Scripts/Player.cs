using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float force;
    public float sprint;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.position += transform.forward * z * speed;

        transform.Rotate(0, x * rotationSpeed, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(transform.forward * sprint);
        }
    }
}
