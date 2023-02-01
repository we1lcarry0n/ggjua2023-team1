using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float force;
    public float sprint;
    public float gravity;

    private Vector3 movementDirection;

    [SerializeField] private Animator animator;
    private CharacterController chc;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        chc = GetComponent<CharacterController>();
    }


    private void Update()
    {
        if (chc.isGrounded)
        {

        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movementDirection = Vector3.zero;
        Debug.Log(chc.isGrounded);
        
        
        movementDirection = x * Vector3.right + z * Vector3.forward;

        movementDirection.Normalize();
        ApplyGravity();

        if (movementDirection.z == 0 && movementDirection.x == 0)
        {
            animator.SetFloat("Speed", 0, .1f, Time.deltaTime);
        }
        else if (movementDirection == Vector3.zero)
        {
            animator.SetFloat("Speed", .15f, .1f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Speed", 1, .1f, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementDirection), Time.deltaTime*rotationSpeed);
        }

        chc.Move(movementDirection * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //rb.AddForce(transform.forward * force, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //rb.AddForce(transform.forward * sprint);
        }
    }

    private void ApplyGravity()
    {
        if (chc.isGrounded)
        {
            movementDirection.y = -gravity * .02f;
        }
        else
        {
            movementDirection.y = - gravity * Time.deltaTime;
        }
    }
}
