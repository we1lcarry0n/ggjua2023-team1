using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float baseSpeed;
    public float rotationSpeed;
    public float sprint;

    private Vector3 movementDirection;

    [SerializeField] private Animator animator;
    private NavMeshAgent nma;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movementDirection = Vector3.zero;
        movementDirection = x * Vector3.right + z * Vector3.forward;

        AdjustAnimation();

        float speed = Input.GetKey(KeyCode.LeftShift) ? baseSpeed*sprint : baseSpeed;

        nma.Move(movementDirection * Time.deltaTime * speed);
    }

    private void AdjustAnimation()
    {
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
            animator.SetFloat("Speed", Input.GetKey(KeyCode.LeftShift) ? 1f : .65f, .1f, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementDirection), Time.deltaTime * rotationSpeed);
        }
    }
}
