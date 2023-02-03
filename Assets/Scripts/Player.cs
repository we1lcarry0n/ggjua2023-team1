using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float baseSpeed;
    public float rotationSpeed;
    public float sprint;

    [SerializeField] private float maxStamina;
    [SerializeField] private float staminaConsumption;
    [SerializeField] private float staminaRegen;
    [SerializeField] private Image staminaBar;
    private float currentStamina;
    private bool isSprinting;

    private Vector3 movementDirection;

    [SerializeField] private Animator animator;
    private NavMeshAgent nma;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        currentStamina = maxStamina;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movementDirection = Vector3.zero;
        movementDirection = x * Vector3.right + z * Vector3.forward;

        AdjustAnimation();
        SprintCheck();
        
        float speed = isSprinting ? baseSpeed*sprint : baseSpeed;

        nma.Move(movementDirection * Time.deltaTime * speed);

        UpdateStamina();
        RefreshUI();
    }

    private void AdjustAnimation()
    {
        animator.Play(baseSpeed == 1.5 ? "Slowmotion" : "Locomotion");

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
            animator.SetFloat("Speed", Input.GetKey(KeyCode.LeftShift) ? 1f : .45f, .1f, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementDirection), Time.deltaTime * rotationSpeed);
        }
    }

    private void SprintCheck()
    {
        isSprinting = (Input.GetKey(KeyCode.LeftShift) && currentStamina != 0);
    }

    public void ConsumeStamina(float staminaConsumptionAmount)
    {
        currentStamina -= staminaConsumptionAmount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }

    public void RegenerateStamina(float staminaRegenAmount)
    {
        currentStamina += staminaRegenAmount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }
    private void UpdateStamina()
    {
        if (isSprinting)
        {
            ConsumeStamina(staminaConsumption * Time.deltaTime);
        }
        else if (!isSprinting && !Input.GetKey(KeyCode.LeftShift))
        {
            RegenerateStamina(staminaRegen * Time.deltaTime);
        }

    }

    private void RefreshUI()
    {
        if(currentStamina == maxStamina && staminaBar.enabled)
        {
            staminaBar.enabled = false;
        }
        else if(!staminaBar.enabled && currentStamina < maxStamina)
        {
            staminaBar.enabled = true;
        }
        staminaBar.fillAmount = currentStamina / maxStamina;
    }

    private IEnumerator WispCollisionCoroutine()
    {
        baseSpeed *= .5f;
        yield return new WaitForSeconds(5f);
        baseSpeed *= 2f;
    }

    public void ApplySpeedDebuff()
    {
        StartCoroutine(WispCollisionCoroutine());
    }
}
